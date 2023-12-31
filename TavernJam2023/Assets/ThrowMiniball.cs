using UnityEngine;
using System.Collections.Generic;

public class ThrowMiniball : MonoBehaviour
{
    public GameObject rockPrefab;
    [SerializeField] public AudioClip throwSound; // Serialized field for the rock throw sound
    private AudioSource audioSource;
    private float throwForce = 7f;
    private float arcHeight = 0f;
    private int maxRocks = 3;
    private List<GameObject> rocks = new List<GameObject>();

    void Start()
    {
        // Ensure there is an AudioSource component and get a reference to it
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && rocks.Count < maxRocks) // Left mouse click
        {
            Throw();
        }

        // Remove any null (destroyed) rocks from the list
        rocks.RemoveAll(rock => rock == null);
    }

    void Throw()
    {
        GameObject rock = Instantiate(rockPrefab, transform.position, Quaternion.identity);
        rocks.Add(rock);
        StartCoroutine(ArcRock(rock));

        // Play throw sound
        if (throwSound != null)
        {
            audioSource.PlayOneShot(throwSound);
        }
    }

    Vector3 GetThrowDirection()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure it's 2D
        Vector3 throwDirection = (mousePosition - transform.position).normalized * throwForce;
        return throwDirection;
    }

    System.Collections.IEnumerator ArcRock(GameObject rock)
    {
        Vector3 startPos = rock.transform.position;
        Vector3 throwDirection = GetThrowDirection();
        Vector3 endPos = startPos + throwDirection;
        float duration = 1f; // Duration of the throw

        float elapsed = 0;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float height = Mathf.Sin(Mathf.PI * elapsed / duration) * arcHeight;
            rock.transform.position = Vector3.Lerp(startPos, endPos, elapsed / duration) + Vector3.up * height;
            yield return null;
        }

        Destroy(rock);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class GoblinScript : MonoBehaviour
{

    [SerializeField] Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }

    //private void OnMouseDown()
    //{
    //    Debug.Log("BRUH");
    //    GameLogic.timer += 5;
    //    Destroy(gameObject);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit by rock.");
        if (collision.gameObject.tag == "Weapon_Rock")
        {
            Debug.Log("BRUH");
            GameLogic.timer += 5;
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoblinScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("BRUH");
        GameLogic.timer += 5;
        Destroy(gameObject);
    }
}

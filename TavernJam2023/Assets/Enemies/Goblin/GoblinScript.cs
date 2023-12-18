using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class GoblinScript : MonoBehaviour
{

    GameObject target;
    NavMeshAgent agent;
    public int health = 1;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Satyr");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameLogic.timer += 5;
            Destroy(this.gameObject);
        }
        agent.SetDestination(target.transform.position);
    }

    //private void OnMouseDown()
    //{
    //    Debug.Log("BRUH");
    //    GameLogic.timer += 5;
    //    Destroy(gameObject);
    //}
}

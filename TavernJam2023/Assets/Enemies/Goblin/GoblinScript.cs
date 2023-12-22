using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class GoblinScript : MonoBehaviour
{

    GameObject target;
    NavMeshAgent agent;
    Animator anim;
    public int health = 2;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Satyr");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Satyr") == true)
        {
            anim.SetTrigger("isAttacking");

        }
    }

    void DoDamage()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Satyr");
        PlayerController playerScript = player.GetComponent<PlayerController>();
        playerScript.health -= 1;
    }

    //private void OnMouseDown()
    //{
    //    Debug.Log("BRUH");
    //    GameLogic.timer += 5;
    //    Destroy(gameObject);
    //}
}

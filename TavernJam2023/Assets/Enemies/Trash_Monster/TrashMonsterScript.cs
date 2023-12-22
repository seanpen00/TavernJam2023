using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrashMonsterScript : MonoBehaviour
{
    GameObject target;
    NavMeshAgent agent;
    public int health = 10;
    Animator anim;
    private bool isDead = false;
    BoxCollider2D bc2d;
    GameObject playerTarget;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.Find("Satyr");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        bc2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !isDead)
        {
            isDead = true;
            agent.enabled = false;
            bc2d.enabled = false;
            anim.SetTrigger("isDead");
        }
        else if (!isDead)
        {
            agent.SetDestination(target.transform.position);
            FlipSpriteBasedOnTargetPosition();
        }
    }

    void FlipSpriteBasedOnTargetPosition()
    {
        if (target != null)
        {
            bool isTargetToRight = target.transform.position.x > transform.position.x;
            transform.localScale = isTargetToRight ? new Vector3(-8, 8, 8) : new Vector3(8, 8, 8);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Satyr") == true)
        {
            anim.SetTrigger("isAttacking");

        }
    }

    void Kill()
    {
        GameLogic.timer += 30;
        isDead = false;
        Destroy(gameObject);
    }

    void DoDamage()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Satyr");
        PlayerController playerScript = player.GetComponent<PlayerController>();
        playerScript.health -= 1;
    }
}

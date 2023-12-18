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

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.Find("Satyr");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !isDead)
        {
            isDead = true;
            agent.enabled = false;
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

    void Kill()
    {
        GameLogic.timer += 30;
        isDead = false;
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    // Start is called before the first frame update

    BoxCollider2D bc;
    SpriteRenderer sr;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goblin") == true)
        {
            Debug.Log("GOBLIN!");
            GoblinScript goblinScript = collision.gameObject.GetComponent<GoblinScript>();
            if (goblinScript != null)
            {
                goblinScript.health -= 1;
                Debug.Log("Goblin hit health: " + goblinScript.health);
            }
            bc.enabled = false;
            sr.enabled = false;
            
        }

        if (collision.gameObject.CompareTag("Trash_Monster") == true)
        {
            Debug.Log("TRASH MONSTER!");
            TrashMonsterScript trashMonsterScript = collision.gameObject.GetComponent<TrashMonsterScript>();
            Animator trashMonsterAnimator;
            if (trashMonsterScript != null && trashMonsterScript.health > 0)
            {
                trashMonsterAnimator = trashMonsterScript.GetComponent<Animator>();
                trashMonsterAnimator.SetTrigger("isHit");
                trashMonsterScript.health -= 1;

                Debug.Log("Trash monster hit health: " + trashMonsterScript.health);
                bc.enabled = false;
                sr.enabled = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMonsterHealthBar : MonoBehaviour
{

    int currentHealth;
    TrashMonsterScript trashMonsterScript;
    // Start is called before the first frame update
    void Start()
    {
        trashMonsterScript = GetComponentInParent<TrashMonsterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = trashMonsterScript.health;
        transform.localScale = new Vector3(.1f * currentHealth, 0.03f, 0.125f); 
    }
}

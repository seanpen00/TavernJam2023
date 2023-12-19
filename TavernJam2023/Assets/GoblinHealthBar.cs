using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinHealthBar : MonoBehaviour
{

    int currentHealth;
    GoblinScript goblinScript;
    // Start is called before the first frame update
    void Start()
    {
        goblinScript = GetComponentInParent<GoblinScript>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = goblinScript.health;
        transform.localScale = new Vector3(.5f * currentHealth, 0.03f, 0.125f); 
    }
}

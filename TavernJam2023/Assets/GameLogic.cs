using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour
{

    public static int timer = 100;

    [SerializeField] TextMeshProUGUI timerText;

    /* 
     Difficulty: Enemies can hurt you, you only have 3 hearts (3 hits), only bosses can drop hearts back
     */

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("reduceTimer");
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = "Time Remaining: " + timer;
    }

    IEnumerator reduceTimer()
    {
        while(true)
        {
            // execute block of code here
            timer -= 1;
            Debug.Log("timer");
            yield return new WaitForSeconds(1f);

        }
    }
}

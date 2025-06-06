using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passed : MonoBehaviour
{
    public LogicHandler logic;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audiosource = GetComponent<AudioSource>();
        logic = GameObject.Find("Logic Handler").GetComponent<LogicHandler>();
    }

    private void OnTriggerExit2D(Collider2D passage)
    {
        if(passage.gameObject.CompareTag("Player"))
        {
            logic.addScore();   
        }
    }
}

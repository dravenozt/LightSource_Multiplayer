using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_dialogue : MonoBehaviour
{   
    public DialogueArranger dialogueArranger;
    public GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        dialogueArranger.didHit= true;
        
        

    }
    private void OnCollisionExit(Collision other) {
        //dialogueArranger.didHitSquare=false;
    }
}
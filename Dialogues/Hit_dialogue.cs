using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_dialogue : MonoBehaviour
{   
    public DialogueArranger dialogueArranger;
    //public GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //gameobject tag kullanacan
        SetIndexByTag();
        dialogueArranger.didHit = true;



    }

    //hangi diyalogun açılacağına burda taga göre karar veriyosun
    //yani konuşmacalara tag atayıp burayı güncellemeyi unutma
    private void SetIndexByTag()
    {
        switch (gameObject.tag)
        {
            case "Store": dialogueArranger.dialogueIndex=1;break;
            case "Player":dialogueArranger.dialogueIndex=0;break;

            default:break;
        }
    }

    private void OnCollisionExit(Collision other) {
        //dialogueArranger.didHitSquare=false;
    }
}

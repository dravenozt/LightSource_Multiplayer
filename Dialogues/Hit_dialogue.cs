using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem;
using Mirror;

public class Hit_dialogue : MonoBehaviour
{   
    public DialogueArranger dialogueArranger;
    public GameObject player;
    [Tooltip("When this dialogue node is current node, it will give the quest")]
    public DialogueNode questNode;
    [Tooltip("Drag the quest object")]
    public GameObject quests;
    public QuestSO questToGive;
    public bool timeToGiveQuest=false;
    PlayerConversant playerConversant;
    
    private void Awake() {
        playerConversant=player.GetComponent<PlayerConversant>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!playerConversant.HasNext() && playerConversant.currentNode != null&&quests.GetComponent<Quests>().currentQuest == null)
        {
            Debug.Log("görev verme zamanı");
            timeToGiveQuest = true;
        }

        SetTheQuestSO();

        if (timeToGiveQuest&&quests.GetComponent<Quests>().currentQuest != null)
        {
            quests.GetComponent<Quests>().SetTheQuestProperties();
            timeToGiveQuest=false;
        }
    }

    private void SetTheQuestSO()
    {
        if (timeToGiveQuest && quests.GetComponent<Quests>().currentQuest == null)
        {
            Debug.Log("görev veriliyor");
            quests.GetComponent<Quests>().currentQuest = questToGive;
        }
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
            //case "Store": dialogueArranger.dialogueIndex=1;break;
            //case "Player":dialogueArranger.dialogueIndex=0;break;
            case "Guard": 
                Debug.Log("guarda tosladık");
                
                dialogueArranger.dialogueIndex=0;
                if (timeToGiveQuest)//player.GetComponent<PlayerConversant>().HasNext()
                {   
                    Debug.Log("Quest verildi");
                    quests.GetComponent<Quests>().currentQuest=questToGive;
                    
                }
                else
                {
                    Debug.Log("quest verilemedi bi hata var");
                }
            break;

            default:break;
        }
    }

    private void OnCollisionExit(Collision other) {
        //dialogueArranger.didHitSquare=false;
    }
}

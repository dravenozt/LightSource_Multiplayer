using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueUI;
using DialogueSystem;
using Mirror;


public class DialogueArranger : NetworkBehaviour
{   
    [HideInInspector]public PlayerConversant playerConversant;
    public GameObject player;
    [SerializeField] DialoguListSO dialogueList;
    //public GameObject square;
    [HideInInspector]public bool didHit= false;
    public GameObject dialoguePrefab;
    [HideInInspector]public bool isDialogueBubbleOpen= false;
    Dialogue dialogue;
    public int dialogueIndex;
    

    private void Awake() {
        playerConversant= player.GetComponent<PlayerConversant>();
    }
    public void SetDialogueIndex(int index)
    {   
            
        playerConversant.currentDialogue = dialogueList.allDialogues[index];
        playerConversant.currentNode = playerConversant.currentDialogue.GetRootNode();

            
    }

    private void Update()
    {   //burayı düzenlersin illa 1 olmayacak
        
        OpenDialogue(dialogueIndex);
        
        
    }

    
    

    
    private void OpenDialogue(int index)
    {
        if (didHit)
        {   
            if (!isDialogueBubbleOpen)
            {
                
                SetDialogueIndex(index);
            }
              
            
            
            
            dialoguePrefab.SetActive(didHit);
            dialoguePrefab.GetComponent<DialogueUI.DialogueUI>().UpdateUI();// oldu ama next tuşu çalışmıyo
            didHit = false;
            isDialogueBubbleOpen=true;
            
        }
    }
}

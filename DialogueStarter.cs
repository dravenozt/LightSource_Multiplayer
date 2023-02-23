using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueUI;
using DialogueSystem;
public class DialogueStarter : MonoBehaviour
{   
    private DialogueUI.DialogueUI dialogueUI = new DialogueUI.DialogueUI();
    public GameObject dialoguePrefab;
    public GameObject player;
    private PlayerConversant playerConversant;
    public DialoguListSO dialogueList;
    // Start is called before the first frame update
    void Start()
    {
        playerConversant= GetComponent<PlayerConversant>();
    }

    // Update is called once per frame
    void Update()
    {
        //dialoguePrefab.gameObject.SetActive(true);
    }
    public void SetDialogueIndex(int index)
        {   
            
            //playerConversant.currentDialogue = dialogueList.allDialogues[index];
            //playerConversant.currentNode = playerConversant.currentDialogue.GetRootNode();
            player.GetComponent<PlayerConversant>().currentDialogue=dialogueList.allDialogues[1];
            player.GetComponent<PlayerConversant>().currentNode= player.GetComponent<PlayerConversant>().currentDialogue.GetRootNode();

            
        }

    //deneme
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag=="Store")
        {   //dialoguePrefab.SetActive(true);
            
            
            //dialogueUI.SetDialogueIndex(1);
            //dialogueUI.UpdateUI();
            
            Debug.Log("aktif edildi");
            //dialogueUI.SetDialogueIndex(1);
        }
        //else
        //{
        //    Debug.Log("kod doğru çalışmıyor");
        //}
        
        //playerConversant.IsActive();
        //dialoguePrefab.SetActive(true);
        //dialogueUI.UpdateUI();
        
        
    }
}

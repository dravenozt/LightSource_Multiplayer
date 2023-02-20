using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem;
using TMPro;
using UnityEngine.UI;
using System.Linq;

namespace DialogueUI{
    public class DialogueUI : MonoBehaviour
{   
    PlayerConversant playerConversant;
    public GameObject player;
    [SerializeField] TextMeshProUGUI AIText;

    [SerializeField] Button nextButton;
    [SerializeField] Transform choiceRoot;
    [SerializeField] GameObject choiceButtonPrefab;
    [SerializeField] GameObject aiResponse;
    private DialogueNode currentNode;
    // Start is called before the first frame update
    void Start()
    {
        
        playerConversant= player.GetComponent<PlayerConversant>();
         
        //playerConversant.currentNode= playerConversant.currentDialogue.GetRootNode();// sonradan ekledik
        nextButton.onClick.AddListener(Next);
        
        UpdateUI();
    }

    void Next(){
        
        
        playerConversant.Next();
        UpdateUI();
        
    }

    
    void UpdateUI()
    {
        //AIText.text = playerConversant.GetText();
        //nextButton.gameObject.SetActive(playerConversant.HasNext());
        aiResponse.SetActive(!playerConversant.IsChoosing()); //
        choiceRoot.gameObject.SetActive(playerConversant.IsChoosing());// burası ischoosing true ise aktif ediyo full

        if (playerConversant.IsChoosing())// burası true çıkıyo full sıkıntı burda
        {

            //burda hiçbi sorun yok çalışıyo
            foreach (Transform item in choiceRoot)
            {
                Destroy(item.gameObject);
            }


            foreach (string choiceText in playerConversant.GetChoices())
            {
                GameObject choiceInstance= Instantiate(choiceButtonPrefab,choiceRoot);
                var textComp= choiceInstance.GetComponentInChildren<TextMeshProUGUI>();
                textComp.text= choiceText;
            }
        }



        else
        {
            AIText.text = playerConversant.GetText();
            nextButton.gameObject.SetActive(playerConversant.HasNext());
        }

        

    }
}
}

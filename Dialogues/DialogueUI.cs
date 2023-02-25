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
    [Tooltip("Drag Player GameObject")]
    public GameObject player;
    [Tooltip("Drag AI Text from Dialogue prefab in 'GamePlay UI Prefabs' folder")]
    [SerializeField] TextMeshProUGUI AIText;

    [Tooltip("Drag Next Button from Dialogue prefab in 'GamePlay UI Prefabs' folder")]
    [SerializeField] Button nextButton;
    [Tooltip("Drag Choices Gameobject")]
    [SerializeField] Transform choiceRoot;
    [Tooltip("Drag the Choice Button prefab from 'GamePlay UI Prefabs' folder")]
    [SerializeField] GameObject choiceButtonPrefab;
    [Tooltip("Drag AI Response from Dialogue prefab in 'GamePlay UI Prefabs' folder")]
    [SerializeField] GameObject aiResponse;
    [Tooltip("Drag Quit Button from Dialogue prefab in 'GamePlay UI Prefabs' folder")]
    [SerializeField] Button quitButton;
    [Tooltip("Drag Speaker Name from Dialogue prefab in 'GamePlay UI Prefabs' folder")]
    [SerializeField] GameObject speakerName;
    //deneme
    
    [Header("List of the dialogues")]
    [Tooltip("Drag your dialogue list scriptable object to adress dialogues from this script by using SetDialogueIndex function")]
    [SerializeField] DialoguListSO dialogueList;
    //deneme
    public DialogueArranger dialogueArranger;
    
    private DialogueNode currentNode;
    
  
    private void Awake() {
        playerConversant= player.GetComponent<PlayerConversant>();
        
        
        //iki dk commentte dursun
        //playerConversant.currentNode= playerConversant.currentDialogue.GetRootNode();
        playerConversant.isChoosing=false;
        
        
    }
    void Start()
        {
            //deneme
            SetDialogueIndex(0);
            

            //playerConversant.currentNode= playerConversant.currentDialogue.GetRootNode();// sonradan ekledik
            nextButton.onClick.AddListener(Next);
            quitButton.onClick.AddListener(() => Quit()
            );

           UpdateUI();
        }


    
        
        //pull dialogue from dialogue list scriptable object
        public void SetDialogueIndex(int index)
        {   
            
            playerConversant.currentDialogue = dialogueList.allDialogues[index];
            playerConversant.currentNode = playerConversant.currentDialogue.GetRootNode();

            
        }

        void Next()
        {


            playerConversant.Next();
            //deneme
            //SetSpeakerName();


            //deneme son
            UpdateUI();

        }

        //prints the name of speaker
        private void SetSpeakerName()
        {
            if (playerConversant.currentNode != null)
            {
                if (playerConversant.IsChoosing())
                {
                    speakerName.GetComponent<TextMeshProUGUI>().text = "You:";
                    
                }
                else
                {
                    speakerName.GetComponent<TextMeshProUGUI>().text = playerConversant.currentDialogue.conversantName + ":";
                    
                }

            }
        }

        public void UpdateUI()
    {
        //AIText.text = playerConversant.GetText();
        //nextButton.gameObject.SetActive(playerConversant.HasNext());
        gameObject.SetActive(playerConversant.IsActive());
        aiResponse.SetActive(!playerConversant.IsChoosing()); //
        SetSpeakerName();
        choiceRoot.gameObject.SetActive(playerConversant.IsChoosing());// burası ischoosing true ise aktif ediyo full

        if (playerConversant.IsChoosing())// burası true çıkıyo full sıkıntı burda
            {
                BrowseChoiceList();
            }



            else
        {
            AIText.text = playerConversant.GetText();
            nextButton.gameObject.SetActive(playerConversant.HasNext());
        }

        

    }

        private void BrowseChoiceList()
        {
            //burda hiçbi sorun yok çalışıyo
            foreach (Transform item in choiceRoot)
            {
                Destroy(item.gameObject);
            }


            foreach (DialogueNode choice in playerConversant.GetChoices())
            {
                GameObject choiceInstance = Instantiate(choiceButtonPrefab, choiceRoot);
                var textComp = choiceInstance.GetComponentInChildren<TextMeshProUGUI>();
                textComp.text = choice.GetText();
                Button button=choiceInstance.GetComponentInChildren<Button>();
                button.onClick.AddListener(()=>{
                    playerConversant.ChoiceSelection(choice);
                    UpdateUI();
                    // seçtikten sonra node'u bir daha ekrana yazdırmak istiyorsan aşağıyı kullanma
                    Next();
                });
            }
        }

        
        public void Quit(){
            playerConversant.currentDialogue= null;
            playerConversant.currentNode=null;
            playerConversant.isChoosing=false;
            dialogueArranger.didHit=false;//okey çalışıyo
            dialogueArranger.isDialogueBubbleOpen=false;
            //player.GetComponent<PlayerMovement>().isIndialogue=false;

            UpdateUI();
            

        }

    
    }

    
}

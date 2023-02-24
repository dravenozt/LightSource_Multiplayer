using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quests : MonoBehaviour
{   
    public GameObject questSheet;
    public QuestSO currentQuest;
    public GameObject questText;
    public GameObject questImage;
    private bool isSheetOpen= false;
    

    private void Awake() {
        currentQuest=null;
        
        
        //questImage=
        
    }
    private void Start() {
        SetQuestUI();
        //questText.GetComponent<TextMeshProUGUI>().text = "You have no quests";
    }
    private void Update()
    {
        
    }

    private void SetQuestUI()
    {
        if (currentQuest == null)
        {   
            Debug.Log("quest yok çalıştı");
            //gameObject.GetComponentInChildren<TextMeshProUGUI>().text="You have no quest";
            

        }
        else
        {
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = currentQuest.questDescription;
            questImage.GetComponent<Image>().sprite = currentQuest.image;
            questImage.GetComponent<Image>().color=Color.white;
           // GetComponentInChildren<Image>().color.CompareRGB(Color.white);

        }
    }


    public void OpenQuestWindow(){
        if (!isSheetOpen)
        {   isSheetOpen= true;
            questSheet.SetActive(true);
            
        }
        else
        {   isSheetOpen= false;
            questSheet.SetActive(false);
            
        }
    }
}

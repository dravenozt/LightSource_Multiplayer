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
    Hit_dialogue hit_Dialogue;
    

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
        //SetQuestUI();
    }

    //sürekli yazdırıyor ben bi kere yazdırması lazım
    private void SetQuestUI()
    {
        if (currentQuest == null)
        {   
            Debug.Log("görev yok çalıştı");
            //gameObject.GetComponentInChildren<TextMeshProUGUI>().text="You have no quest";
            //SetTheQuestProperties();
            

        }
        else 
        {
            SetTheQuestProperties();
            // GetComponentInChildren<Image>().color.CompareRGB(Color.white);

        }
    }

    public void SetTheQuestProperties()
    {
        questText.GetComponent<TextMeshProUGUI>().text = currentQuest.questDescription;
        if (questImage.GetComponent<Image>().sprite==null)
        {
            //questImage.GetComponent<Image>().color= new Color(129,84,71);

            //dikkatli ol image ı kapatıyosun
            questImage.SetActive(false);
        }
        questImage.GetComponent<Image>().sprite = currentQuest.image;
        questImage.GetComponent<Image>().color = Color.white;
        //hit_Dialogue.timeToGiveQuest=false;
        Debug.Log("görev yazdırılıyor");
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests : MonoBehaviour
{   
    public GameObject questSheet;
    private bool isSheetOpen= false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

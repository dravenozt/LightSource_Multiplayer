using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TriggerEvent : MonoBehaviour
{   
    
    public GameObject player;
    public GameObject self;
    //private bool isFirstTime; // prevents multiple light triggers

    //public int lightCount;
    public bool isFirstTime;
    
    private void Start() {
        isFirstTime=true;
        //lightCount=0;
        
    }

    private void Update() {
        
        
    }
    //ontrigger çalışıyor
    private void OnTriggerEnter2D(Collider2D other) {
        //player.GetComponentInChildren<Light2D>().pointLightOuterRadius=16f;

        
        
            
            
             
        
        
       
        
        //other.GetComponentInChildren<Light2D>().pointLightOuterRadius=1.84f;
        
    }
    


    
    


    
    //aşşa kısım çalışıyodu tek candle varken
    /*
    IEnumerator TurnOnTheLights(){
       Debug.Log("Corotine çalıştı");
       Debug.Log("Işıklar açıldı");
       
        //self.GetComponentInChildren<Light2D>().intensity=0f;
        player.GetComponentInChildren<Light2D>().pointLightOuterRadius=16f;
        yield return new WaitForSeconds(3f);
        player.GetComponentInChildren<Light2D>().pointLightOuterRadius=1.84f;
        Debug.Log("Işıklar kapanıyor");
        isFirstTime=false;
        

    }
    */
    
}

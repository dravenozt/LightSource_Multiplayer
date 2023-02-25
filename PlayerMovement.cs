using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Mirror;
using System;
using TMPro;




public class PlayerMovement : NetworkBehaviour
{
    public float movementSpeed= 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;
    public GameObject player;
    TriggerEvent triggerCandle;
    public int lightcount;
    [SyncVar(hook = nameof(CountGlowStick))]public int glowstickcount;
    public GameObject glowstick;
    [SyncVar]private float xpos;
    [SyncVar]private float ypos;
    [SyncVar]private float zpos;
    public GameObject candleSoundHolder;
    public GameObject footStepHolder;
    public Transform playerPosition;
    public TextMeshProUGUI glowstickText;
    [SyncVar]private bool isLightsOn=false;
    public bool isIndialogue=false;
    
    

    


    private void Start() {
        lightcount=10;
        
        glowstickcount=20;
        
        
        
    }


    

    
    // Update is called once per frame
    void Update()
    {   //aşadaki kodu çalıştırınca herkesi kontrol etme sorunu çözüldü
        //ama artık host oynayamıyor
        //client authority i kapatınca sorun çözüldü
        if(!isOwned){return;}//isowned hasauthority olabilir dikkat

        //glowstickcount -= 1;
        

        
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);



        xpos = player.transform.position.x;
        ypos = player.transform.position.y;
        zpos = player.transform.position.z;


        // access into glowstick count cs 
         FindObjectOfType<GlowStickCount>().gscount= glowstickcount; 


        FindObjectOfType<CandleCount>().candlecount = lightcount;

    

        
        
        
        


        if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.D))
        {
            footStepHolder.GetComponent<AudioSource>().enabled=true;
        }
        else
        {
            footStepHolder.GetComponent<AudioSource>().enabled=false;
        }





        FlipTheCharacterSprite();
        ActivateCandleLight();

        DropGlowStick();
        



        //Debug.Log(lightcount);

    }
    
    
        
    
    

    
    void FixedUpdate() {
        if (!isIndialogue)
        {
            rb.MovePosition(rb.position + movement*movementSpeed*Time.fixedDeltaTime);
        }
    }

    



    
    // candle ın üstüne geldik şimdi
    //Candle daki triggerevent scriptine gidiyoruz, ordaki isfirsttime boolu true ise lightcountımızı 1 arttırıyoruz, sonra ilk defa üstüne basamıyoruz bida
    private void OnTriggerEnter2D(Collider2D other) {
       
       if (other.GetComponent<TriggerEvent>().isFirstTime)
       {
            lightcount+=1;
            other.GetComponent<TriggerEvent>().isFirstTime=false;
            
       }
       
        
    }


    
    private void ActivateCandleLight()
    {
        if (Input.GetKeyDown(KeyCode.T)&&lightcount>0)
        {
            if (lightcount > 0)
            {
                BringLight();
                //StartCoroutine("COTurnOnTheLights");
            }

        }
    }
    
    [Command]
    public void BringLight()
    {
        lalala();

    }

    [ClientRpc]
    private void lalala()
    {
        StartCoroutine("COTurnOnTheLights");
    }

    
    private void TurnOnTheLights(){
        player.GetComponentInChildren<Light2D>().pointLightOuterRadius=16f;
    }

    
    private void TurnOffTheLights(){
        player.GetComponentInChildren<Light2D>().pointLightOuterRadius=1.84f;
    }


    
    IEnumerator COTurnOnTheLights(){
        //Debug.Log("Corotine çalıştı kaççççovvvvv");
        lightcount-=1;
        candleSoundHolder.GetComponent<AudioSource>().enabled=true;
        yield return new WaitForSeconds(1.2f);
        
        TurnOnTheLights();
        //player.GetComponentInChildren<Light2D>().pointLightOuterRadius=16f;
        yield return new WaitForSeconds(30f);
        TurnOffTheLights();
        //player.GetComponentInChildren<Light2D>().pointLightOuterRadius=1.84f;
        candleSoundHolder.GetComponent<AudioSource>().enabled=false;
    }


    //Turn The Character Sprites Right-Left
    private void FlipTheCharacterSprite()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CmdFlipLeft();

        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            CmdFlipRight();

        }
    }

    
    [Command]
    private void CmdFlipRight()
    {
        FlipRight();
    }

    [Command]
    private void CmdFlipLeft()
    {
        FlipLeft();
    }
    [ClientRpc]
    private void FlipRight()
    {
        transform.localScale = new Vector3(.5f, .5f, 1f);
    }

    [ClientRpc]
    private void FlipLeft()
    {
        transform.localScale = new Vector3(-.5f, .5f, 1f);
    }

    private void DropGlowStick()
    {
       
        if (Input.GetKeyDown(KeyCode.R)&&glowstickcount>0)
        { /*  
        xpos = player.transform.localPosition.x;
        ypos = player.transform.localPosition.y;
        zpos = player.transform.localPosition.z;*/
            
           // SpawnGlowStick();
          CmdSpawnGlowStick();
          

        }
        
    }





    [Command]
    private void CmdSpawnGlowStick(){
        GameObject networkGlowstick= Instantiate(glowstick,playerPosition.position,playerPosition.rotation);
        NetworkServer.Spawn(networkGlowstick);
        
        glowstickcount-=1;
        
        
        
        
    }

    
    private void CountGlowStick(int oldValue, int newValue){

        Debug.Log($"Sayı azaldı{glowstickcount}");
        
        //FindObjectOfType<GlowStickCount>().gscount= glowstickcount;
        
    }

    /*
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag=="Guard")
        {   
            isIndialogue=true;
        }
        
    }*/

    







}

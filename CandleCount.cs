using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CandleCount : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI candleText;
    public int candlecount;
    
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
       // candlecount=player.GetComponent<PlayerMovement>().lightcount;
        //candleText=GetComponent<TMP_Text>();
        candleText.text=candlecount.ToString();
    }
}

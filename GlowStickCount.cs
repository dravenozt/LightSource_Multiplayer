using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlowStickCount : MonoBehaviour
{
   public GameObject player;
    public TextMeshProUGUI glowstickText;
    public int gscount=40;
    
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        //gscount=player.GetComponent<PlayerMovement>().glowstickcount;
        //candleText=GetComponent<TMP_Text>();
        glowstickText.text=gscount.ToString();
    }
}

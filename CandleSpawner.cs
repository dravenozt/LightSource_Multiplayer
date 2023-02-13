using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleSpawner : MonoBehaviour
{   
    public GameObject candle;
    private float range;
    // Start is called before the first frame update
    void Start()
    {   
        
        //candle.transform.localPosition= new Vector3(15f,15f,3f);
        
        for (int i = 0; i < 100; i++)
        {
            Instantiate(candle);
            candle.transform.localPosition= new Vector3(Random.Range(-93f,613f),Random.Range(-666f,35f),3f);

        }
       // Instantiate(candle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MentalHealth : MonoBehaviour
{
    public Slider healthBarSlider;
    public int maxHealth;
    public float currentHealth;
    public float decreaseByTime;
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth=maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateHealth();



        //DecreaseMentalHealth();

    }

    private void CalculateHealth()
    {
        healthBarSlider.value = currentHealth;
        healthBarSlider.maxValue = maxHealth;
        decreaseByTime = (1f * Time.deltaTime) / 20f;
        currentHealth -= decreaseByTime;
    }


    /*
    private void DecreaseMentalHealth()
    {
        decreaseByTime = (1f * Time.deltaTime) / 20f;
        mentalHealth -= decreaseByTime;
    }*/

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem;
using TMPro;

namespace DialogueUI{
    public class DialogueUI : MonoBehaviour
{   
    PlayerConversant playerConversant;
    public GameObject player;
    [SerializeField] TextMeshProUGUI AIText;
    // Start is called before the first frame update
    void Start()
    {
        playerConversant= player.GetComponent<PlayerConversant>();
        AIText.text = playerConversant.GetText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}

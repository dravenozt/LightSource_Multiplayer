using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem{
    public class PlayerConversant : MonoBehaviour
{
    [SerializeField] Dialogue currentDialogue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetText(){
        if (currentDialogue==null)
        {
            return "";
        }

        return currentDialogue.GetRootNode().GetText();
    }
}
}

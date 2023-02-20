using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace DialogueSystem{
    public class PlayerConversant : MonoBehaviour
{
    [SerializeField] public Dialogue currentDialogue;
    public DialogueNode currentNode;
    public bool isChoosing;

    
    // Start is called before the first frame update
    // bura awake idi unutma
    private void Awake() {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsChoosing(){
       // isChoosing=currentNode.IsPlayerSpeaking(); // burayı sonradan ekledim çalıştı gibi
        // ama bir kere diyalğou geçtin mi hep current node son node oluyo onu düzeltmek lazım
        return isChoosing;
    }

    public IEnumerable<string> GetChoices(){
        yield return "haha";
        yield return "zortttt";

    }

    public string GetText(){
        if (currentDialogue==null)
        {
            return "";
        }
        
        //currentNode= currentDialogue.GetRootNode();
        //hocam bu kod gayet çalışıyodu ya
       // return currentDialogue.GetRootNode().GetText(); 
        return currentNode.GetText();
    }
    // bu burda çalışmıyodu dialogue ui a taşıdım
    public void Next(){
        
        int numPlayerResponses =currentDialogue.GetPlayerChildren(currentNode).Count();
        if ( numPlayerResponses>0)// burayı değiştirdim and den sonrasını sil buranın true ya da false olması hiçbi şey değiştirmiyo

        {
            isChoosing= true;
            return;
        }
       
        DialogueNode[] children = currentDialogue.GetAIChilden(currentNode).ToArray();
        int randomIndex = Random.Range(0,children.Count());
    
        currentNode= children[0];
        
        //DialogueNode[] children = currentDialogue.GetAllChilden(currentNode).ToArray();
    
        //currentNode= children[0];
    }


    public bool HasNext(){
        
        return currentDialogue.GetAIChilden(currentNode).Count()> 0;
    }
}
}

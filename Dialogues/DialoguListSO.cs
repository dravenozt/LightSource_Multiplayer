using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem;


[CreateAssetMenu(fileName = "New Dialogue Holder(List)", menuName = "Dialogue System/Dialogue List", order = 1)]
public class DialoguListSO : ScriptableObject
{
    public List<Dialogue> allDialogues = new List<Dialogue>();
}

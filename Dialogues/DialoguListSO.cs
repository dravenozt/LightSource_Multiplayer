using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem;


[CreateAssetMenu(fileName = "New Dialogue Holder(List)", menuName = "Dialogue System/Dialogue List", order = 1)]
public class DialoguListSO : ScriptableObject
{
    [Header("List of all dialogues in game")]
    [Tooltip("A holder to adress dialogues")]
    public List<Dialogue> allDialogues = new List<Dialogue>();
}

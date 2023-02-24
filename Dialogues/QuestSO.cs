using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest/New Quest")]
public class QuestSO : ScriptableObject
{
    public string questDescription;
    public Sprite image;

}

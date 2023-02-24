using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Quest", menuName = "Quest/New Quest List")]
public class QuestListSO : ScriptableObject
{
    public List<QuestSO> questList = new List<QuestSO>();
}

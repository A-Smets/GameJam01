using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "ScriptableObjects/Trap Table")]
public class TrapTable : SerializedScriptableObject
{
    [DictionaryDrawerSettings(KeyLabel = "Trap", ValueLabel = "Was Sprung ?")] public Dictionary<Trap, bool> Traps = new Dictionary<Trap, bool>();
}

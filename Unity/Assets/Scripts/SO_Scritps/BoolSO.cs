using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "ScriptableObjects/BoolSO")]
public class BoolSO : ScriptableObject
{
    protected bool _variable;
    [ShowInInspector]
    public bool Value
    {
        get { return _variable; }
        set { _variable = value; }
    }
}

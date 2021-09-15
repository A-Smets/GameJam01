using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

/// <summary>
/// Used to clamp the Value of a FloatSO
/// </summary>
public enum E_ClampingMethod
{
    None,
    Constant,
    ValueSO
}

/// <summary>
/// Used to compare layers in collisions
/// </summary>
public enum E_LayerCompare
{
    //Numerical values must match layer's index
    Player = 6,
    Enemy = 7,
    Neutral = 8,
    Environment = 9,
    Trap =10
}

/// <summary>
/// Used to compare tags in collisions
/// </summary>
public enum E_TagCompare
{
    //Strings must match tag's name
    Entity,
    Trigger,
    TrapProper
}

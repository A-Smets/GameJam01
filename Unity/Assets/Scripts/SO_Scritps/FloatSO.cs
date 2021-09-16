using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/FloatSO")]
public class FloatSO : ScriptableObject
{
    [SerializeField, HorizontalGroup("Bools")] protected bool constantValue = false;
    [SerializeField, HorizontalGroup("Bools", Width = .55f), ShowIf("@!constantValue"), EnumPaging, LabelWidth(75)] protected E_ClampingMethod clamping;

    [InfoBox("Min must be strictly lower than Max", InfoMessageType = InfoMessageType.Error, VisibleIf = "@minSO && maxSO && minSO.Value >= maxSO.Value")]
    [SerializeField, ShowIf("@!constantValue && clamping == E_ClampingMethod.ValueSO"), LabelText("Min")] protected FloatSO minSO;
    [SerializeField, ShowIf("@!constantValue && clamping == E_ClampingMethod.ValueSO"), LabelText("Max")] protected FloatSO maxSO;
    [InfoBox("Min must be strictly lower than Max", InfoMessageType = InfoMessageType.Error, VisibleIf = "@minConst >= maxConst")]
    [SerializeField, ShowIf("@!constantValue && clamping == E_ClampingMethod.Constant"), LabelText("Min")] protected float minConst = 0;
    [SerializeField, ShowIf("@!constantValue && clamping == E_ClampingMethod.Constant"), LabelText("Max")] protected float maxConst = 1;

    [SerializeField, ShowIf("@constantValue")] protected float constant;
    protected float _variable;
    [ShowInInspector, ShowIf("@!constantValue")]
    public float Value
    {
        get
        {
            return constantValue ? constant : _variable;
        }
        set
        {
            switch (clamping)
            {
                case E_ClampingMethod.None:
                    _variable = value;
                    break;

                case E_ClampingMethod.Constant:
                    _variable = Mathf.Clamp(value, minConst, maxConst);
                    break;

                case E_ClampingMethod.ValueSO:
                    if (minSO && maxSO)
                    {
                        _variable = Mathf.Clamp(value, minSO.Value, maxSO.Value);
                    }
                    else
                    {
                        throw new System.Exception("Couldn't set " + name + "'s Value : no range referenced.");
                    }
                    break;

                default:
                    break;
            }
        }
    }

    /// <summary>
    /// Returns the minimal value of the ValueSO, 0 if there is none
    /// </summary>
    public float MinValue
    {
        get
        {
            switch (clamping)
            {
                case E_ClampingMethod.Constant:
                    return minConst;

                case E_ClampingMethod.ValueSO:
                    return minSO ? minSO.Value : 0;

                default:
                    return 0;
            }
        }
    }

    /// <summary>
    /// Returns the maximal value of the ValueSO, 0 if there is none
    /// </summary>
    public float MaxValue
    {
        get
        {
            switch (clamping)
            {
                case E_ClampingMethod.Constant:
                    return maxConst;

                case E_ClampingMethod.ValueSO:
                    return maxSO ? maxSO.Value : 0;

                default:
                    return 0;
            }
        }
    }

    /// <summary>
    /// Returns the normalized value of the ValueSO, 0 if there is none
    /// </summary>
    public float NormalizedValue
    {
        get
        {
            switch (clamping)
            {
                case E_ClampingMethod.Constant:
                    return maxConst != 0 ? Value / maxConst : 0;

                case E_ClampingMethod.ValueSO:
                    return maxSO ? (maxSO.Value != 0 ? Value / maxSO.Value : 0) : 0;

                default:
                    return 0;
            }
        }
    }

    [Button, PropertySpace(5)] protected void ResetAsset()
    {
        constantValue = false;
        clamping = E_ClampingMethod.None;
        minSO = null;
        maxSO = null;
        minConst = 0;
        maxConst = 1;
        constant = 0;
        _variable = 0;
    }
}
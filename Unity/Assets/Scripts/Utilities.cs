using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    /// <summary>
    /// Returns a randomised bool
    /// </summary>
    public static bool RandomBool(float probability = .5f)
    {
        return Random.value > Mathf.Clamp01(probability);
    }

    /// <summary>
    /// Randomly inverts the input
    /// </summary>
    public static float RandomInverse(float input, float probability = .5f)
    {
        return input * (RandomBool(probability) ? 1 : -1);
    }

    /// <summary>
    /// Returns true every duration
    /// </summary>
    public static bool Timer(ref float timer, float duration, bool resetTimer = true, float timeFactor = 1f)
    {
        timer += Time.deltaTime * timeFactor;
        if (timer > duration)
        {
            timer = resetTimer ? 0f : timer;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Returns whetever the given value is contained within the given bounds
    /// </summary>
    public static bool IsInside(float value, float min, float max)
    {
        return value >= min && value <= max;
    }

    /// <summary>
    /// Returns whetever the given value is contained within the given bounds
    /// </summary>
    public static bool IsInside(float value, Vector2 minMax)
    {
        float min = Mathf.Min(minMax.x, minMax.y);
        float max = Mathf.Max(minMax.x, minMax.y);
        return IsInside(value, min, max);
    }

    /// <summary>
    /// Returns whetever the given positions are within the given range of each other
    /// </summary>
    public static bool IsInRange(Vector3 pos1, Vector3 pos2, float range)
    {
        return Vector3.Distance(pos1, pos2) < range;
    }

    /// <summary>
    /// Remaps the given value to the given new bounds
    /// </summary>
    public static float Remap(float value, float minOld, float maxOld, float minNew, float maxNew)
    {
        return (value - minOld) / (maxOld - minOld) * (maxNew - minNew) + minNew;
    }

    /// <summary>
    /// Converts string into a compare enum
    /// </summary>
    /// <param name="tagString">Tag of the hit gameObject</param>
    /// <param name="convertedTag">Tag converted into an E_TagCompare if compatible (default : 0)</param>
    /// <returns>True if the tag was compatible</returns>
    public static bool ConvertToTag(string tagString, out E_TagCompare convertedTag)
    {
        bool defined = System.Enum.IsDefined(typeof(E_TagCompare), tagString);
        convertedTag = defined ? (E_TagCompare)System.Enum.Parse(typeof(E_TagCompare), tagString) : 0;
        return defined;
    }

    #region IsOnLayer
    /// <summary>
    /// Checks if a GameObject is on a specific layer (given by index number)
    /// </summary>
    public static bool IsOnLayer(GameObject obj, int targetLayer)
    {
        return obj.layer == targetLayer;
    }

    /// <summary>
    /// Checks if a GameObject is on a specific layer (given by layer name)
    /// </summary>
    public static bool IsOnLayer(GameObject obj, string targetLayer)
    {
        return IsOnLayer(obj, LayerMask.NameToLayer(targetLayer));
    }
    #endregion

    #region GetLayerMask
    /// <summary>
    /// Returns a mask for the given layer (excluded by default)
    /// </summary>
    public static int GetLayerMask(int layerIndex, bool invert = true)
    {
        int bitMask = 1 << layerIndex;
        return invert ? ~bitMask : bitMask;
    }

    /// <summary>
    /// Returns a mask for the given layer (excluded by default)
    /// </summary>
    public static int GetLayerMask(string layerName, bool invert = true)
    {
        return GetLayerMask(LayerMask.NameToLayer(layerName), invert);
    }
    #endregion

    #region CheckCollision
    /// <summary>
    /// Checks if the given GameObject is on the given layer 
    /// </summary>
    public static bool CheckCollision(GameObject other, int layer)
    {
        return IsOnLayer(other, layer);
    }

    /// <summary>
    /// Checks if the given GameObject is on the given layer and has the given tag
    /// </summary>
    public static bool CheckCollision(GameObject other, int layer, string tag)
    {
        return CheckCollision(other, layer) && other.CompareTag(tag);
    }

    /// <summary>
    /// Checks if the given GameObject is on the given layer and has the given tag
    /// </summary>
    public static bool CheckCollision(GameObject other, int layer, E_TagCompare tag)
    {
        return CheckCollision(other, layer, tag.ToString());
    }

    /// <summary>
    /// Checks if the given GameObject is on the given layer and outs the GameObject's tag as compare enum
    /// </summary>
    public static bool CheckCollision(GameObject other, int layer, out E_TagCompare tag)
    {
        ConvertToTag(other.tag, out tag);
        return IsOnLayer(other, layer);
    }

    /// <summary>
    /// Checks if the given GameObject is on the given layer 
    /// </summary>
    public static bool CheckCollision(GameObject other, string layer)
    {
        return CheckCollision(other, LayerMask.NameToLayer(layer));
    }

    /// <summary>
    /// Checks if the given GameObject is on the given layer and has the given tag
    /// </summary>
    public static bool CheckCollision(GameObject other, string layer, string tag)
    {
        return CheckCollision(other, LayerMask.NameToLayer(layer), tag);
    }

    /// <summary>
    /// Checks if the given GameObject is on the given layer and has the given tag
    /// </summary>
    public static bool CheckCollision(GameObject other, string layer, E_TagCompare tag)
    {
        return IsOnLayer(other, layer) && other.CompareTag(tag.ToString());
    }

    /// <summary>
    /// Checks if the given GameObject is on the given layer and outs the GameObject's tag as compare enum
    /// </summary>
    public static bool CheckCollision(GameObject other, string layer, out E_TagCompare tag)
    {
        ConvertToTag(other.tag, out tag);
        return IsOnLayer(other, layer);
    }
    #endregion
}

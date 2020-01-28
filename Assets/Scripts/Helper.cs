
using UnityEngine;

public static partial class Helper
{
    public static Color RandomColor()
    {
        return new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f)); 
    }


    public static Vector3 RandomVector3 (Rect bounds)
    {
        return new Vector3(Random.Range(bounds.xMin, bounds.xMax), Random.Range(bounds.yMin, bounds.yMax)); 
    }

    public static bool RandomBool()
    {
        return Random.Range(0, 1) == 1; 
    }
}


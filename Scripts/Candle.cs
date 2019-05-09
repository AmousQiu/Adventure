using UnityEngine;

public class Candle : MonoBehaviour
{
    public Transform stick, wick;
    private static float stickHeight, wickHeight;
    void OnEnable()
    {
        Vector3 scale = stick.localScale;
        scale.y = stickHeight;
        stick.localScale = scale;

        scale = wick.localScale;
        scale.y = wickHeight;
        wick.localScale = scale;
    }
    public static void setStickHeight(float height)
    {
        stickHeight = height;
    }
    public static void setWickHeight(float height)
    {
        wickHeight = height;
    }
}


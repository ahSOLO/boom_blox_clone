using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpers
{
    public static float NormalizeAngle(float a)
    {
        if (a > 180f) return a - 360f;
        else if (a < -180f) return a + 360f;
        return a;
    }
}

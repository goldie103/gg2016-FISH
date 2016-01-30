using UnityEngine;
using System.Collections;

public class SaturationEventManager : MonoBehaviour {

    public delegate void SaturationChange(int score);

    public static event SaturationChange Saturate;
    public static event SaturationChange DeSaturate;

    public static void OnDeSaturate(int score)
    {
        if (DeSaturate != null)
        {
            DeSaturate(score);
        }
    }

    public static void OnSaturate(int score)
    {
        if (Saturate != null)
        {
            Saturate(score);
        }
    }
}

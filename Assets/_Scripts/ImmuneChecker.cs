using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmuneChecker : MonoBehaviour {

    public static bool p1Immune;
    public static bool p2Immune;
    public static bool p3Immune;

    private void Start()
    {
        p1Immune = false;
        p2Immune = false;
        p3Immune = false;
    }
}

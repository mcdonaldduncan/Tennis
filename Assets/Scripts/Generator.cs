using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Generator : MonoBehaviour
{
    float farZ = 23.77f;
    float farX = 10.97f;
    float innerOffset = 1.37f;
    Vector3 centreMarkLength = new Vector3(0, 0, .1f);
    Vector3 netOffset = new Vector3(.914f, 0, 0);

    void Update()
    {
        // Baseline and doubles sidelines
        Debug.DrawLine(EasyVector(0, 0), EasyVector(0, farZ));
        Debug.DrawLine(EasyVector(farX, 0), EasyVector(farX, farZ));
        Debug.DrawLine(EasyVector(0, 0), EasyVector(farX, 0));
        Debug.DrawLine(EasyVector(0, farZ), EasyVector(farX, farZ));

        // Centre Marks
        Debug.DrawLine(CalculateMidPoint(EasyVector(0, 0), EasyVector(farX, 0)), CalculateMidPoint(EasyVector(0, 0), EasyVector(farX, 0)) + centreMarkLength);
        Debug.DrawLine(CalculateMidPoint(EasyVector(0, farZ), EasyVector(farX, farZ)), CalculateMidPoint(EasyVector(0, farZ), EasyVector(farX, farZ)) - centreMarkLength);

        // Singles sidelines
        Debug.DrawLine(EasyVector(innerOffset, 0), EasyVector(innerOffset, farZ));
        Debug.DrawLine(EasyVector(farX - innerOffset, 0), EasyVector(farX - innerOffset, farZ));

        // Net
        Debug.DrawLine(CalculateMidPoint(EasyVector(0, 0), EasyVector(0, farZ)) - netOffset, CalculateMidPoint(EasyVector(farX, 0), EasyVector(farX, farZ)) + netOffset);

        // Servicelines
        Debug.DrawLine(CalculateMidPoint(CalculateMidPoint(EasyVector(innerOffset, 0), EasyVector(innerOffset, farZ)), EasyVector(innerOffset, farZ)), CalculateMidPoint(CalculateMidPoint(EasyVector(farX - innerOffset, 0), EasyVector(farX - innerOffset, farZ)), EasyVector(farX - innerOffset, farZ)));
        Debug.DrawLine(CalculateMidPoint(CalculateMidPoint(EasyVector(innerOffset, 0), EasyVector(innerOffset, farZ)), EasyVector(innerOffset, 0)), CalculateMidPoint(CalculateMidPoint(EasyVector(farX - innerOffset, 0), EasyVector(farX - innerOffset, farZ)), EasyVector(farX - innerOffset, 0)));

        // Centre serviceline
        Debug.DrawLine(CalculateMidPoint(CalculateMidPoint(CalculateMidPoint(EasyVector(innerOffset, 0), EasyVector(innerOffset, farZ)), EasyVector(innerOffset, farZ)), CalculateMidPoint(CalculateMidPoint(EasyVector(farX - innerOffset, 0), EasyVector(farX - innerOffset, farZ)), EasyVector(farX - innerOffset, farZ))), CalculateMidPoint(CalculateMidPoint(CalculateMidPoint(EasyVector(innerOffset, 0), EasyVector(innerOffset, farZ)), EasyVector(innerOffset, 0)), CalculateMidPoint(CalculateMidPoint(EasyVector(farX - innerOffset, 0), EasyVector(farX - innerOffset, farZ)), EasyVector(farX - innerOffset, 0))));
    }

    // I didnt want to write new 50 times
    Vector3 EasyVector(float x, float z)
    {
        return new Vector3(x, 0, z);
    }

    // Midpoint
    Vector3 CalculateMidPoint(Vector3 v1, Vector3 v2)
    {
        float calcX = (v1.x + v2.x) / 2;
        float calcZ = (v1.z + v2.z) / 2;

        return new Vector3(calcX, 0, calcZ);
    }


    // going to work on a recursive method, this was what I came up with off the top, doesnt work yet, haven't tested
    Vector3 CalculateMidPointRecursively(Vector3 v1, Vector3 v2, int iterations)
    {
        if (iterations == 0)
            return CalculateMidPoint(v1, v2);
        float calcX = (v1.x + v2.x) / 2;
        float calcZ = (v1.z + v2.z) / 2;
        return CalculateMidPointRecursively(EasyVector(calcX, calcZ), v2, --iterations);
    }
}

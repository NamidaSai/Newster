using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CredibilityManager : MonoBehaviour
{
    float credibilityScore = 50f;

    public void ModifyCredibility(float amount)
    {
        credibilityScore += amount;
    }
}

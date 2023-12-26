using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapons : MonoBehaviour
{
    public GameObject weaponPrefab;
    public int lowestDamage;
    public int highestDamage;
    private int _averageDamage;

    private void Awake()
    {
        _averageDamage = Mathf.FloorToInt((highestDamage + lowestDamage) / 2);
    }

    public int CalculateDamage(float velecoity)
    {
        if (velecoity == 3.0f)
        {
            int lowDamage = Random.Range(lowestDamage, _averageDamage);
            return lowDamage;
        }

        if (velecoity == 4.0f)
        {
            int midDamage = Random.Range(_averageDamage, highestDamage);
            return midDamage;
        }

        if (velecoity >= 5.0f) return highestDamage;
        return 0;
    }
}

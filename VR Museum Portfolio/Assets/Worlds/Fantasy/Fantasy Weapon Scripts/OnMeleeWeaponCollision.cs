using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(InputData))]
public class OnMeleeWeaponCollision : MonoBehaviour
{
    public new GameObject gameObject;
    private HealthSystem healthBar;
    private InputData inputData;
    private MeleeWeaponSystem meleeWeaponSystem;

    private void Start()
    {
        healthBar = gameObject.GetComponent<HealthSystem>();
        inputData = GetComponent<InputData>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GetParent(other);
        string otherTag = other.tag;

        switch (otherTag)
        {
            case "Blade":
                WeaponPartHit(meleeWeaponSystem.bladeDamage); 
                break;
            case "Guard":
                WeaponPartHit(meleeWeaponSystem.guardDamage);
                break;
            case "Hilt":
                WeaponPartHit(meleeWeaponSystem.hiltDamage);
                break;
        }
    }

    private void WeaponPartHit(int damage) 
    {

            if (inputData.leftController.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 leftVelocity))
            {
                if (leftVelocity.magnitude > 3.0f)
                {
                    healthBar.UpdateHealth(damage, "damage");
                }
                else
                {
                    Debug.Log("Hit harder");
                }
            }

            if (inputData.rightController.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 rightVelocity))
            {
                if (rightVelocity.magnitude > 3.0f)
                {
                    healthBar.UpdateHealth(damage, "damage");
                }
                else
                {
                    Debug.Log("Hit harder");
                }
            }
    }

    private void GetParent(Collider other)
    {
        Transform childTransform = other.transform;

        if (childTransform != null)
        {
            // Get the parent of the child
            Transform parentTransform = childTransform.parent;

            // Check if the parentTransform is not null
            if (parentTransform != null)
            {
                meleeWeaponSystem = parentTransform.GetComponent<MeleeWeaponSystem>();
            }
            else
            {
                Debug.Log("No parent found.");
            }
        }
        }
    
}

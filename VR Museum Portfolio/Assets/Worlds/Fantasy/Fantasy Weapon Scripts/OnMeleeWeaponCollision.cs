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
    private MeleeWeaponSystem meleeWeapon;

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
                WeaponPartHit(meleeWeapon.bladeDamage, "blade"); 
                break;
            case "Guard":
                WeaponPartHit(meleeWeapon.guardDamage, "guard");
                break;
            case "Hilt":
                WeaponPartHit(meleeWeapon.hiltDamage, "hilt");
                break;
        }
    }

    private void WeaponPartHit(int damage, string weaponPart) 
    {
        InputDevice leftControllertData = inputData.leftController;
        InputDevice rightControllertData = inputData.rightController;

        if (leftControllertData.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 leftVelocity))
        {
            if (leftVelocity.magnitude > 3.0f)
            {
                healthBar.UpdateHealth(damage, "damage");
            }
            else
            {
                Debug.Log(String.Format("You need to swing you {0} harder", weaponPart));
            }
        }

        if (rightControllertData.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 rightVelocity))
        {
            if (rightVelocity.magnitude > 3.0f)
            {
                healthBar.UpdateHealth(damage, "damage");
            }
            else
            {
                Debug.Log(String.Format("You need to swing you {0} harder", weaponPart));
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
                meleeWeapon = parentTransform.GetComponent<MeleeWeaponSystem>();
            }
            else
            {
                Debug.Log("No parent found.");
            }
        }
        }
    
}

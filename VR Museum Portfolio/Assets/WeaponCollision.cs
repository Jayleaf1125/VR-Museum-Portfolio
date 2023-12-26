using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


[RequireComponent(typeof(InputData))]
public class WeaponCollision : MonoBehaviour
{
    private HealthSystem healthBar;
    private InputData inputData;
    private MeleeWeapons meleeSys;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<HealthSystem>();
        inputData = GetComponent<InputData>();
        meleeSys = GetComponent<MeleeWeapons>();
    }

    private void OnTriggerEnter(Collider other)
    {
        OnWeaponHit();
    }

    private void OnWeaponHit()
    {
        InputDevice leftControllerData = inputData.leftController, rightControllerData = inputData.rightController;

        if (leftControllerData.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 leftVelocity))
        {
            float leftMagnitude = Mathf.Floor(leftVelocity.magnitude);
            int weaponDamage = meleeSys.CalculateDamage(leftMagnitude);

            healthBar.UpdateHealth(weaponDamage, "damage");
            Debug.Log(System.String.Format("{0} damage", weaponDamage));
        }

        if (rightControllerData.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 rightVelocity))
        {
            float rightMagnitude = Mathf.Floor(rightVelocity.magnitude);
            int weaponDamage = meleeSys.CalculateDamage(rightMagnitude);

            healthBar.UpdateHealth(weaponDamage, "damage");
            Debug.Log(System.String.Format("{0} damage", weaponDamage));
        }
    }
}

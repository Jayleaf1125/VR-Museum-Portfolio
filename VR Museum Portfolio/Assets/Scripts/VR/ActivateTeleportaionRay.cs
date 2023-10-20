using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportaionRay : MonoBehaviour
{
    public GameObject leftTeleportation;
    public GameObject rightTeleportation;
    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;

    // Update is called once per frame
    void Update()
    {
        bool isLeftTriggerPressed = leftActivate.action.ReadValue<float>() > 0.1f;
        bool isRightTriggerPressed = rightActivate.action.ReadValue<float>() > 0.1f;

        leftTeleportation.SetActive(isLeftTriggerPressed);
        rightTeleportation.SetActive(isRightTriggerPressed);
    }
}

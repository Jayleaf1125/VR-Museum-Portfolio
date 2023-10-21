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

    public InputActionProperty leftCancel;
    public InputActionProperty rightCancel;

    // Update is called once per frame
    void Update()
    {
        bool isLeftTriggerPressed =  leftActivate.action.ReadValue<float>() > 0.1f;
        bool isRightTriggerPressed = rightActivate.action.ReadValue<float>() > 0.1f;

        // Debug.Log(string.Format("Left Grip: {0}", leftCancel.action.ReadValue<float>()));
        // Debug.Log(string.Format("Right Grip: {0}", rightCancel.action.ReadValue<float>()));

        bool isLeftTriggerCanceled = leftCancel.action.ReadValue<float>() < 0.1f;
        bool isRightTriggerCanceled = rightCancel.action.ReadValue<float>() < 0.1f;

        leftTeleportation.SetActive(isLeftTriggerCanceled && isLeftTriggerPressed);
        rightTeleportation.SetActive(isRightTriggerCanceled && isRightTriggerPressed);
    }
}

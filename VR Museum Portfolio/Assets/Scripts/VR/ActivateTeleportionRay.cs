using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateTeleportaionRay : MonoBehaviour
{
    public GameObject leftTeleportationRay;
    public GameObject rightTeleportationRay;

    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;

    public InputActionProperty leftCancel;
    public InputActionProperty rightCancel;

    public XRRayInteractor leftGrabRay;
    public XRRayInteractor rightGrabRay;

    // Update is called once per frame
    void Update()
    {
        bool isLeftTriggerPressed =  leftActivate.action.ReadValue<float>() > 0.1f;
        bool isRightTriggerPressed = rightActivate.action.ReadValue<float>() > 0.1f;

        // Debug.Log(string.Format("Left Grip: {0}", leftCancel.action.ReadValue<float>()));
        // Debug.Log(string.Format("Right Grip: {0}", rightCancel.action.ReadValue<float>()));

        bool isLeftTriggerCanceled = leftCancel.action.ReadValue<float>() < 0.1f;
        bool isRightTriggerCanceled = rightCancel.action.ReadValue<float>() < 0.1f;

        bool isLeftGrabRayHovering = leftGrabRay.TryGetHitInfo(out Vector3 leftPosition, out Vector3 leftNormal, out int leftNumber, out bool leftValid);
        bool isRightGrabRayHovering = rightGrabRay.TryGetHitInfo(out Vector3 rightPosition, out Vector3 rightNormal, out int rightNumber, out bool rightValid);

        leftTeleportationRay.SetActive(!isLeftGrabRayHovering && isLeftTriggerCanceled && isLeftTriggerPressed);
        rightTeleportationRay.SetActive(!isRightGrabRayHovering && isRightTriggerCanceled && isRightTriggerPressed);

    }
}

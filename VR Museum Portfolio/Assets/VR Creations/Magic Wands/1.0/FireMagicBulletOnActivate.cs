using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class FireMagicBulletOnActivate : MonoBehaviour
{
    public GameObject magic;
    public Transform spawnPoint;
    public float fireSpeed = 20.0f;
    public InputActionProperty leftTriggerAction;
    public InputActionProperty rightTriggerAction;
    public InputActionProperty leftGripAction;
    public InputActionProperty rightGripAction;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbale = GetComponent<XRGrabInteractable>();
        grabbale.activated.AddListener(FireMagic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    void ListenForActivateMagic(ActivateEventArgs arg)
    {
        float leftTriggerValue = leftTriggerAction.action.ReadValue<float>();
        float leftGripValue = leftGripAction.action.ReadValue<float>();
        float rightTriggerValue = rightTriggerAction.action.ReadValue<float>();
        float rightGripValue= rightGripAction.action.ReadValue<float>();


        if (leftTriggerValue > 0.1f || rightTriggerValue > 0.1f)
        {

        }

    }
    */

    public void FireMagic(ActivateEventArgs arg)
    {
        GameObject spawnedMagic = Instantiate(magic);
        spawnedMagic.transform.position = spawnPoint.position;
        spawnedMagic.GetComponent<Rigidbody>().velocity = spawnPoint.up * fireSpeed;
        Destroy(spawnedMagic, 3);
    }
}

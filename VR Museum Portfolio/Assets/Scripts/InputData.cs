using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

// Credit to FistFullOfShrimp -> (https://fistfullofshrimp.com/unity-vr-controller-data/)
public class InputData : MonoBehaviour
{
    public InputDevice rightController;
    public InputDevice leftController;
    public InputDevice HMD;

    private void InitializeInputDevices()
    {
        if(!rightController.isValid)
        {
            InitializeInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, ref rightController);
        }

        if (!leftController.isValid)
        {
            InitializeInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, ref leftController);
        }

        if (!HMD.isValid)
        {
            InitializeInputDevice(InputDeviceCharacteristics.HeadMounted, ref HMD);
        }
    }

    private void InitializeInputDevice(InputDeviceCharacteristics inputCharacteristics, ref InputDevice inputDevice)
    {
        List<InputDevice> devices = new List<InputDevice>();
        // Call InputDeivces to see if it can any devices with the characterstics we're looking for
        InputDevices.GetDevicesWithCharacteristics(inputCharacteristics, devices);

        // Our hands might not be active and so they will not be generated from the search
        // We check if any devices are found here to avoid errors
        if(devices.Count > 0 )
        {
            inputDevice = devices[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!rightController.isValid || !leftController.isValid || !HMD.isValid)
        {
            InitializeInputDevices();
        }
    }
}

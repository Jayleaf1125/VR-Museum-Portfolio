using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRRayGrabInteractor : XRGrabInteractable
{
    private Vector3 initialLocalPosition;
    private Quaternion initialLocalRotation;

    // Start is called before the first frame update
    void Start()
    {
        if(!attachTransform)
        {
            GameObject attachPoint = new GameObject("Offset Grab Ray Pivot");
            attachPoint.transform.SetParent(transform, false);
            attachTransform = attachPoint.transform;
        } else
        {
            initialLocalPosition = attachTransform.localPosition;
            initialLocalRotation = attachTransform.localRotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactorObject is XRDirectInteractor)
        {
            attachTransform.position = args.interactorObject.transform.position;
            attachTransform.rotation= args.interactorObject.transform.rotation;
        }
        else
        {
            attachTransform.localPosition = initialLocalPosition;
            attachTransform.rotation = initialLocalRotation;    
        }


        base.OnSelectEntered(args);
    }
}

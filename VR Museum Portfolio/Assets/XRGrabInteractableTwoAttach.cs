using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractableTwoAttach : XRGrabInteractable
{
    public Transform leftAttachTransform;
    public Transform rightAttachTransform;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactorObject.transform.CompareTag("LeftController"))
        {
            attachTransform = leftAttachTransform;
        } else if (args.interactorObject.transform.CompareTag("RightController"))
        {
            attachTransform = rightAttachTransform;
        }

        base.OnSelectEntered(args);
    }
}

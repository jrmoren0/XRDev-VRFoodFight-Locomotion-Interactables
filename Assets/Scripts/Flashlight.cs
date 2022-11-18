using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Flashlight : XRGrabInteractable
{
    [SerializeField] GameObject spotlight;

    protected override void OnActivated(ActivateEventArgs args)
    {
        base.OnActivated(args);

        if (spotlight.activeSelf)
        {
            spotlight.SetActive(false);
        }
        else
        {
            spotlight.SetActive(true);
        }
    }
}

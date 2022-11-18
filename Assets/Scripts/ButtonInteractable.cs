using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonInteractable : XRSimpleInteractable
{

    [SerializeField] private Transform buttonUp, buttonDown;

    [SerializeField] private Transform button;
    void Start()
    {
        button.position = button.position;
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        button.position = buttonDown.position;
        Debug.Log("wooooow");
    }
    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        button.position = buttonUp.position;
    }
}

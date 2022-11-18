using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PaintBrushGrabInteractable : XRGrabInteractable
{
    [SerializeField] private GameObject paintPrefab;

    [SerializeField] private Transform paintTip;

    [SerializeField] private PaintPicker tip;

    private GameObject tempPaint;
        protected override void OnActivated(ActivateEventArgs args)
    {
        base.OnActivated(args);
        tempPaint = Instantiate(paintPrefab, paintTip.position, paintTip.rotation);
        tempPaint.transform.SetParent(paintTip);

        if(tip.currentMaterial != null)
        {
            tempPaint.GetComponent<TrailRenderer>().material = tip.currentMaterial;
        }

        
    }

    protected override void OnDeactivated(DeactivateEventArgs args)
    {
        base.OnDeactivated(args);
        
        if(tempPaint != null)
        {
            tempPaint.transform.SetParent(null);
            tempPaint = null;
        }
    }
}

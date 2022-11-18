using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class FadeTeleportProvider : TeleportationProvider
{

    [SerializeField] private RawImage fadeImage;

    [SerializeField] private float timerValue;

    private float timer = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }


    public override bool QueueTeleportRequest(TeleportRequest teleportRequest)
    {
        StartCoroutine(FadeInAndStartRequest(teleportRequest));

        return true;
    }


    IEnumerator FadeInAndStartRequest(TeleportRequest teleportRequest)
    {
        timer = 0;

        while(timer <= 1)
        {
            fadeImage.color = Color.Lerp(Color.clear, Color.black, timer);
            timer += timerValue;
            yield return new WaitForEndOfFrame();

        }

        fadeImage.color = Color.black;

        currentRequest = teleportRequest;

        validRequest = true;
        
    }


    IEnumerator FadeOutAndEndRequest()
    {
        timer = 0;

        while (timer <= 1)
        {
            fadeImage.color = Color.Lerp(Color.black, Color.clear, timer);
            timer += timerValue;
            yield return new WaitForEndOfFrame();

        }

        fadeImage.color = Color.clear;

        EndLocomotion();
        validRequest = false;

     

    }


    // Update is called once per frame
    void Update()
    {
        if (!validRequest || !BeginLocomotion())
            return;

        var xrOrigin = system.xrOrigin;
        if (xrOrigin != null)
        {
            switch (currentRequest.matchOrientation)
            {
                case MatchOrientation.WorldSpaceUp:
                    xrOrigin.MatchOriginUp(Vector3.up);
                    break;
                case MatchOrientation.TargetUp:
                    xrOrigin.MatchOriginUp(currentRequest.destinationRotation * Vector3.up);
                    break;
                case MatchOrientation.TargetUpAndForward:
                    xrOrigin.MatchOriginUpCameraForward(currentRequest.destinationRotation * Vector3.up, currentRequest.destinationRotation * Vector3.forward);
                    break;
                case MatchOrientation.None:
                    // Change nothing. Maintain current origin rotation.
                    break;
                default:
                    Assert.IsTrue(false, $"Unhandled {nameof(MatchOrientation)}={currentRequest.matchOrientation}.");
                    break;
            }

            var heightAdjustment = xrOrigin.Origin.transform.up * xrOrigin.CameraInOriginSpaceHeight;

            var cameraDestination = currentRequest.destinationPosition + heightAdjustment;

            xrOrigin.MoveCameraToWorldLocation(cameraDestination);
        }

        StartCoroutine(FadeOutAndEndRequest());
    }
}

using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Settings : MonoBehaviour
{

    public GameObject Camera;

    private TrackedPoseDriver CameraTracker;
    
    public GameObject LeftRayInterractor;
    public GameObject RightRayInterractor;
    public GameObject LeftDirectInterractor;
    public GameObject RightDirectInterractor;
    public GameObject LeftDisabled;
    public GameObject RightDisabled;

    public GameObject TeleportationAnchors;

    public bool freeMove;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CameraTracker = Camera.GetComponent<TrackedPoseDriver>();
        enableFreeMove(); // security check that scene if correctly configured
    }

    public void enableFreeMove()
    {
        // TODO: change this?
        //CameraTracker.trackingType = TrackedPoseDriver.TrackingType.RotationAndPosition;
        freeMove = true;
        
        RightRayInterractor.SetActive(false);
        RightDisabled.SetActive(true);
        TeleportationAnchors.SetActive(false);
    }

    public void enableTeleporation()
    {
        // TODO: change this?
        //CameraTracker.trackingType = TrackedPoseDriver.TrackingType.RotationOnly;
        freeMove = false;
        
        RightDisabled.SetActive(false);
        RightRayInterractor.SetActive(true);
        TeleportationAnchors.SetActive(true);
    }
}
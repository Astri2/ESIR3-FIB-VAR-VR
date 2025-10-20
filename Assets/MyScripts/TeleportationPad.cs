using System;
using Unity.XR.CoreUtils;
using UnityEngine;

public class TeleportationPad : MonoBehaviour
{
    public XROrigin XROrigin;
    public Transform MainCamera;

    public Material baseMaterial;
    public Material hoverMaterial;
    
    private Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        if(renderer == null) Debug.Log($"Could not get renderer. ({this.name})");
        renderer.material = baseMaterial;
    }

    public void TeleportHere()
    {
        Debug.Log("Passe");
        Vector3 target = new Vector3(this.transform.position.x, MainCamera.position.y, this.transform.position.z);
        XROrigin.MoveCameraToWorldLocation(target);
    }

    public void HoverEnter()
    {
        renderer.material = hoverMaterial;
    }
    
    public void HoverExit()
    {
        renderer.material = baseMaterial;
    }
    
}

using System;
using System.Collections;
using Unity.XR.CoreUtils;
using UnityEngine;

public class TeleportationPad : MonoBehaviour
{
    public XROrigin XROrigin;
    public Transform MainCamera;

    public Material baseMaterial;
    public Material hoverMaterial;
    
    private Renderer renderer;
    public AudioSource TpSound;
    public float TPDelay;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        if(renderer == null) Debug.Log($"Could not get renderer. ({this.name})");
        renderer.material = baseMaterial;
    }

    public void TeleportHere()
    {
        TpSound.Play();
        Vector3 target = new Vector3(this.transform.position.x, MainCamera.position.y, this.transform.position.z);
        StartCoroutine(TeleportAfter(TPDelay, target));
    }

    public void HoverEnter()
    {
        renderer.material = hoverMaterial;
    }
    
    public void HoverExit()
    {
        renderer.material = baseMaterial;
    }

    private IEnumerator TeleportAfter(float time, Vector3 target)
    {
        yield return new WaitForSeconds(time);
        XROrigin.MoveCameraToWorldLocation(target);

    }
    
}

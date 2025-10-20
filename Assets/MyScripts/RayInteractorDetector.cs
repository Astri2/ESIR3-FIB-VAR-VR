using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class RayInteractorDetector : MonoBehaviour
{
    private XRRayInteractor rayInteractor;
    public Renderer objectRenderer;
    private Material originalMaterial;
    private Material highlightMaterial;

    [Header("Highlight Settings")]
    public Color highlightColor;
    
    void Awake()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
        
        // Store the original material
        originalMaterial = objectRenderer.material;

        // Create a copy of the material so we don’t modify the shared one
        highlightMaterial = new Material(originalMaterial);
        highlightMaterial.color = highlightColor;
    }

    void OnEnable()
    {
        rayInteractor.hoverEntered.AddListener(OnHoverEnter);
        rayInteractor.hoverExited.AddListener(OnHoverExit);
    }

    void OnDisable()
    {
        rayInteractor.hoverEntered.RemoveListener(OnHoverEnter);
        rayInteractor.hoverExited.RemoveListener(OnHoverExit);
    }

    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        //Debug.Log($"Ray Interactor touched: {args.interactableObject.transform.name}");
        objectRenderer.material = highlightMaterial;
    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        // Debug.Log($"Ray Interactor left: {args.interactableObject.transform.name}");
        objectRenderer.material = originalMaterial;
    }
}


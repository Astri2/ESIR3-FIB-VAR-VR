using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class DirectInteractorDetector : MonoBehaviour
{
    private XRDirectInteractor directInteractor;
    public Renderer objectRenderer;
    private Material originalMaterial;
    private Material highlightMaterial;

    [Header("Highlight Settings")]
    public Color highlightColor;

    private int CurrentHeldObjectLayer;

    void Awake()
    {
        directInteractor = GetComponent<XRDirectInteractor>();
        
        // Store the original material
        originalMaterial = objectRenderer.material;

        // Create a copy of the material so we don’t modify the shared one
        highlightMaterial = new Material(originalMaterial);
        highlightMaterial.color = highlightColor;
    }

    void OnEnable()
    {
        directInteractor.hoverEntered.AddListener(OnHoverEnter);
        directInteractor.hoverExited.AddListener(OnHoverExit);
        
        directInteractor.selectEntered.AddListener(OnSelectEntered);
        directInteractor.selectExited.AddListener(OnSelectExited);
    }

    void OnDisable()
    {
        directInteractor.hoverEntered.RemoveListener(OnHoverEnter);
        directInteractor.hoverExited.RemoveListener(OnHoverExit);
        
        directInteractor.selectEntered.RemoveListener(OnSelectEntered);
        directInteractor.selectExited.RemoveListener(OnSelectExited);
    }

    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        // Debug.Log($"Direct Interactor touched: {args.interactableObject.transform.name}");
        objectRenderer.material = highlightMaterial;
    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        // Debug.Log($"Direct Interactor left: {args.interactableObject.transform.name}");
        objectRenderer.material = originalMaterial;
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Debug.Log($"Direct Interactor grabbed: {args.interactableObject.transform.name}");
        // args.interactableObject.transform.GetComponent<Collider>().enabled = false;
        this.CurrentHeldObjectLayer = args.interactableObject.transform.gameObject.layer;
        args.interactableObject.transform.gameObject.layer = LayerMask.NameToLayer("DirectGrabbed");
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        // Debug.Log($"Direct Interactor dropped: {args.interactableObject.transform.name}");
        // args.interactableObject.transform.GetComponent<Collider>().enabled = true;
        args.interactableObject.transform.gameObject.layer = this.CurrentHeldObjectLayer;
    }
    
}


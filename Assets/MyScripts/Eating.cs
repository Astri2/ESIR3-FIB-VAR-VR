using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Eating : MonoBehaviour
{
    public Transform MainCamera;
    public InputActionReference MainButtonAction;
    public XRDirectInteractor leftHand;
    public double dist;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MainButtonAction.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (MainButtonAction.action.enabled)
        {
            if (MainButtonAction.action.WasPressedThisFrame())
            {
                //Debug.Log("Bouton pressé");
                if (leftHand.interactablesSelected.Count > 0)
                {
                    var interactable = leftHand.interactablesSelected[0].transform;
                    if (interactable != null && interactable.gameObject.CompareTag("Cookie") && Vector3.Distance(interactable.position, MainCamera.position) < dist)
                    {
                        Destroy(interactable.gameObject);
                    }
                    
                }
            }
        }
        else
        {
            Debug.LogWarning("Action non activée !");
        }

        
    }
}

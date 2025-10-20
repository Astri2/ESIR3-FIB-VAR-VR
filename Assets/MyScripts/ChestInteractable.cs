using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ChestInteractable : MonoBehaviour
{
    public GameObject chestLock;
    public GameObject grabbable;
    public GameObject cookies;
    public GameObject bottomLodColliders;

    void Start()
    {
        bottomLodColliders.SetActive(false);
        grabbable.SetActive(false);
        GetComponent<Glow>().enabled = false;
        cookies.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    { 
        if(!chestLock.activeSelf) {
            bottomLodColliders.SetActive(true);
            grabbable.SetActive(true);
            GetComponent <Glow>().enabled = true;
            cookies.SetActive(true);
        }
    }
}

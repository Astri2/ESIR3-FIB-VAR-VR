using System.Net;
using UnityEngine;

public class HeadCollider : MonoBehaviour
{
    private BoxCollider myCollider;

    // Script made with the help of Kieran
    public Transform head;
    public Transform floor;
    public float floorHeight;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myCollider = this.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the size of the collider to match head height
        Vector3 colliderSize = myCollider.size;
        colliderSize.y = (head.position.y - floor.position.y) * 0.95f; // add a small gap to prevent clipping with ground 
        myCollider.size = colliderSize; 
        
        // center the collider on the player (no rotation)
        Vector3 colliderPos = head.position; 
        colliderPos.y = head.position.y - colliderSize.y/2.0f + colliderSize.y * (1-0.95f)/2.0f; // gap should only on ground
        transform.position = colliderPos;
    }
}

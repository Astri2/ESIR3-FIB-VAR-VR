using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.GraphicsBuffer;

public class Locomotion : MonoBehaviour
{
    public float acceleration = 5f;  // how quickly it speeds up
    public float maxSpeed = 4f;       // top speed
    public float drag = 8f;           // how fast it slows down when no input
    
    public Transform JoystickReferenceTransform; // main camera
    
    private Vector3 velocity;
    private Rigidbody rigidBody;

    public Settings settings;
    
    public InputActionReference leftJoystickAction;
    public InputActionReference rightJoystickAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rigidBody = GetComponent<Rigidbody>();
        if(rigidBody == null) { Debug.Log("Could not find Rigidbody component of {this->name}"); }
        
        leftJoystickAction.action.Enable();
        rightJoystickAction.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // Allow the user to move up and down to reach items on the floor.
        Vector2 rightJoystickOrientation = rightJoystickAction.action.ReadValue<Vector2>();
        Vector3 yMotion = JoystickReferenceTransform.position + new Vector3(0, rightJoystickOrientation.y * 0.3f * Time.deltaTime, 0);
        yMotion.y = Mathf.Clamp(yMotion.y, 0, 2);
        this.GetComponent<XROrigin>().MoveCameraToWorldLocation(yMotion);

        // Allow the user to use left stick to move
        if (settings.freeMove)
        {
            Vector2 joystickOrientation = leftJoystickAction.action.ReadValue<Vector2>();


            // remove y components to avoid flying :D
            Vector3 forward = JoystickReferenceTransform.forward; forward.y = 0; forward.Normalize();
            Vector3 right = JoystickReferenceTransform.right; right.y = 0; right.Normalize();
            Vector3 inputDir =
                joystickOrientation.y * forward +
                joystickOrientation.x * right;

            /*
            Vector3 inputDir =
                joystickOrientation.y * JoystickReferenceTransform.forward +
                joystickOrientation.x * JoystickReferenceTransform.right;
            inputDir.y = 0;
            */

            // normalize but apply magnitude back to get a trade off between normalized and non normalized
            float magnitude = Mathf.Clamp01(inputDir.magnitude);
            Vector3 targetVelocity = inputDir.normalized * (magnitude * maxSpeed);
        
            // Accelerate toward target velocity
            rigidBody.linearVelocity = Vector3.MoveTowards(rigidBody.linearVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);
        
            // Apply air drag when no input
            if (inputDir.magnitude == 0)
            {
                rigidBody.linearVelocity = Vector3.Lerp(rigidBody.linearVelocity, Vector3.zero, drag * Time.fixedDeltaTime);
            }

            // remove any y velocity
            Vector3 vel = rigidBody.linearVelocity;
            vel.y = 0.0f;
            rigidBody.linearVelocity = vel;

        } else
        {
            // in teleportation mode, node velocity allowed
            rigidBody.linearVelocity = Vector3.zero;
        }
    }
}

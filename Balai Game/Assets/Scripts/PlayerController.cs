using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    [Header("References")]
    Rigidbody rb;
    CapsuleCollider cc;
    Ray isGrounded;
    RaycastHit floor;
    public Joystick cameraInput;
	public Joystick movementInput;
	public bool useTouchControls; // Determines whether the player is using touch controls or a keyboard and mouse.
	
    [Header("Camera control")]
    public Camera playerCamera;
    [Range(0, 180)]
    public float fieldOfView = 60;
    public GameObject head;
    [Tooltip("Camera control sensitivity for the X axis i.e. rotating left and right. Set to minus to invert it.")]
    [Range(-100, 100)]
    public float sensitivityX = 50;
    [Tooltip("Camera control sensitivity for the Y axis i.e. looking up and down. Set to minus to invert it.")]
    [Range(-100, 100)]
    public float sensitivityY = 50;

    //[HideInInspector] public float cameraSensitivityModifier;

    [Range(-90, 90)]
    public float minLookAngle = -90;
    [Range(-90, 90)]
    public float maxLookAngle = 90;

    Vector2 lookVector;

    [Header("Standard Movement")]
    [Tooltip("The player's standard movement speed.")]
    public float movementSpeed = 10;
    Vector2 moveInput;
    Vector3 movementValue;

    #region Validate variables
    #if UNITY_EDITOR
    void Reset() { OnValidate(); }
    void OnValidate()
    {

        minLookAngle = Mathf.Clamp(minLookAngle, -90, maxLookAngle);
        maxLookAngle = Mathf.Clamp(maxLookAngle, minLookAngle, 90);
    }
    #endif
    #endregion
	
	/*
    bool IsGrounded()
    {
        isGrounded.origin = transform.position; // Sets the origin of isGrounded ray to the player's body
        isGrounded.direction = Vector3.down; // Sets isGrounded direction to cast directly down under the player's 'feet'
        if (Physics.SphereCast(isGrounded, cc.radius, cc.height / 2 + 0.01f)) //Raycast isGrounded is cast to detect if there is a surface underneath the player. If so, canJump boolean is enabled to allow the player to jump off the surface, and disabled if false, i.e. if the player is in midair.
        {
            return true;
        }
        return false;
    }
	*/
	
    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ToggleInputMethod"))
        {
            useTouchControls = !useTouchControls;
        }
        
        // Enable/disable touch controls based on whether the player is using them or not
        if (cameraInput != null)
		{
			cameraInput.gameObject.SetActive(useTouchControls);
		}
		if (movementInput != null)
		{
			movementInput.gameObject.SetActive(useTouchControls);
		}
		
		#region Camera
        // Move camera based on input from mouse or touch controls, depending on which are enabled.
		if (useTouchControls == true)
		{
			LookAngle(new Vector2(cameraInput.Direction.x * sensitivityX * Time.deltaTime, cameraInput.Direction.y * sensitivityY * Time.deltaTime));
		}
		else
		{
			LookAngle(new Vector2(Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime, Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime));
		}

		
        
        #endregion
		
        #region Movement
		
        // Obtains movement input from keyboard or touch controls, depending on which one the player has selected.
		if (useTouchControls == true)
		{
			moveInput = movementInput.Direction;
		}
		else
		{
			moveInput.x = Input.GetAxis("Horizontal"); // Set to AD keys or analog stick.
            moveInput.y = Input.GetAxis("Vertical"); // Set to WS keys or analog stick.
		}
		
        // Normalises input if above a magnitude of 1, to prevent the player from moving extremely fast in a diagonal direction if inputs from two different axes are applied simultaneously.
        if (moveInput.magnitude > 1)
        {
            moveInput.Normalize();
        }
		//print(moveInput);
        movementValue = new Vector3(moveInput.x * movementSpeed, 0, moveInput.y * movementSpeed); // X and Y values of Vector2 moveInput are set as X and Z values of Vector3 movementValue, turning horizontal and vertical values into horizontal and lateral ones.
        //print(movementValue);
		movementValue = transform.rotation * movementValue; // movementValue is multiplied by transform.rotation so moveInput occurs in the direction the character is facing.
        #endregion
    }

    public void LookAngle(Vector2 cameraInput) // This variable is public so it can be altered by other sources such as gun recoil
    {
        // Input variables are placed into a separate Vector2, as the player's horizontal rotation can be directly added or subtracted, but their vertical rotation must be set directly to a value. So lookVector.y has to consist of the player's current vertical look angle minus any new Y input given.
        lookVector.x = cameraInput.x;
        lookVector.y -= cameraInput.y;
        lookVector.y = Mathf.Clamp(lookVector.y, minLookAngle, maxLookAngle); // Camera.y is then clamped to ensure it does not move past 90* or 90*, ensuring that the player does not flip the camera over completely.
        transform.Rotate(0, lookVector.x, 0); // Player is rotated on y axis based on Camera.x, for turning left and right
        head.transform.localRotation = Quaternion.Euler(lookVector.y, 0, 0); // Player head is rotated in x axis based on Camera.y, for looking up and down
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + movementValue * Time.fixedDeltaTime); // The rigidbody is moved based on movementValue.

        rb.AddForce(Physics.gravity * rb.mass); // Gravity is applied to the player, otherwise they fall too slowly.
    }
}
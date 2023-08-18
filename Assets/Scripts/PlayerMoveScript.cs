using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMoveScript : MonoBehaviour
{
    //other
    public Rigidbody rb;
    public Transform orientation;
    private float moveSpeed = 900f;
    private float multiplier;
    private float multiplierV;
    public Camera camera;
    
    
    //look
    private Vector2 mouseInput;
    private float mouseSensitivity = 2f;
    
    //player bools
    private float x, y;
    private bool jump, crouching;

    //physics
    public bool grounded;

    //crouch
    private Vector3 crouchScale = new Vector3(1, 0.5f, 1);
    private Vector3 playerScale;

    public float jumpAmount = 3f;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = gameObject.GetComponent<Rigidbody>();
        playerScale = transform.localScale;
    }

    public void FixedUpdate()
    {
        multiplier = grounded ? 1f : .5f;
        multiplierV = multiplier;
        Debug.Log(multiplier);
        CheckInput();
        Movement();
    }

    public void Update()
    {
        Debug.LogWarning(grounded);
    }

    private void CheckInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        jump = Input.GetKey(KeyCode.Space);
        crouching = Input.GetKey(KeyCode.LeftControl);

        //look variables
        mouseInput.x = Input.GetAxis("Mouse X");
        mouseInput.y = Input.GetAxis("Mouse Y");
        
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            StartCrouch();
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            StopCrouch();
        }
    }

    private void StartCrouch()
    {
        transform.localScale = crouchScale;
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
    }

    private void StopCrouch()
    {
        transform.localScale = playerScale;
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
    }

    private void Movement()
    {
        if (jump && grounded)
        {
            Debug.Log("Jump");
            rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
        }

        float mouseX = mouseInput.x * mouseSensitivity;
        float mouseY = mouseInput.y * mouseSensitivity;
        
        transform.Rotate(Vector3.left * mouseY);
        camera.transform.Rotate(Vector3.up * mouseX);
        
        rb.AddForce(orientation.transform.forward * y * moveSpeed * Time.deltaTime * multiplier * multiplierV);
        rb.AddForce(orientation.transform.right * x * moveSpeed * Time.deltaTime * multiplier);
        
    }
    

    private void OnCollisionStay(Collision collision)
    {
        //check if collider is the ground layer
        // if true then grounded`
        tag = gameObject.tag;
        if (tag.Equals("Player") && collision.collider.tag.Equals("Ground"))
        {
            grounded = true;
            return;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        String tag = gameObject.tag;

        if (tag.Equals("Player") && collision.collider.tag.Equals("Ground"))
        {
            grounded = false;
        }
    }
}
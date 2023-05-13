using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    float horizontalInput;
    float verticalInput;

    bool isGrounded;
    public float GroundDrag;
    public LayerMask groundMask;

    public float speed;
    public float jumpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        isGrounded = Physics.Raycast(transform.position,Vector3.down,1.2f,groundMask);

        if(isGrounded)
            rb.drag = GroundDrag;
        else
            rb.drag = 0;

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.AddForce(transform.up * jumpSpeed,ForceMode.Impulse);
    }

    private void FixedUpdate() 
    {
        Vector3 direction = transform.right * horizontalInput + transform.forward*verticalInput;
        if(isGrounded)
            rb.AddForce(direction.normalized * speed);
    }
}

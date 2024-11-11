using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkingSpeed, runningSpeed, jumpforce, sphereRadius, gravityScale;
    public string groundName;

    public Vector3 movementVector;

    private Rigidbody rb;

    private float x, z, mouseX;
    private bool jumpPressed, shiftPressed;

    public float currentSpeed;

    public float Yvelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Conseguir el imput del movimiento horizontal y vertical
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        shiftPressed = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumpPressed = true;
        }

        if (shiftPressed)
        {
            currentSpeed = runningSpeed;
        }
        else
        {
            currentSpeed = walkingSpeed;
        }

        ////Mover al jugador
        //Vector3 movement = new Vector3(x, 0f, z) * walkingSpeed * Time.deltaTime;
        //transform.Translate(movement, Space.Self);
        if (IsGrounded())
        {
            Yvelocity = 0f;
        }
        else
        {
            Yvelocity -= gravityScale * Time.deltaTime;
        }

    }
    private void FixedUpdate()
    {
        ApplySpeed();

        ApplyJumpForce();
    }

    void ApplySpeed()
    {
       
        movementVector = (transform.forward * currentSpeed * z) + (transform.right * currentSpeed * x) + new Vector3(0, rb.velocity.y + Yvelocity, 0);
        rb.velocity = movementVector;


    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    void ApplyJumpForce()
    {
        if (jumpPressed)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * jumpforce);
            jumpPressed = false;
        }
    }

    private bool IsGrounded()
    {
        Collider[] colliders = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), sphereRadius);
        
        for(int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.layer == LayerMask.NameToLayer(groundName))
            {
                return true;
            }
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), sphereRadius);
    }
}

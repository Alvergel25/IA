using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables públicas para controlar la velocidad, fuerza de salto, gravedad y detección de suelo.
    public float walkingSpeed = 20f;   // Velocidad al caminar, configurable desde el Inspector
    public float runningSpeed = 40f;   // Velocidad al correr, configurable desde el Inspector
    public float jumpforce = 500f;     // Fuerza de salto, configurable desde el Inspector
    public float sphereRadius = 1f;    // Radio para detección de suelo, configurable desde el Inspector
    public float gravityScale = 9.8f;  // Escala de gravedad personalizada, configurable desde el Inspector
    public string groundName = "Ground"; // Nombre de la capa del suelo para detección de colisiones

    // Variables para almacenar el vector de movimiento y la velocidad actual
    public Vector3 movementVector;     // Vector que representa el movimiento del jugador
    public float currentSpeed;         // Velocidad actual del jugador (caminar o correr)
    public float Yvelocity;            // Velocidad vertical controlada por gravedad y saltos

    // Variables privadas para manejo de componentes e inputs
    private Rigidbody rb;              // Referencia al componente Rigidbody del jugador
    private float x, z, mouseX;        // Variables de input de movimiento y rotación
    private bool jumpPressed, shiftPressed; // Variables de control de salto y velocidad

    void Start()
    {
        // Obtenemos el componente Rigidbody al iniciar el script
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
        // Cambiar entre velocidad de caminar y correr
        if (shiftPressed)
        {
            currentSpeed = runningSpeed;
        }
        else
        {
            currentSpeed = walkingSpeed;
        }

        // Aplicar gravedad personalizada si el jugador no está en el suelo
        if (IsGrounded())
        {
            Yvelocity = 0f; // Reinicia la velocidad vertical si está en el suelo
        }
        else
        {
            Yvelocity -= gravityScale * Time.deltaTime; // Aplica gravedad personalizada
        }

    }
    private void FixedUpdate()
    {
        // Aplicar movimiento y salto en FixedUpdate para manejar física
        ApplySpeed();

        ApplyJumpForce();
    }
    
    // Función para aplicar la velocidad en la dirección del movimiento
    void ApplySpeed()
    {
        // Calcular el vector de movimiento basado en la dirección y velocidad actual
        movementVector = (transform.forward * currentSpeed * z) + (transform.right * currentSpeed * x) + new Vector3(0, rb.velocity.y + Yvelocity, 0);
        rb.velocity = movementVector; // Aplicar el movimiento al Rigidbody
    }

    // Método para obtener la velocidad actual del jugador desde otros scripts
    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    // Función para aplicar la fuerza de salto
    void ApplyJumpForce()
    {
        if (jumpPressed)
        {
            // Reiniciar la velocidad vertical y aplicar fuerza de salto
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * jumpforce);// Aplicar fuerza de salto como impulso
            jumpPressed = false; // Reiniciar la variable de salto
        }
    }

    // Función para comprobar si el jugador está en el suelo
    private bool IsGrounded()
    {
        // Usamos un OverlapSphere para detectar colisiones dentro del radio en la capa de suelo
        Collider[] colliders = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), sphereRadius);
        
        for(int i = 0; i < colliders.Length; i++)
        {
            // Verificamos si algún collider pertenece a la capa de suelo
            if (colliders[i].gameObject.layer == LayerMask.NameToLayer(groundName))
            {
                return true;
            }
        }

        return false; // Si no detecta suelo, retorna false
    }

    // Dibujar el radio de detección de suelo en el editor para visualizar la zona de colisión
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), sphereRadius);
    }
}

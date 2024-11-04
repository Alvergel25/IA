using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    //Velocidad de la camara
    public float lookSensitivity = 1;
    //public float rotateMax, rotateMin;
    public Transform target, player;
    //Inputs del mouse
    float mouseX, mouseY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        ControlCamera();
    }

    void ControlCamera()
    {
        mouseX += Input.GetAxis("Mouse X") * lookSensitivity;
        mouseY += Input.GetAxis("Mouse Y") * lookSensitivity;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(target);

        //Rotar al jugador
        player.rotation = Quaternion.Euler(0, mouseX, 0);
        //Rotar camara
        target.rotation = Quaternion.Euler(-mouseY, mouseX, 0);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform posTP; //Posicion de Camara en Tercera Persona

    public float rotSpeed; //Controlar la rotacion de la camara
    public float rotMin, rotMax; //Asignar limites en el eje Y
    float mouseX, mouseY;
    public Transform target, player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Cam()
    {
        mouseX += rotSpeed * Input.GetAxis("Mouse X"); //Le asignamos el valor X del mouse a la variable mouseX
        mouseY += rotSpeed * Input.GetAxis("Mouse Y"); //Le asignamos el valor X del mouse a la variable mouseX
        mouseY = Mathf.Clamp(mouseY, rotMin, rotMax); //Asignarle los limites a la Y con los valores que asignemos a rtoMin y rotMax

        target.rotation = Quaternion.Euler(mouseY, mouseX, 0.0f);//Para que la camara gire alrededor de los ejes de nuestro target, el z lleva 0 porque no lo necesitamos
        player.rotation = Quaternion.Euler(0.0f, mouseX, 0.0f);//Para que la camara gire alrededor de los ejes de nuestro target

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

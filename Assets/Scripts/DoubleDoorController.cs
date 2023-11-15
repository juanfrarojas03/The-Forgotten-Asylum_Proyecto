using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorController : MonoBehaviour
{
    public KeyCode keyToOpen = KeyCode.E; // Tecla para abrir la puerta
    private bool isDoorOpen = false; // Estado de la puerta
    public float openDistance = 2f; // Distancia a la que se abrirán las partes de la puerta
    public float smooth = 2f; // Suavizado de la animación

    private Vector3 initialPositionLeft; // Posición inicial de la parte izquierda de la puerta
    private Vector3 initialPositionRight; // Posición inicial de la parte derecha de la puerta

    public Transform leftDoor; // Transform de la parte izquierda de la puerta
    public Transform rightDoor; // Transform de la parte derecha de la puerta

    private void Start()
    {

        initialPositionLeft = leftDoor.localPosition; // Guarda la posición inicial de la parte izquierda
        initialPositionRight = rightDoor.localPosition; // Guarda la posición inicial de la parte derecha
    }

    void Update()
    {
        // Verificar si el jugador presiona la tecla para abrir la puerta
        if (Input.GetKeyDown(keyToOpen))
        {
            if (!isDoorOpen)
            {
                // Abrir la puerta
                Vector3 targetPositionLeft = initialPositionLeft - Vector3.right * openDistance;
                Vector3 targetPositionRight = initialPositionRight + Vector3.right * openDistance;
                leftDoor.localPosition = Vector3.Lerp(leftDoor.localPosition, targetPositionLeft, Time.deltaTime * smooth);
                rightDoor.localPosition = Vector3.Lerp(rightDoor.localPosition, targetPositionRight, Time.deltaTime * smooth);
                isDoorOpen = true;
            }
            else
            {
                // Cerrar la puerta
                leftDoor.localPosition = Vector3.Lerp(leftDoor.localPosition, initialPositionLeft, Time.deltaTime * smooth);
                rightDoor.localPosition = Vector3.Lerp(rightDoor.localPosition, initialPositionRight, Time.deltaTime * smooth);
                isDoorOpen = false;
            }
        }
    }
}

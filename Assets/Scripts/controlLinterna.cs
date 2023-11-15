using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlLinterna : MonoBehaviour
{
    public float distanciaRetroceso = 1.0f; // Distancia a retroceder cuando se detecta una colisión
    public float distanciaDeteccion = 2.0f; // Distancia a la que se detecta el objeto

    public Vector3 posicionInicial;// Posición inicial de la cámara

    public GameObject luz;
    void Start()
    {
    }

    void Update()
    {
        Vector3 direccionMovimiento = Camera.main.transform.forward;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, luz.transform.forward, out hit, distanciaDeteccion))
        {
            // Si la distancia al objeto es menor que la distancia de detección
            if (hit.distance < distanciaDeteccion)
            {
                Vector3 direccionRetroceso = -hit.normal.normalized * distanciaRetroceso;
                transform.position += direccionRetroceso;
            }
        }
        else
        {
            // Si no hay colisión, vuelve a la posición inicial
            transform.position = Vector3.Lerp(transform.position, posicionInicial, Time.deltaTime * 5f);
        }
    }
}

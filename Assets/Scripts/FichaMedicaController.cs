using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FichaMedicaController : MonoBehaviour
{
    public bool esCorrecta;
    public string mensajeFichaCorrecta = "Ficha m�dica de Samuel Grimm";
    public string mensajeFichaIncorrecta = "Ficha m�dica de una persona";

    void Update()
    {
        // Comprobar si el jugador hace clic (o presiona un bot�n) para interactuar
        if (Input.GetKeyDown(KeyCode.E)) // Puedes ajustar el n�mero 0 seg�n el bot�n que desees utilizar
        {
            // Lanzar un rayo desde la c�mara en la direcci�n de la vista del jugador
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Comprobar si el rayo impacta con alg�n objeto
            if (Physics.Raycast(ray, out hit))
            {
                // Verificar si el objeto impactado es esta ficha m�dica
                if (hit.collider.gameObject == gameObject)
                {
                    RecogerFichaMedica();
                }
            }
        }
    }

    void RecogerFichaMedica()
    {
        // Implementar aqu� la l�gica para recoger la ficha m�dica
        // Por ejemplo, mostrar un mensaje, desactivar la ficha, etc.
        if (esCorrecta)
        {
            MostrarMensaje(mensajeFichaCorrecta);
        }
        else
        {
            MostrarMensaje(mensajeFichaIncorrecta);
        }

        // Destruir la ficha m�dica una vez que ha sido recogida
        Destroy(gameObject);
    }

    void MostrarMensaje(string mensaje)
    {
        // Implementar aqu� la l�gica para mostrar el mensaje en el juego
        Debug.Log(mensaje); // Por ejemplo, mostrar el mensaje en la consola (solo para prop�sitos de demostraci�n)
    }
}

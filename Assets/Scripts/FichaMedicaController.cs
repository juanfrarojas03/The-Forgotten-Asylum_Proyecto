using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FichaMedicaController : MonoBehaviour
{
    public bool esCorrecta;
    public string mensajeFichaCorrecta = "Ficha médica de Samuel Grimm";
    public string mensajeFichaIncorrecta = "Ficha médica de una persona";

    void Update()
    {
        // Comprobar si el jugador hace clic (o presiona un botón) para interactuar
        if (Input.GetKeyDown(KeyCode.E)) // Puedes ajustar el número 0 según el botón que desees utilizar
        {
            // Lanzar un rayo desde la cámara en la dirección de la vista del jugador
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Comprobar si el rayo impacta con algún objeto
            if (Physics.Raycast(ray, out hit))
            {
                // Verificar si el objeto impactado es esta ficha médica
                if (hit.collider.gameObject == gameObject)
                {
                    RecogerFichaMedica();
                }
            }
        }
    }

    void RecogerFichaMedica()
    {
        // Implementar aquí la lógica para recoger la ficha médica
        // Por ejemplo, mostrar un mensaje, desactivar la ficha, etc.
        if (esCorrecta)
        {
            MostrarMensaje(mensajeFichaCorrecta);
        }
        else
        {
            MostrarMensaje(mensajeFichaIncorrecta);
        }

        // Destruir la ficha médica una vez que ha sido recogida
        Destroy(gameObject);
    }

    void MostrarMensaje(string mensaje)
    {
        // Implementar aquí la lógica para mostrar el mensaje en el juego
        Debug.Log(mensaje); // Por ejemplo, mostrar el mensaje en la consola (solo para propósitos de demostración)
    }
}

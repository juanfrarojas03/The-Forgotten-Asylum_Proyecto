using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public Text statusText;

    public Acceso acceso;

    private void Start()
    {
        // Asegúrate de que el DatabaseManager esté en la escena y configurado correctamente
        acceso = FindObjectOfType<Acceso>();

    }


    public void OnLoginButtonClicked()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (acceso != null)
        {
            acceso.Abrir();
            if (acceso.VerificarInicioSesion(username, password))
            {
                SceneManager.LoadScene("Play");
                statusText.text = "Inicio de sesión exitoso";
            }
            else
            {
                statusText.text = "Inicio de sesión fallido. Verifica tu nombre de usuario y contraseña.";
            }
        }
        else
        {
            statusText.text = "Error de configuración. DatabaseManager no encontrado.";
        }
        acceso.Cerrar();
    }

    public void OnRegisterButtonClicked()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (acceso != null)
        {
            acceso.Abrir();
            bool registroExitoso = acceso.AgregarUsuario(username, password);
            acceso.Cerrar();

            if (registroExitoso)
            {
                // El registro fue exitoso, puedes proceder con alguna acción como cargar otra escena
                SceneManager.LoadScene("Play");
                statusText.text = "Registro exitoso";
            }
            else
            {
                statusText.text = "Error al registrar usuario. Inténtalo nuevamente.";
            }
        }
        else
        {
            statusText.text = "Error de configuración. Acceso no encontrado.";
        }
    }
}

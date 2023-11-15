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
        // Aseg�rate de que el DatabaseManager est� en la escena y configurado correctamente
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
                statusText.text = "Inicio de sesi�n exitoso";
            }
            else
            {
                statusText.text = "Inicio de sesi�n fallido. Verifica tu nombre de usuario y contrase�a.";
            }
        }
        else
        {
            statusText.text = "Error de configuraci�n. DatabaseManager no encontrado.";
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
                // El registro fue exitoso, puedes proceder con alguna acci�n como cargar otra escena
                SceneManager.LoadScene("Play");
                statusText.text = "Registro exitoso";
            }
            else
            {
                statusText.text = "Error al registrar usuario. Int�ntalo nuevamente.";
            }
        }
        else
        {
            statusText.text = "Error de configuraci�n. Acceso no encontrado.";
        }
    }
}

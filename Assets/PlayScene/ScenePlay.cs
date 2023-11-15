using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePlay : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Cinematica");
    }

    public void OnLogOutButtonClicked()
    {
        SceneManager.LoadScene("Login");
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }

    public void OnReturnButtonClicked()
    {
        SceneManager.LoadScene("Play");
    }

    public void OnContinueButtonClicked()
    {
        SceneManager.LoadScene("Game");
    }
}

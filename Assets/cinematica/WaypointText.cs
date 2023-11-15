using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaypointText : MonoBehaviour
{
    public Camera cameraCin;
    public Vector3 targetCoordinate;
    public Vector3 finalTarget;
    public TextMeshProUGUI displayText;

    private bool hasReachedTarget = false;
    private int textChangeCount = 0;

    public GameObject boton;

    void Start()
    {
        displayText.gameObject.SetActive(false);
        boton.SetActive(false);
    }

    void Update()
    {
        if (!hasReachedTarget && Vector3.Distance(cameraCin.transform.position, targetCoordinate) < 0.1f)
        {
            displayText.text = GetNextText();
            displayText.gameObject.SetActive(true);

            hasReachedTarget = true;
        }
        if(Vector3.Distance(cameraCin.transform.position, finalTarget) < 0.1f)
        {
            boton.SetActive(true);
        }

    }

    string GetNextText()
    {
        switch (textChangeCount)
        {
            case 0:
                return "Este lugar ha guardado sus secretos durante demasiado tiempo...";
            case 1:
                return "¿Qué historias escondes entre tus muros?";
            case 2:
                return "En busca de respuestas...";
            case 3:
                return "Algunos secretos no deberían ser desenterrados.";
            case 4:
                return "¿Qué me aguarda detrás de cada puerta?";
            case 5:
                return "Cada sombra, cada rincón... todos tienen su propia historia.";
            case 6:
                return "Pero descubrir la verdad tiene su precio. Y estoy dispuesto a pagarlo.";
            default:
                return "Texto por defecto";
        }
    }

    void ChangeText()
    {
            textChangeCount++;

            if (textChangeCount < 7)
            {
                displayText.text = GetNextText();

                Invoke("ChangeText", 5.5f);
            }
            else
            {
                Invoke("HideText", 5.5f);
            }
    }

    void HideText()
    {
        displayText.gameObject.SetActive(false);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Game");
    }
}

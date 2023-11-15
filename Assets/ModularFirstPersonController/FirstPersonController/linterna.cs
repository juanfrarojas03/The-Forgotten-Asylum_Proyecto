using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class linterna : MonoBehaviour
{
    [Header("Energia")]
    public float EnergiaActual = 100;
    public float EnergiaMaxima = 100;
    public float VelocidadConsumo = 0.25f;
    public Light lanternLight;
    public Light lanterncerca;

    [Header("Interfaz")]
    public Image BarraBateria;

    public AudioSource audioSource;
    public AudioClip sonido;

    private bool isLanternOn = false;

    void Start()
    {
        lanternLight.enabled = false;
        lanterncerca.enabled = false;
    }

    void Update()
    { 
        //Encender y Apagar
        if (Input.GetKeyDown(KeyCode.F))
        {
            isLanternOn = !isLanternOn;

            lanternLight.enabled = isLanternOn;
            lanterncerca.enabled = isLanternOn;
            audioSource.PlayOneShot(sonido);
        }

        if(lanternLight.enabled)
        {
            EnergiaActual -= Time.deltaTime * VelocidadConsumo;

            if(EnergiaActual <= 0) 
            {
                EnergiaActual = 0;
                lanternLight.enabled = false;
                lanterncerca.enabled = false;
                audioSource.PlayOneShot(sonido);
            }
        }

        BarraBateria.fillAmount = EnergiaActual/EnergiaMaxima;
    }
}

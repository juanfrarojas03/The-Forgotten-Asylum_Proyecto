using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steps : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] sonidosPasos;
    public float volumenPasos = 0.5f;
    public float delayEntrePasos = 0.5f;
    public float delayEntrePasosRapidos = 0.25f;

    private float tiempoUltimoPaso;

    void Start()
    {
        tiempoUltimoPaso = Time.time;
    }

    void Update()
    {
        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        { 
            if (Time.time - tiempoUltimoPaso > (Input.GetKey(KeyCode.LeftShift) ? delayEntrePasosRapidos : delayEntrePasos))
            {
                ReproducirSonidoPaso();
                tiempoUltimoPaso = Time.time;
            }
        }
    }

    void ReproducirSonidoPaso()
    {       
        if (audioSource != null && sonidosPasos.Length > 0)
        {  
            AudioClip pasoAleatorio = sonidosPasos[Random.Range(0, sonidosPasos.Length)];

            audioSource.clip = pasoAleatorio;
            audioSource.volume = volumenPasos;
            audioSource.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public Transform player;

    public float distanciaParaMatar = 2f;

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, player.position);

        if (distancia <= distanciaParaMatar)
        {
            CambiarEscena();
        }
    }

    void CambiarEscena()
    {
       SceneManager.LoadScene("Lose");
    }
}

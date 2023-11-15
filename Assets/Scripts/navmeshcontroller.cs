using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class navmeshcontroller : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform jugador;
    private Vector3 destinoAleatorio;
    public bool persiguiendo = false;
    public bool caminando = false;

    public float rangoMovimiento = 20f;
    public float tiempoEsperaMinimo = 2f;
    public float tiempoEsperaMaximo = 5f;
    public float rangoVision = 20f;

    private float tiempoEsperaActual;

    public Animator animator;

    public GameObject Jugador;

    public float distanciaParaMatar = 2f;
    public string nombreEscenaSiguiente = "Lose";

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        ObtenerNuevoDestinoAleatorio();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (persiguiendo)
        {
            navMeshAgent.SetDestination(jugador.position);
            caminando = false;

        }
        else if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f)
        {
            tiempoEsperaActual = Random.Range(tiempoEsperaMinimo, tiempoEsperaMaximo);
            Invoke("ObtenerNuevoDestinoAleatorio", tiempoEsperaActual);
            caminando = true;
        }
        else
        {
            caminando = false;
        }

        if (Vector3.Distance(transform.position, jugador.position) <= rangoVision)
        {
            Vector3 direccionJugador = (jugador.position - transform.position).normalized;
            RaycastHit hit;

            if (Physics.Raycast(transform.position, direccionJugador, out hit, rangoVision))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    persiguiendo = true;
                    navMeshAgent.speed = 4f;

                }
                else
                {
                    persiguiendo = false;
                    navMeshAgent.speed = 2f;
                }
            }
        }
        else
        {
            persiguiendo = false;
            navMeshAgent.speed = 2f;
        }

        if (animator != null)
        {
            animator.SetBool("IsWalking", caminando);
        }

        if (distancia <= distanciaParaMatar)
        {
            CambiarEscena();
        }
        else
        {
            navMeshAgent.SetDestination(jugador.position);
        }
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene(nombreEscenaSiguiente);
    }

    void ObtenerNuevoDestinoAleatorio()
    {
        Vector3 puntoAleatorio = Random.insideUnitSphere * rangoMovimiento;
        NavMeshHit hit;
        NavMesh.SamplePosition(transform.position + puntoAleatorio, out hit, rangoMovimiento, NavMesh.AllAreas);
        destinoAleatorio = hit.position;
        navMeshAgent.SetDestination(destinoAleatorio);
    }
}

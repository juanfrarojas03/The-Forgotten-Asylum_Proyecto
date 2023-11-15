using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agarrarobjeto : MonoBehaviour
{
    private GameObject objetoActual;
    private bool estaSiendoAgarrado = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && objetoActual != null && !estaSiendoAgarrado)
        {
            objetoActual.transform.parent = this.transform;
            estaSiendoAgarrado = true;
        }

        if (Input.GetKeyUp(KeyCode.E) && objetoActual != null && estaSiendoAgarrado)
        {
            objetoActual.transform.parent = null;
            estaSiendoAgarrado = false;
        }

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 10))
        {
            if (hit.collider.CompareTag("Agarrable"))
            {
                objetoActual = hit.collider.gameObject;
            }
            else
            {
                objetoActual = null;
            }
        }
        else
        {
            objetoActual = null;
        }
    }
}

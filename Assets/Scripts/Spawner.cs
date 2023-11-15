using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fichaMedicaPrefab; // Prefab de la ficha médica que quieres spawnear
    public Transform[] spawnPoints; // Array que contiene los gameobjects vacíos que son puntos de spawn
    public int cantidadFichasMedicas = 5; // Cantidad total de fichas médicas a spawnear
    public string mensajeFichaCorrecta = "Ficha médica de Samuel Grimm";
    public string mensajeFichaIncorrecta = "Ficha médica de una persona";

    void Start()
    {
        // Lista que almacenará los índices de spawnPoints seleccionados
        var spawnIndexes = new List<int>();

        // Spawneamos la cantidad deseada de fichas médicas
        for (int i = 0; i < cantidadFichasMedicas; i++)
        {
            // Elegir aleatoriamente uno de los spawnPoints que aún no ha sido seleccionado
            int spawnIndex;
            do
            {
                spawnIndex = Random.Range(0, spawnPoints.Length);
            } while (spawnIndexes.Contains(spawnIndex)); // Aseguramos que no se seleccione un punto de spawn ya utilizado

            spawnIndexes.Add(spawnIndex); // Agregamos el índice seleccionado a la lista

            // Spawneamos la ficha médica en el punto seleccionado
            GameObject fichaMedica = Instantiate(fichaMedicaPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);

            // Marcamos una de las fichas médicas como la correcta (la primera que se genera)
            if (i == 0)
            {
                // Agregamos el componente FichaMedicaController al objeto spawnado
                FichaMedicaController controller = fichaMedica.AddComponent<FichaMedicaController>();
                controller.esCorrecta = true;
                controller.mensajeFichaCorrecta = mensajeFichaCorrecta;
                controller.mensajeFichaIncorrecta = mensajeFichaIncorrecta;
            }
            else
            {
                // Si no es la ficha médica correcta, agregamos el componente FichaMedicaController
                FichaMedicaController controller = fichaMedica.AddComponent<FichaMedicaController>();
                controller.esCorrecta = false;
                controller.mensajeFichaCorrecta = mensajeFichaCorrecta;
                controller.mensajeFichaIncorrecta = mensajeFichaIncorrecta;
            }
        }
    }
}
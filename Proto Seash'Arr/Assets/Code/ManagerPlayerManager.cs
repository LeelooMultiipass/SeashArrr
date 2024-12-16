using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ManagerPlayerManager : MonoBehaviour
{
    public GameObject[] prefabs; // Tableau de préfabriqués à instancier
    public int numberToSpawn = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnChangePrefab(InputAction.CallbackContext context)
    {
        if (context.started) // Vérifie que l'action a commencé
        {
            for (int i = 0; i < numberToSpawn; i++)
            {
                // Sélectionne un préfabriqué aléatoire dans la liste
                GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)];

            }
        }
    }
}


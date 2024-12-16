using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZoneUIController : MonoBehaviour
{
    public GameObject linkedUI;  // L'UI qui sera activée et désactivée pour cette zone

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (linkedUI != null)
            {
                linkedUI.SetActive(true);  // Activer l'UI quand le joueur entre
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (linkedUI != null)
            {
                linkedUI.SetActive(false);  // Désactiver l'UI quand le joueur sort
            }
        }
    }
}
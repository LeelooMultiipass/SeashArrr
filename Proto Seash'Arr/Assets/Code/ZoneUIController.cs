using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneUIController : MonoBehaviour
{
    public GameObject linkedUI;  // Le panneau UI qui s'affiche lorsque le joueur appuie sur E/X
    public GameObject buttonIcon; // L'icône du bouton qui s'affiche lorsque le joueur entre dans la zone

    private bool isPlayerInZone = false; // Le joueur est-il dans la zone ?
    private bool isUIVisible = false;   // Le panneau UI est-il visible actuellement ?

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = true;

            // Afficher l'icône du bouton
            if (buttonIcon != null)
            {
                buttonIcon.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false;

            // Cacher l'icône du bouton
            if (buttonIcon != null)
            {
                buttonIcon.SetActive(false);
            }

            // Cacher le panneau UI si encore visible
            HideUI();
        }
    }

    private void Update()
    {
        // Si le joueur est dans la zone, vérifier l'entrée utilisateur
        if (isPlayerInZone)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("XButton"))
            {
                // Basculer entre afficher et masquer le panneau UI
                if (isUIVisible)
                {
                    HideUI();
                }
                else
                {
                    ShowUI();
                }
            }
        }
    }

    private void ShowUI()
    {
        if (linkedUI != null)
        {
            linkedUI.SetActive(true); // Activer le panneau UI
            isUIVisible = true;

            // Cacher l'icône du bouton pendant que l'UI est affichée
            if (buttonIcon != null)
            {
                buttonIcon.SetActive(false);
            }
        }
    }

    private void HideUI()
    {
        if (linkedUI != null)
        {
            linkedUI.SetActive(false); // Désactiver le panneau UI
            isUIVisible = false;

            // Réafficher l'icône du bouton si le joueur est toujours dans la zone
            if (isPlayerInZone && buttonIcon != null)
            {
                buttonIcon.SetActive(true);
            }
        }
    }
}
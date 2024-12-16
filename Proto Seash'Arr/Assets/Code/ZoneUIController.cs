using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class ZoneUIController : MonoBehaviour
{
    public GameObject linkedUI;  // Le panneau UI qui s'affiche lorsque le joueur appuie sur E/X
    public GameObject buttonIcon; // L'icône du bouton qui s'affiche lorsque le joueur entre dans la zone

    private bool isPlayerInZone = false; // Le joueur est-il dans la zone ?
    private bool isUIVisible = false;   // Le panneau UI est-il visible actuellement ?
    public RectTransform canvas;  // Référence au RectTransform du Canvas
    public GameObject character; 

    private void OnTriggerEnter(Collider other)
    {

        // Vérifier si le bouton et le personnage sont bien assignés
        if (linkedUI != null && character != null && canvas != null)
        {
            // Récupérer la position mondiale du personnage
            Vector3 worldPosition = character.transform.position;

            // Convertir la position mondiale du personnage en coordonnées d'écran
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

            // Afficher la position d'écran pour déboguer
            Debug.Log("Position d'écran du personnage : " + screenPosition);

            // Convertir la position d'écran en position locale dans le Canvas
            Vector2 localPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.GetComponent<RectTransform>(),  // RectTransform du Canvas
                screenPosition,                        // Position d'écran
                Camera.main,                           // Caméra principale
                out localPosition                      // Position locale du Canvas
            );

            // Afficher la position locale pour vérifier
            Debug.Log("Position locale du Canvas : " + localPosition);

            // Appliquer la position locale à l'UI liée
            linkedUI.transform.localPosition = localPosition;

            // Activer l'UI liée (si elle n'est pas encore active)
            linkedUI.SetActive(true);
        }



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
            if (Input.GetKeyDown(KeyCode.E))
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
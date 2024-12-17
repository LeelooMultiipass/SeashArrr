using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtelierManager : MonoBehaviour
{
    public GameObject ButtonAtelier;

    public GameObject PanelCuisine;
    public GameObject PanelTableIngenieur;
    public GameObject PanelPiqueNique;
    public GameObject PanelCanon;

    public bool cuisineActive; 
    public bool tableIngenieurActive;
    public bool canonActive;
    public bool piqueNiqueActive;

    private void Start()
    {
        if (ButtonAtelier != null)
        {
            ButtonAtelier.SetActive(false);
        }
        CloseAllPanels();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (ButtonAtelier != null)
        {
            if (other.CompareTag("Cuisine"))
            {
                ButtonAtelier.SetActive(true);
                cuisineActive = true;
            }

            if (other.CompareTag("TableIngenieur"))
            {
                ButtonAtelier.SetActive(true);
                tableIngenieurActive = true;
            }

            if (other.CompareTag("Canon"))
            {
                ButtonAtelier.SetActive(true);
                canonActive = true;
            }

            if (other.CompareTag("PiqueNique"))
            {
                ButtonAtelier.SetActive(true);
                piqueNiqueActive = true;
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (ButtonAtelier != null)
        {
            if (other.CompareTag("Cuisine"))
            {
                ButtonAtelier.SetActive(false);
                cuisineActive = false;
            }

            if (other.CompareTag("TableIngenieur"))
            {
                ButtonAtelier.SetActive(false);
                tableIngenieurActive = false;
            }

            if (other.CompareTag("Canon"))
            {
                ButtonAtelier.SetActive(false);
                canonActive = false;
            }

            if (other.CompareTag("PiqueNique"))
            {
                ButtonAtelier.SetActive(false);
                piqueNiqueActive = false;
            }
        }

        CloseInactivePanels();
    }

    

    // Méthode générique pour ouvrir un panel
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    // Méthode générique pour fermer un panel
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    // ouvrir un panel spécifique
    public void OpenTogglePanelCuisine() 
    { 
        if (PanelCuisine != null && !PanelCuisine.activeSelf && cuisineActive) 
        { 
            OpenPanel(PanelCuisine); 
        } 
    }
    public void OpenTogglePanelTableIngenieur() { if (PanelTableIngenieur != null && !PanelTableIngenieur.activeSelf && tableIngenieurActive) { OpenPanel(PanelTableIngenieur);  } }
    public void OpenTogglePanelPiqueNique() { if (PanelPiqueNique != null && !PanelPiqueNique.activeSelf && piqueNiqueActive) { OpenPanel(PanelPiqueNique);  } }
    public void OpenTogglePanelCanon() { if (PanelCanon != null && !PanelCanon.activeSelf && canonActive) { OpenPanel(PanelCanon);  } }


    // fermer un panel spécifique 
    public void CloseTogglePanelCuisine() { if (PanelCuisine != null && PanelCuisine.activeSelf ) { ClosePanel(PanelCuisine); cuisineActive = false; } }
    public void CloseTogglePanelTableIngenieur() { if (PanelTableIngenieur != null && PanelTableIngenieur.activeSelf ) { ClosePanel(PanelTableIngenieur); tableIngenieurActive = false; } }
    public void CloseTogglePanelPiqueNique() { if (PanelPiqueNique != null && PanelPiqueNique.activeSelf ) { ClosePanel(PanelPiqueNique); piqueNiqueActive = false; } }
    public void CloseTogglePanelCanon() { if (PanelCanon != null && PanelCanon.activeSelf) { ClosePanel(PanelCanon); canonActive = false; } }

    public void CloseAllPanels()
    {
        if (PanelCuisine != null) ClosePanel(PanelCuisine);
        if (PanelTableIngenieur != null) ClosePanel(PanelTableIngenieur);
        if (PanelPiqueNique != null) ClosePanel(PanelPiqueNique);
        if (PanelCanon != null) ClosePanel(PanelCanon);
    }


    void OpenActivePanels()
    {
        OpenTogglePanelCuisine(); 

        OpenTogglePanelTableIngenieur(); 

        OpenTogglePanelPiqueNique(); 

        OpenTogglePanelCanon(); 
    }

     void CloseInactivePanels()
    {
        CloseTogglePanelCuisine(); 

        CloseTogglePanelTableIngenieur();

        CloseTogglePanelPiqueNique(); 

        CloseTogglePanelCanon(); 
    }
}

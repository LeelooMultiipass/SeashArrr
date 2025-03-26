using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AtelierManager : MonoBehaviour
{
    public GameObject ButtonAtelier;

    public GameObject PanelCuisine;
    public GameObject PanelTableIngenieur;
    public GameObject PanelPiqueNique;
    public GameObject PanelCanon;
    //public GameObject PanelAncre;

    public bool cuisineActive; 
    public bool tableIngenieurActive;
    public bool canonActive;
    public bool piqueNiqueActive;
    public bool ancreActive;

    [Header ("Inputs")]

    public InputActionAsset inputActionAsset;

    private InputActionMap NavigationMap;
    private InputActionMap CuisineMap;
    private InputActionMap CanonMap;
    private InputActionMap PiqueNiqueMap;
    private InputActionMap IngeniorMap;

    public InputAction InteractKitchen;
    public InputAction CanonToggle; 
    public InputAction IngeniorToggle; 
    public InputAction PiqueNiqueToggle;


    private void Start()
    {
        if (ButtonAtelier != null)
        {
            ButtonAtelier.SetActive(false);
        }
        CloseAllPanels();

        NavigationMap = inputActionAsset.FindActionMap("GameplayNavigation");
        CuisineMap = inputActionAsset.FindActionMap("Cuisine");
        CanonMap = inputActionAsset.FindActionMap("Canon");
        PiqueNiqueMap = inputActionAsset.FindActionMap("PiqueNique");
        IngeniorMap = inputActionAsset.FindActionMap("Ingenior");

        SwitchtoGameplay();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (ButtonAtelier != null)
        {
            if (other.CompareTag("Cuisine"))
            {
                ButtonAtelier.SetActive(true);
                cuisineActive = true;
                SwitchToCuisine();
            }
            else if (other.CompareTag("TableIngenieur"))
            {
                ButtonAtelier.SetActive(true);
                tableIngenieurActive = true;
                SwitchToIngenior();
            }
            else if (other.CompareTag("Canon"))
            {
                ButtonAtelier.SetActive(true);
                canonActive = true;
                SwitchToCanon();
            }
            else if (other.CompareTag("PiqueNique"))
            {
                ButtonAtelier.SetActive(true);
                piqueNiqueActive = true;
                SwitchToPiqueNique();
            }
            else if (other.CompareTag("Ancre"))
            {
                ButtonAtelier.SetActive(true);
                ancreActive = true;
                //SwitchToPiqueNique();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (ButtonAtelier != null)
        {
            ButtonAtelier.SetActive(false);

            if (other.CompareTag("Cuisine"))
            {
                cuisineActive = false;
                PanelCuisine.SetActive(false);
            }
            else if (other.CompareTag("TableIngenieur"))
            {
                tableIngenieurActive = false;
                PanelTableIngenieur.SetActive(false);
            }
            else if (other.CompareTag("Canon"))
            {
                canonActive = false;
                PanelCanon.SetActive(false);
            }
            else if (other.CompareTag("PiqueNique"))
            {
                piqueNiqueActive = false;
                PanelPiqueNique.SetActive(false);
            }
            else if (other.CompareTag("Ancre"))
            {
                ancreActive = false;
               // PanelAncre.SetActive(false);
            }

            // Revert to navigation controls when leaving
            SwitchtoGameplay();
        }
    }


    private void SwitchtoGameplay()
    {
        DisableAllActionMaps();
        NavigationMap.Enable();
        Debug.Log("Switched to GameplayNavigation map");
    }

    private void SwitchToCuisine()
    {
        DisableAllActionMaps();
        CuisineMap.Enable();
        Debug.Log("Switched to Cuisine map");
    }

    private void SwitchToCanon()
    {
        DisableAllActionMaps();
        CanonMap.Enable();
        Debug.Log("Switched to Canon map");
    }

    private void SwitchToPiqueNique()
    {
        DisableAllActionMaps();
        PiqueNiqueMap.Enable();
        Debug.Log("Switched to PiqueNique map");
    }

    private void SwitchToIngenior()
    {
        DisableAllActionMaps();
        IngeniorMap.Enable();
        Debug.Log("Switched to Ingenior map");
    }

    private void DisableAllActionMaps()
    {
        CuisineMap?.Disable();
        CanonMap?.Disable();
        PiqueNiqueMap?.Disable();
        IngeniorMap?.Disable();
    }


    // Méthode générique pour ouvrir un panel
    void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    // Méthode générique pour fermer un panel
    void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    private void OnEnable()
    {
        InteractKitchen.Enable();
        IngeniorToggle.Enable();
        PiqueNiqueToggle.Enable();
        CanonToggle.Enable();

        InteractKitchen.started +=OpenTogglePanelCuisine;
        IngeniorToggle.started += OpenTogglePanelTableIngenieur;
        PiqueNiqueToggle.started += OpenTogglePanelPiqueNique;
        CanonToggle.started += OpenTogglePanelCanon;
    }

    private void OnDisable()
    {
        InteractKitchen.Disable();
        IngeniorToggle.Disable();
        PiqueNiqueToggle.Disable();
        CanonToggle.Disable();

        InteractKitchen.started -= OpenTogglePanelCuisine;
        IngeniorToggle.started -= OpenTogglePanelTableIngenieur;
        PiqueNiqueToggle.started -= OpenTogglePanelPiqueNique;
        CanonToggle.started -= OpenTogglePanelCanon;
    }

    // ouvrir un panel spécifique
    void OpenTogglePanelCuisine(InputAction.CallbackContext context) 
    { 
        if (PanelCuisine != null && !PanelCuisine.activeSelf && cuisineActive) 
        { 
            OpenPanel(PanelCuisine); 
        } 
    }
    void OpenTogglePanelTableIngenieur(InputAction.CallbackContext context) { if (PanelTableIngenieur != null && !PanelTableIngenieur.activeSelf && tableIngenieurActive) { OpenPanel(PanelTableIngenieur);  } }
    void OpenTogglePanelPiqueNique(InputAction.CallbackContext context) { if (PanelPiqueNique != null && !PanelPiqueNique.activeSelf && piqueNiqueActive) { OpenPanel(PanelPiqueNique);  } }
    void OpenTogglePanelCanon(InputAction.CallbackContext context) { if (PanelCanon != null && !PanelCanon.activeSelf && canonActive) { OpenPanel(PanelCanon);  } }


    // fermer un panel spécifique 
    void CloseTogglePanelCuisine(InputAction.CallbackContext context) { if (PanelCuisine != null && PanelCuisine.activeSelf ) { ClosePanel(PanelCuisine); cuisineActive = false; } }
    void CloseTogglePanelTableIngenieur(InputAction.CallbackContext context) { if (PanelTableIngenieur != null && PanelTableIngenieur.activeSelf ) { ClosePanel(PanelTableIngenieur); tableIngenieurActive = false; } }
    void CloseTogglePanelPiqueNique(InputAction.CallbackContext context) { if (PanelPiqueNique != null && PanelPiqueNique.activeSelf ) { ClosePanel(PanelPiqueNique); piqueNiqueActive = false; } }
    void CloseTogglePanelCanon(InputAction.CallbackContext context) { if (PanelCanon != null && PanelCanon.activeSelf) { ClosePanel(PanelCanon); canonActive = false; } }

    void CloseAllPanels()
    {
        if (PanelCuisine != null) ClosePanel(PanelCuisine);
        if (PanelTableIngenieur != null) ClosePanel(PanelTableIngenieur);
        if (PanelPiqueNique != null) ClosePanel(PanelPiqueNique);
        if (PanelCanon != null) ClosePanel(PanelCanon);
    }


    //void OpenActivePanels()
    //{
    //    OpenTogglePanelCuisine(); 

    //    OpenTogglePanelTableIngenieur(); 

    //    OpenTogglePanelPiqueNique(); 

    //    OpenTogglePanelCanon(); 
    //}

    // void CloseInactivePanels()
    //{
    //    CloseTogglePanelCuisine(); 

    //    CloseTogglePanelTableIngenieur();

    //    CloseTogglePanelPiqueNique(); 

    //    CloseTogglePanelCanon(); 
    //}

}

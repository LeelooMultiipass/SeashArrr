using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class liaisonStatsManager : MonoBehaviour
{
    private StatsManager statsManager;
    private UseAtelier useAtelier; // Reference to the UseAtelier script
    public AtelierManager atelierManager;

    public InputAction CuisinerRagout;
    public InputAction CuisinerRhum;
    public InputAction Manger;
    public InputAction RepCanon;
    public InputAction AmeBateau;
    public InputAction AmeCanon;

    // Start is called before the first frame update
    void Start()
    {
        // Find the GameObject with the "StatsManager" tag
        GameObject statsManagerObject = GameObject.FindGameObjectWithTag("StatsManager");

        if (statsManagerObject != null)
        {
            // Get the StatsManager component
            statsManager = statsManagerObject.GetComponent<StatsManager>();
            if (statsManager != null)
            {
                Debug.Log("StatsManager found: " + statsManager.name);
            }
            else
            {
                Debug.LogError("StatsManager component not found on GameObject with tag 'StatsManager'!");
            }

            // Get the UseAtelier component
            useAtelier = statsManagerObject.GetComponent<UseAtelier>();
            if (useAtelier != null)
            {
                Debug.Log("UseAtelier found: " + useAtelier.name);
            }
            else
            {
                Debug.LogWarning("UseAtelier component not found on GameObject with tag 'StatsManager'.");
            }
        }
        else
        {
            Debug.LogError("No GameObject with the 'StatsManager' tag found in the scene!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        CuisinerRagout.Enable();
        CuisinerRhum.Enable();
        Manger.Enable();
        RepCanon.Enable();
        AmeBateau.Enable();
        AmeCanon.Enable();
        CuisinerRagout.started += TriggerUseAtelierCuisineRagout;
        CuisinerRhum.started += TriggerUseAtelierCuisinerRhum;
        Manger.started += TriggerUseAtelierManger;
        RepCanon.started += TriggerUseAtelierRepCanon;
        AmeBateau.started += TriggerUseAtelierAmeBateau;
        AmeCanon.started += TriggerUseAtelierAmeCanon;

    }

    private void OnDisable()
    {
        CuisinerRagout.started -= TriggerUseAtelierCuisineRagout;
        CuisinerRhum.started -= TriggerUseAtelierCuisinerRhum;
        Manger.started -= TriggerUseAtelierManger;
        RepCanon.started -= TriggerUseAtelierRepCanon;
        AmeBateau.started -= TriggerUseAtelierAmeBateau;
        AmeCanon.started -= TriggerUseAtelierAmeCanon;
        CuisinerRagout.Disable();
        CuisinerRhum.Disable();
        Manger.Disable();
        RepCanon.Disable();
        AmeBateau.Disable();
        AmeCanon.Disable();
    }

    public void TriggerUseAtelierAmeBateau(InputAction.CallbackContext context)
    {
        if (atelierManager.PanelTableIngenieur.activeSelf)
        {
            if (useAtelier != null)
            {
                useAtelier.AmeliorationBateau();  // Call method from UseAtelier
                statsManager.boatMaxHealth += 100;
                statsManager.UpdateText();
                Debug.Log("TriggerUseAtelierAction called from liaisonStatsManager.");
            }
            else
            {
                Debug.LogError("UseAtelier not found!");
            }
        }
    }

    public void TriggerUseAtelierAmeCanon(InputAction.CallbackContext context)
    {
        if (atelierManager.PanelTableIngenieur.activeSelf)
        {
            if (useAtelier != null)
            {
                useAtelier.AmeliorationCanon();  // Call method from UseAtelier
                statsManager.canonMaxHealth += 100;
                statsManager.UpdateText();
                Debug.Log("TriggerUseAtelierAction called from liaisonStatsManager.");
            }
            else
            {
                Debug.LogError("UseAtelier not found!");
            }
        }
    }

    public void TriggerUseAtelierManger(InputAction.CallbackContext context)
    {
        if (atelierManager.PanelPiqueNique.activeSelf)
        {
            if (useAtelier != null)
            {
                useAtelier.Manger();  // Call method from UseAtelier
                Debug.Log("TriggerUseAtelierAction called from liaisonStatsManager.");
            }
            else
            {
                Debug.LogError("UseAtelier not found!");
            }
        }
    }

    public void TriggerUseAtelierRepBateau(InputAction.CallbackContext context)
    {
        if (useAtelier != null)
        {
            useAtelier.ReparerBateau();  // Call method from UseAtelier
            Debug.Log("TriggerUseAtelierAction called from liaisonStatsManager.");
        }
        else
        {
            Debug.LogError("UseAtelier not found!");
        }
    }

    public void TriggerUseAtelierRepCanon(InputAction.CallbackContext context)
    {
        if (atelierManager.PanelCanon.activeSelf)
        {
            if (useAtelier != null)
            {
                if (statsManager.canonHealth < statsManager.canonMaxHealth)
                {
                    useAtelier.ReparerCanon();  // Call method from UseAtelier
                    statsManager.canonHealth += (int)(statsManager.canonMaxHealth * 0.2f);
                    statsManager.UpdateText();
                    Debug.Log("TriggerUseAtelierAction called from liaisonStatsManager.");
                }
            }
            else
            {
                Debug.LogError("UseAtelier not found!");
            }
        }
    }

    public void TriggerUseAtelierCuisineRagout(InputAction.CallbackContext context)
    {
        if (atelierManager.PanelCuisine.activeSelf)
        {
            if (useAtelier != null)
            {
                useAtelier.CuisinerRagout();  // Call method from UseAtelier
                statsManager.nbrRagout += 1;
                statsManager.UpdateText();
                Debug.Log("TriggerUseAtelierAction called from liaisonStatsManager.");
            }
            else
            {
                Debug.LogError("UseAtelier not found!");
            }
        }
    }

    public void TriggerUseAtelierCuisinerRhum(InputAction.CallbackContext context)
    {
        if (atelierManager.PanelCuisine.activeSelf)
        {
            if (useAtelier != null)
            {
                useAtelier.CuisinerRhum();  // Call method from UseAtelier
                statsManager.nbrRhum += 1;
                if(useAtelier.isBusy == false)
                {
                    statsManager.UpdateText();
                }
                

                Debug.Log("TriggerUseAtelierAction called from liaisonStatsManager.");
            }
            else
            {
                Debug.LogError("UseAtelier not found!");
            }
        }
    }
}
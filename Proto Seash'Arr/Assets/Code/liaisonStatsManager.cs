using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liaisonStatsManager : MonoBehaviour
{
    private StatsManager statsManager;
    private UseAtelier useAtelier; // Reference to the UseAtelier script

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

    public void TriggerUseAtelierAmeBateau()
    {
        if (useAtelier != null)
        {
            useAtelier.AmeliorationBateau();  // Call method from UseAtelier
            Debug.Log("TriggerUseAtelierAction called from liaisonStatsManager.");
        }
        else
        {
            Debug.LogError("UseAtelier not found!");
        }
    }

    public void TriggerUseAtelierAmeCanon()
    {
        if (useAtelier != null)
        {
            useAtelier.AmeliorationCanon();  // Call method from UseAtelier
            Debug.Log("TriggerUseAtelierAction called from liaisonStatsManager.");
        }
        else
        {
            Debug.LogError("UseAtelier not found!");
        }
    }

    public void TriggerUseAtelierManger()
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

    public void TriggerUseAtelierRepBateau()
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

    public void TriggerUseAtelierRepCanon()
    {
        if (useAtelier != null)
        {
            useAtelier.ReparerCanon();  // Call method from UseAtelier
            Debug.Log("TriggerUseAtelierAction called from liaisonStatsManager.");
        }
        else
        {
            Debug.LogError("UseAtelier not found!");
        }
    }

    public void TriggerUseAtelierCuisineRagout()
    {
        if (useAtelier != null)
        {
            useAtelier.CuisinerRagout();  // Call method from UseAtelier
            Debug.Log("TriggerUseAtelierAction called from liaisonStatsManager.");
        }
        else
        {
            Debug.LogError("UseAtelier not found!");
        }
    }

    public void TriggerUseAtelierCuisinerRhum()
    {
        if (useAtelier != null)
        {
            useAtelier.CuisinerRhum();  // Call method from UseAtelier
            Debug.Log("TriggerUseAtelierAction called from liaisonStatsManager.");
        }
        else
        {
            Debug.LogError("UseAtelier not found!");
        }
    }
}
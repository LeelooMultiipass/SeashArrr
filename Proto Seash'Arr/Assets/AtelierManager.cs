using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtelierManager : MonoBehaviour
{
    public GameObject ButtonPanel;
    public GameObject PanelCuisine;

    private void Start()
    {
        ButtonPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Cuisine"))
        {
           // Debug.Log("CollisionCuisine");
            ButtonPanel.SetActive(true);
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cuisine"))
        {
            ButtonPanel.SetActive(false);
        }
    }
}

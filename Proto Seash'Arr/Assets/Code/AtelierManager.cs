using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtelierManager : MonoBehaviour
{
    public GameObject ButtonAtelier;
    public GameObject PanelCuisine;

    private void Start()
    {
        ButtonAtelier.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Cuisine"))
        {
            // Debug.Log("CollisionCuisine");
            ButtonAtelier.SetActive(true);
        }

        if (other.CompareTag("TableIngenieur"))
        {
            // Debug.Log("CollisionCuisine");
            ButtonAtelier.SetActive(true);
        }

        if (other.CompareTag("Canon"))
        {
            // Debug.Log("CollisionCuisine");
            ButtonAtelier.SetActive(true);
        }

        if (other.CompareTag("PiqueNique"))
        {
            // Debug.Log("CollisionCuisine");
            ButtonAtelier.SetActive(true);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cuisine"))
        {
            ButtonAtelier.SetActive(false);
        }

        if (other.CompareTag("TableIngenieur"))
        {
            ButtonAtelier.SetActive(false);
        }

        if (other.CompareTag("Canon"))
        {
            ButtonAtelier.SetActive(false);
        }

        if (other.CompareTag("PiqueNique"))
        {
            ButtonAtelier.SetActive(false);
        }
    }
}

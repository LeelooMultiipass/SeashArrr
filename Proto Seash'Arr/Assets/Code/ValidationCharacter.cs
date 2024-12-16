using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValidationCharacter : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Valider;

    public bool Player1Ok = false;
    public bool Player2Ok = false;
    public bool Player3Ok = false;

    void Start()
    {
        // Ajouter des écouteurs d'événements pour chaque bouton
        Player1.GetComponent<Button>().onClick.AddListener(TogglePlayer1);
        Player2.GetComponent<Button>().onClick.AddListener(TogglePlayer2);
        Player3.GetComponent<Button>().onClick.AddListener(TogglePlayer3);
    }

    void TogglePlayer1()
    {
        Player1Ok = !Player1Ok; // Toggle de l'état
        Debug.Log("Player 1: " + (Player1Ok ? "Selected" : "Deselected"));
        ToggleValider();
    }

    void TogglePlayer2()
    {
        Player2Ok = !Player2Ok; // Toggle de l'état
        Debug.Log("Player 2: " + (Player2Ok ? "Selected" : "Deselected"));
        ToggleValider();
    }

    void TogglePlayer3()
    {
        Player3Ok = !Player3Ok; // Toggle de l'état
        Debug.Log("Player 3: " + (Player3Ok ? "Selected" : "Deselected"));
        ToggleValider();
    }

    void ToggleValider()
    {
        if (Player1Ok == true && Player2Ok == true && Player3Ok == true)
        {
            Valider.SetActive(true);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventaire : MonoBehaviour
{
    public int Wood;
    

    // Méthode pour ajouter du bois
    public void AddWood(int amount)
    {
        Wood += amount;
        Debug.Log(Wood.ToString());
    }

    // Méthode pour retirer du bois
    public void RemoveWood(int amount)
    {
        Wood = Mathf.Max(Wood - amount, 0); // Empêche des valeurs négatives
        Debug.Log(Wood.ToString());
    }
}

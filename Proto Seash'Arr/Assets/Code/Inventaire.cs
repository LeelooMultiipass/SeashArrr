using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventaire : MonoBehaviour
{
    public int Wood;
    public int Iron;
    public int Food;
    public int Rhum;
    public int Ragout;



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

    // Méthode pour ajouter du fer
    public void AddIron(int amount)
    {
        Iron += amount;
        Debug.Log(Iron.ToString());
    }

    // Méthode pour retirer du fer
    public void RemoveIron(int amount)
    {
        Iron = Mathf.Max(Iron - amount, 0); // Empêche des valeurs négatives
        Debug.Log(Iron.ToString());
    }

    // Méthode pour ajouter de la nourriture
    public void AddFood(int amount)
    {
        Food += amount;
        Debug.Log(Food.ToString());
    }

    // Méthode pour retirer de la nourriture
    public void RemoveFood(int amount)
    {
        Food = Mathf.Max(Food - amount, 0); // Empêche des valeurs négatives
        Debug.Log(Food.ToString());
    }

    // Méthode pour ajouter du rhum
    public void AddRhum(int amount)
    {
        Rhum += amount;
        Debug.Log(Rhum.ToString());
    }

    // Méthode pour retirer du rhum
    public void RemoveRhum(int amount)
    {
        Rhum = Mathf.Max(Rhum - amount, 0); // Empêche des valeurs négatives
        Debug.Log(Rhum.ToString());
    }

    // Méthode pour ajouter du ragoût
    public void AddRagout(int amount)
    {
        Ragout += amount;
        Debug.Log(Ragout.ToString());
    }

    // Méthode pour retirer du ragoût
    public void RemoveRagout(int amount)
    {
        Ragout = Mathf.Max(Ragout - amount, 0); // Empêche des valeurs négatives
        Debug.Log(Ragout.ToString());
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FoodCounter : MonoBehaviour
{
    // Référence au Text UI
    public TMP_Text foodText;
    // Référence à la classe Inventaire
    public Inventaire inventaire;

    void Start()
    {
        // Initialise le texte à la valeur actuelle de Wood
        UpdateFoodText();
    }

    // Méthode pour mettre à jour le texte
    public void UpdateFoodText()
    {
        foodText.text = "Food : " + inventaire.Wood;
    }

    void Update()
    {
        // Si nécessaire, mets à jour le texte à chaque frame
        UpdateFoodText();
    }
}

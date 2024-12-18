using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WoodCounter : MonoBehaviour
{
    // Référence au Text UI
    public TMP_Text woodText;
    // Référence à la classe Inventaire
    public Inventaire inventaire;

    void Start()
    {
        // Initialise le texte à la valeur actuelle de Wood
        UpdateWoodText();
    }

    // Méthode pour mettre à jour le texte
    public void UpdateWoodText()
    {
        woodText.text = "Wood : " + inventaire.Wood;
    }

    void Update()
    {
        // Si nécessaire, mets à jour le texte à chaque frame
        UpdateWoodText();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RhumCounter : MonoBehaviour
{
    // Référence au Text UI
    public TMP_Text rhumText;
    // Référence à la classe Inventaire
    public Inventaire inventaire;

    void Start()
    {
        // Initialise le texte à la valeur actuelle de Wood
        UpdateRhumText();
    }

    // Méthode pour mettre à jour le texte
    public void UpdateRhumText()
    {
        rhumText.text = "Rhum : " + inventaire.Rhum;
    }

    void Update()
    {
        // Si nécessaire, mets à jour le texte à chaque frame
        UpdateRhumText();
    }
}

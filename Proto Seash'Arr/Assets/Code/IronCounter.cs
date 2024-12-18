using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class IronCounter : MonoBehaviour
{
    // Référence au Text UI
    public TMP_Text ironText;
    // Référence à la classe Inventaire
    public Inventaire inventaire;

    void Start()
    {
        // Initialise le texte à la valeur actuelle de Wood
        UpdateIronText();
    }

    // Méthode pour mettre à jour le texte
    public void UpdateIronText()
    {
        ironText.text = "Iron : " + inventaire.Iron;
    }

    void Update()
    {
        // Si nécessaire, mets à jour le texte à chaque frame
        UpdateIronText();
    }
}

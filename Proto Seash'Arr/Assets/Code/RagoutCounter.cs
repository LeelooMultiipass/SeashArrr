using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RagoutCounter : MonoBehaviour
{
    // Référence au Text UI
    public TMP_Text ragoutText;
    // Référence à la classe Inventaire
    public Inventaire inventaire;

    void Start()
    {
        // Initialise le texte à la valeur actuelle de Wood
        UpdateRagoutText();
    }

    // Méthode pour mettre à jour le texte
    public void UpdateRagoutText()
    {
        ragoutText.text = "Ragout : " + inventaire.Ragout;
    }

    void Update()
    {
        // Si nécessaire, mets à jour le texte à chaque frame
        UpdateRagoutText();
    }
}

using System.Collections.Generic;
using UnityEngine;

public class SwipeCharacter : MonoBehaviour
{
    public List<GameObject> characters;
    private int currentIndex = 0;

    void Start()
    {
        // Assure que seul le premier personnage est actif au début
        UpdateCharacterVisibility();
    }

    public void ChangeCharacterUp()
    {
        characters[currentIndex].SetActive(false); // Désactive le personnage actuel
        currentIndex = (currentIndex + 1) % characters.Count; // Incrémente et boucle
        UpdateCharacterVisibility();
    }

    public void ChangeCharacterDown()
    {
        characters[currentIndex].SetActive(false); // Désactive le personnage actuel
        currentIndex = (currentIndex - 1 + characters.Count) % characters.Count; // Décrémente et boucle
        UpdateCharacterVisibility();
    }

    private void UpdateCharacterVisibility()
    {
        // Désactive tous les personnages pour éviter les doublons
        foreach (var character in characters)
        {
            character.SetActive(false);
        }

        // Active uniquement le personnage courant
        characters[currentIndex].SetActive(true);
    }
}
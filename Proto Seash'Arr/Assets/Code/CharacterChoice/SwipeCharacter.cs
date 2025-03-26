using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeCharacter : MonoBehaviour
{
    public List<GameObject> characters;
    private int currentIndex = 0;
    public InputAction Left;
    public InputAction Right;

    
    void Start()
    {
        // Assure que seul le premier personnage est actif au début
        UpdateCharacterVisibility();
    }

    private void OnEnable()
    {
        Left.Enable();
        Right.Enable();
        Left.started += ChangeCharacterDown;
        Right.started += ChangeCharacterUp;
    }

    private void OnDisable()
    {
        Left.started -= ChangeCharacterDown;
        Right.started -= ChangeCharacterUp;
        Left.Disable();
        Right.Disable();
    }


    public void ChangeCharacterUp(InputAction.CallbackContext context)
    {
        characters[currentIndex].SetActive(false); // Désactive le personnage actuel
        currentIndex = (currentIndex + 1) % characters.Count; // Incrémente et boucle
        UpdateCharacterVisibility();
    }

    public void ChangeCharacterDown(InputAction.CallbackContext context)
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
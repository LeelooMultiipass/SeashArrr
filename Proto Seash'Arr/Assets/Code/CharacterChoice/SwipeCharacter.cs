using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeCharacter : MonoBehaviour
{
    public List<GameObject> charactersPlayer2;
    public List<GameObject> charactersPlayer3;
    private int currentIndexPlayer2 = 0;
    private int currentIndexPlayer3 = 0;
    private PlayerInput playerInput;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Start()
    {
        if (playerInput.playerIndex == 0)
        {
            // Désactive les personnages du joueur 2 (Player 3)
            foreach (var character in charactersPlayer3)
            {
                character.SetActive(false);
            }

            // Affiche les personnages du joueur 1 (Player 2)
            UpdateCharacterVisibility2();
        }
        // Si c'est le joueur 2 (playerIndex == 1)
        else if (playerInput.playerIndex == 1)
        {
            // Désactive les personnages du joueur 1 (Player 2)
            foreach (var character in charactersPlayer2)
            {
                character.SetActive(false);
            }

            // Affiche les personnages du joueur 2 (Player 3)
            UpdateCharacterVisibility3();
        }

    }

    public void OnRight(InputAction.CallbackContext context)
    {
        if (playerInput == null)
        {
            Debug.LogWarning("PlayerInput is null on OnRight.");
            return;
        }

        if (context.started)
        {
            Debug.Log($"Player {playerInput.playerIndex} pressed RIGHT");
            ChangeCharacterUp(context);
        }
    }

    public void OnLeft(InputAction.CallbackContext context)
    {
        if (playerInput == null)
        {
            Debug.LogWarning("PlayerInput is null on OnLeft.");
            return;
        }

        if (context.started)
        {
            Debug.Log($"Player {playerInput.playerIndex} pressed LEFT");
            ChangeCharacterDown(context);
        }
    }

    public void ChangeCharacterUp(InputAction.CallbackContext context)
    {
        if (playerInput.playerIndex == 0)
        {
            charactersPlayer2[currentIndexPlayer2].SetActive(false);
            currentIndexPlayer2 = (currentIndexPlayer2 + 1) % charactersPlayer2.Count;
            UpdateCharacterVisibility2();
        }
        else if (playerInput.playerIndex == 1)
        {
            charactersPlayer3[currentIndexPlayer3].SetActive(false);
            currentIndexPlayer3 = (currentIndexPlayer3 + 1) % charactersPlayer3.Count;
            UpdateCharacterVisibility3();
        }
    }

    public void ChangeCharacterDown(InputAction.CallbackContext context)
    {
        if (playerInput.playerIndex == 0)
        {
            charactersPlayer2[currentIndexPlayer2].SetActive(false); // Désactive le personnage actuel
            currentIndexPlayer2 = (currentIndexPlayer2 - 1 + charactersPlayer2.Count) % charactersPlayer2.Count; // Décrémente et boucle
            UpdateCharacterVisibility2();
        }

        if (playerInput.playerIndex == 1)
        {
            charactersPlayer3[currentIndexPlayer3].SetActive(false); // Désactive le personnage actuel
            currentIndexPlayer3 = (currentIndexPlayer3 - 1 + charactersPlayer3.Count) % charactersPlayer3.Count; // Décrémente et boucle
            UpdateCharacterVisibility3();
        }

    }

    private void UpdateCharacterVisibility2()
    {
        // Désactive tous les personnages pour éviter les doublons
        foreach (var character in charactersPlayer2)
        {
            character.SetActive(false);
        }

        // Active uniquement le personnage courant
        charactersPlayer2[currentIndexPlayer2].SetActive(true);
    }


    private void UpdateCharacterVisibility3()
    {
        // Désactive tous les personnages pour éviter les doublons
        foreach (var character in charactersPlayer3)
        {
            character.SetActive(false);
        }

        // Active uniquement le personnage courant
        charactersPlayer3[currentIndexPlayer3].SetActive(true);
    }
}
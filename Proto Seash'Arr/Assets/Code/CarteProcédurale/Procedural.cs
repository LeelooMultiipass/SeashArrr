using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Procedural : MonoBehaviour
{
    private List<Vector3> predefinedPositions; // Liste des positions actuelles des boutons
    private List<Vector3> availablePositions; // Liste des positions disponibles pour le shuffle
    private List<GameObject> objectsToShuffle; // Liste des objets (boutons) à mélanger

    public GameObject BoatButton; // Référence au bouton du bateau
    public List<GameObject> IslandButtonsParent; // Conteneur des boutons des îles (si nécessaire)

    // Cette méthode sera appelée au lancement de la scène
    void Start()
    {
        // Trouver tous les boutons dans la scène
        objectsToShuffle = new List<GameObject>();
        Button[] buttons = FindObjectsOfType<Button>();

        // Ajouter les boutons à la liste et récupérer leurs positions actuelles
        predefinedPositions = new List<Vector3>(); // Initialiser la liste des positions
        foreach (Button button in buttons)
        {
            if (button.gameObject == BoatButton)
            {
                // Ne pas ajouter le bouton du bateau à la liste des objets à mélanger
                continue;
            }

            objectsToShuffle.Add(button.gameObject);
            predefinedPositions.Add(button.gameObject.transform.position); // Ajouter la position actuelle à la liste
        }

        // Vérifier si nous avons suffisamment de positions prédéfinies
        if (predefinedPositions.Count < objectsToShuffle.Count)
        {
            Debug.LogError("Il n'y a pas assez de positions prédéfinies pour tous les objets.");
            return;
        }

        // Initialiser la liste des positions disponibles avec les positions prédéfinies
        availablePositions = new List<Vector3>(predefinedPositions);

        // Mélanger et placer les objets (boutons) sauf le bouton du bateau
        ShuffleAndPlaceObjects();
    }

    // Cette méthode sera appelée pour mélanger et placer les objets
    void ShuffleAndPlaceObjects()
    {
        // Créer une copie de la liste des positions prédéfinies
        availablePositions = new List<Vector3>(predefinedPositions);

        // Mélange les objets à placer
        System.Random rand = new System.Random();
        for (int i = objectsToShuffle.Count - 1; i > 0; i--)
        {
            int j = rand.Next(0, i + 1);
            GameObject temp = objectsToShuffle[i];
            objectsToShuffle[i] = objectsToShuffle[j];
            objectsToShuffle[j] = temp;
        }

        // Assigner à chaque objet une position de la liste disponible
        List<Vector3> usedPositions = new List<Vector3>();

        foreach (GameObject obj in objectsToShuffle)
        {
            Vector3 chosenPosition;

            // Trouver une position valide pour chaque objet
            do
            {
                int randomIndex = Random.Range(0, availablePositions.Count);
                chosenPosition = availablePositions[randomIndex];

                // Vérifier si la position choisie est adjacente à une position déjà utilisée
                bool isAdjacent = false;
                foreach (Vector3 usedPosition in usedPositions)
                {
                    if (IsAdjacent(usedPosition, chosenPosition))
                    {
                        isAdjacent = true;
                        break;
                    }
                }

                // Si la position est adjacente à une autre, on essaie une autre position
            } while (usedPositions.Exists(pos => IsAdjacent(pos, chosenPosition)));

            // Placer l'objet à cette position
            obj.transform.position = chosenPosition;

            // Ajouter la position utilisée à la liste des positions utilisées
            usedPositions.Add(chosenPosition);

            // Enlever cette position de la liste des positions disponibles
            availablePositions.Remove(chosenPosition);
        }

        // Placer le BoatButton à sa position initiale ou dans une position spécifique
        BoatButton.transform.position = BoatButton.transform.position; // Vous pouvez définir une nouvelle position pour le BoatButton si nécessaire
    }

    // Méthode pour vérifier si deux positions sont adjacentes
    bool IsAdjacent(Vector3 pos1, Vector3 pos2)
    {
        // On considère les positions adjacentes si elles sont directement à gauche, à droite, en haut ou en bas
        return Mathf.Abs(pos1.x - pos2.x) <= 1f && Mathf.Abs(pos1.y - pos2.y) <= 1f && pos1 != pos2;
    }
}
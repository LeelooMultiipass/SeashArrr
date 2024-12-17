using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fight : MonoBehaviour
{
    public static List<Player> players = new List<Player>();
    public static List<Ennemy> ennemies = new List<Ennemy>();

    [Header("Boutons")]
    public GameObject BoutonAttaquer;
    public GameObject BoutonHeal;
    public GameObject BoutonFixBoat;
    public GameObject BoutonFixCanon;
    public GameObject BoutonCanon;
    public GameObject BoutonBoost;

    public bool playerTurn = true; // Indique si c'est le tour du joueur
    public bool monsterTurn = false;

    private void Start()
    {
        // Génère la liste des players
        Player player1 = new Player();
        Player player2 = new Player();
        Player player3 = new Player();
        
        players.Add(player1);
        players.Add(player2);
        players.Add(player3);
        
        // Génère la liste des ennemis (en fonction du temps in game)
        Ennemy ennemy1 = new Ennemy();
        Ennemy ennemy2 = new Ennemy();
        Ennemy ennemy3 = new Ennemy();
        Ennemy ennemy4 = new Ennemy();
        
        ennemies.Add(ennemy1);
        ennemies.Add(ennemy2);
        ennemies.Add(ennemy3);
        ennemies.Add(ennemy4);

        foreach (var ennemy in ennemies)
        {
            int i = Random.Range(0, 3);
            switch (i)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;

            }
        }
        
        
        // Randomise l'ordre
        
        
        // Met à jour les points de vie affichés au démarrage
        UpdateHealthText();
        
        // Début du combat
        
    }

    private void UpdateHealthText()
    {
        
    }
    
}
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public static List<Player> Players = new List<Player>();
    public static List<Ennemy> Ennemies = new List<Ennemy>();

    [SerializeField] private GameObject player1GO;
    [SerializeField] private GameObject player2GO;
    [SerializeField] private GameObject player3GO;

    [SerializeField] private GameObject fighterGO;
    [SerializeField] private GameObject destroyerGO;
    [SerializeField] private GameObject healerGO;
    [SerializeField] private GameObject aoeGO;
    [SerializeField] private GameObject bossGO;
    

    [SerializeField] private GameObject placeEnnemy1;
    [SerializeField] private GameObject placeEnnemy2;
    [SerializeField] private GameObject placeEnnemy3;
    [SerializeField] private GameObject placeEnnemy4;
    [SerializeField] private GameObject placeEnnemy5;

    public static Player Player1;
    public static Player Player2;
    public static Player Player3;

    public static Ennemy Ennemy1;
    public static Ennemy Ennemy2;
    public static Ennemy Ennemy3;
    public static Ennemy Ennemy4;
    public static Ennemy Ennemy5;
    
    

    public bool playerTurn = true; // Indique si c'est le tour du joueur
    public bool monsterTurn = false;

    private void Start()
    {
        // Génère la liste des players
        Player1 = player1GO.GetComponent(typeof(Player)) as Player;
        Player2 = player2GO.GetComponent(typeof(Player)) as Player;
        Player3 = player3GO.GetComponent(typeof(Player)) as Player;
        
        Players.Add(Player1);
        Players.Add(Player2);
        Players.Add(Player3);
        
        // Génère les ennemis (en fonction du temps in game)

        var prefabList = new List<GameObject>();
        prefabList.Add(fighterGO);
        prefabList.Add(destroyerGO);
        prefabList.Add(healerGO);
        prefabList.Add(aoeGO);

        var prefabIndice = Random.Range(0, 3);
        GameObject ennemy1GO = Instantiate(prefabList[prefabIndice], placeEnnemy1.transform);
        prefabIndice = Random.Range(0, 3);
        GameObject ennemy2GO = Instantiate(prefabList[prefabIndice], placeEnnemy2.transform);
        prefabIndice = Random.Range(0, 3);
        GameObject ennemy3GO = Instantiate(prefabList[prefabIndice], placeEnnemy3.transform);
        prefabIndice = Random.Range(0, 3);
        GameObject ennemy4GO = Instantiate(prefabList[prefabIndice], placeEnnemy4.transform);
        prefabIndice = Random.Range(0, 3);
        GameObject ennemy5GO = Instantiate(prefabList[prefabIndice], placeEnnemy5.transform);
        
        Ennemy1 = ennemy1GO.GetComponent(typeof(Ennemy)) as Ennemy;
        Ennemy2 = ennemy2GO.GetComponent(typeof(Ennemy)) as Ennemy;
        Ennemy3 = ennemy3GO.GetComponent(typeof(Ennemy)) as Ennemy;
        Ennemy4 = ennemy4GO.GetComponent(typeof(Ennemy)) as Ennemy;
        Ennemy5 = ennemy5GO.GetComponent(typeof(Ennemy)) as Ennemy;
        
        Ennemies.Add(Ennemy1);
        Ennemies.Add(Ennemy2);
        Ennemies.Add(Ennemy3);
        Ennemies.Add(Ennemy4);
        Ennemies.Add(Ennemy5);
        
        
        // Randomise l'ordre

        List<int> order = new List<int>();
        order.Add(Player1!.GetHP());
        order.Add(Player2!.GetHP());
        order.Add(Player3!.GetHP());
        order.Add(Ennemy1!.GetHP());
        order.Add(Ennemy2!.GetHP());
        order.Add(Ennemy3!.GetHP());
        order.Add(Ennemy4!.GetHP());
        order.Add(Ennemy5!.GetHP());
        
        System.Random rand = new System.Random();
        int p = order.Count();
        for (int n = p-1; n > 0 ; n--)
        {
            int r = rand.Next(1, n);
            (order[r], order[n]) = (order[n], order[r]);
        }

        for (int i = 0; i < order.Count(); i++)
        {
            Debug.Log(order[i]);
        }
        
        // Met à jour les points de vie affichés au démarrage
        UpdateHealthText();
        
        // Début du combat
        
    }

    private void UpdateHealthText()
    {
        
    }
    
}
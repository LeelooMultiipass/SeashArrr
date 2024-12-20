using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

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

    private List<MonoBehaviour> order = new List<MonoBehaviour>();
    private int turnIndex;
    private IEnumerator turn;
    public static bool isTurnOver = true;
    private bool isFightOver = false;

    public static bool IsCanonUsed;


    private void Awake()
    {
        Players.Clear();
        Ennemies.Clear();
        
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
        GameObject ennemy1Go = Instantiate(prefabList[prefabIndice], placeEnnemy1.transform);
        prefabIndice = Random.Range(0, 3);
        GameObject ennemy2Go = Instantiate(prefabList[prefabIndice], placeEnnemy2.transform);
        prefabIndice = Random.Range(0, 3);
        GameObject ennemy3Go = Instantiate(prefabList[prefabIndice], placeEnnemy3.transform);
        prefabIndice = Random.Range(0, 3);
        GameObject ennemy4Go = Instantiate(prefabList[prefabIndice], placeEnnemy4.transform);
        prefabIndice = Random.Range(0, 3);
        GameObject ennemy5Go = Instantiate(prefabList[prefabIndice], placeEnnemy5.transform);
        
        Ennemy1 = ennemy1Go.GetComponent(typeof(Ennemy)) as Ennemy;
        Ennemy2 = ennemy2Go.GetComponent(typeof(Ennemy)) as Ennemy;
        Ennemy3 = ennemy3Go.GetComponent(typeof(Ennemy)) as Ennemy;
        Ennemy4 = ennemy4Go.GetComponent(typeof(Ennemy)) as Ennemy;
        Ennemy5 = ennemy5Go.GetComponent(typeof(Ennemy)) as Ennemy;
        
        Ennemies.Add(Ennemy1);
        Ennemies.Add(Ennemy2);
        Ennemies.Add(Ennemy3);
        Ennemies.Add(Ennemy4);
        Ennemies.Add(Ennemy5);
    }
    private void Start()
    {
        // Randomise l'ordre
        
        order.Add(Player1!);
        order.Add(Player2!);
        order.Add(Player3!);
        order.Add(Ennemy1!);
        order.Add(Ennemy2!);
        order.Add(Ennemy3!);
        order.Add(Ennemy4!);
        order.Add(Ennemy5!);
        
        System.Random rand = new System.Random();
        for (int n = 0; n < order.Count ; n++)
        {
            int r = rand.Next(0, n);
            (order[r], order[n]) = (order[n], order[r]);
        }

        // DEBUG Order
        /*
        for (int i = 0; i < order.Count(); i++)
        {
            Debug.Log(order[i]);
        }
        */
        
        // Début du combat
        turnIndex = 0;
        turn = NextTurn();
       
        isTurnOver = false;
        StartCoroutine(turn);
        
        
    }

    IEnumerator NextTurn()
    {
        Debug.Log("C'est à " + order[turnIndex] + " de jouer");

        if (order[turnIndex].GetType() == typeof(Ennemy))
        {
            Ennemy ennemy = order[turnIndex] as Ennemy;
            
            switch (ennemy!.GetEnnemyType())
            {
                case Ennemy.EnnemyType.Fighter:
                    StartCoroutine(Ennemy.Fighter.Action());
                    break;
                case Ennemy.EnnemyType.Destroyer:
                    StartCoroutine(Ennemy.Destroyer.Action());
                    break;
                case Ennemy.EnnemyType.Healer:
                    StartCoroutine(Ennemy.Healer.Action());
                    break;
                case Ennemy.EnnemyType.AOE:
                    StartCoroutine(Ennemy.AOE.Action());
                    break;
                case Ennemy.EnnemyType.Boss:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        else
        {
            Player player = order[turnIndex] as Player;
            StartCoroutine(player!.Action());
        }
        
        while(!isTurnOver)
            yield return null;

        isTurnOver = false;
        StartCoroutine(turn);
    }

}
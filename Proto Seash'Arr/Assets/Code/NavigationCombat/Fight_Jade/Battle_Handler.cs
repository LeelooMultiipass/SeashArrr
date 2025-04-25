using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Battle_Handler : MonoBehaviour
{

    public static List<GameObject> Players = new List<GameObject>();
    public static List<GameObject> Ennemies = new List<GameObject>();
    public List<GameObject> turnOrder = new List<GameObject>();
    public Enemy enemyGestion;
    public Player playerGestion;

    // Start is called before the first frame update
    void Start()
    {
        Players.Clear();
        Ennemies.Clear(); 
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        Players.AddRange(playerObjects);
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        Ennemies.AddRange(enemyObjects);

        BuildTurnOrder();
    }

    private void BuildTurnOrder()
    {
        turnOrder.Clear();
        turnOrder.AddRange(Players);
        turnOrder.AddRange(Ennemies);
        ShuffleList(turnOrder);
    }

    // Méthode pour mélanger une liste de manière aléatoire
    private void ShuffleList(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            GameObject temp = list[i];
            int randomIndex = UnityEngine.Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}




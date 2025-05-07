using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Battle_Handler : MonoBehaviour
{
    public List<GameObject> Players = new List<GameObject>();
    public List<GameObject> Ennemies = new List<GameObject>();
    public List<GameObject> turnOrder = new List<GameObject>();
    private int currentTurnIndex = 0;
    public bool isBattleOver = false;
    public bool isTurnOver = false;


    void Start()
    {
        Players.Clear();
        Ennemies.Clear();

        // Find all player and enemy GameObjects
        Players.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        Ennemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));


        BuildTurnOrder();
        StartCoroutine(BattleLoop());
    }

    private void BuildTurnOrder()
    {
        turnOrder.Clear();
        turnOrder.AddRange(Players);
        turnOrder.AddRange(Ennemies);
        ShuffleList(turnOrder);
    }

    private void ShuffleList(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rand = Random.Range(i, list.Count);
            GameObject temp = list[i];
            list[i] = list[rand];
            list[rand] = temp;
        }
    }

    private IEnumerator BattleLoop()
    {
        yield return new WaitForSeconds(1f); // Small delay before starting

        while (!isBattleOver)
        {
            if (Players.Count == 0 || Ennemies.Count == 0)
            {
                Debug.Log("Battle Over!");
                isBattleOver = true;
                yield break;

            }

            GameObject currentUnit = turnOrder[currentTurnIndex];
            isTurnOver = false;

            if (currentUnit.CompareTag("Player"))
            {
                Player player = currentUnit.GetComponent<Player>();
                if (player != null && player.GetHP() > 0)
                {
                    yield return StartCoroutine(player.Action());
                }
                else
                {
                    isTurnOver = true;
                }
            }
            else if (currentUnit.CompareTag("Enemy"))
            {
                Enemy enemy = currentUnit.GetComponent<Enemy>();
                if (enemy != null)
                {
                    yield return StartCoroutine(EnemyTurn(enemy));
                }
                else
                {
                    isTurnOver = true;
                }
            }

            // Wait until action is complete
            while (!isTurnOver)
                yield return null;

            currentTurnIndex = (currentTurnIndex + 1) % turnOrder.Count;

            yield return new WaitForSeconds(0.5f); // Turn delay
        }
    }

    private IEnumerator EnemyTurn(Enemy enemy)
    {
        yield return new WaitForSeconds(0.5f);

        switch (enemy.type)
        {
            case Enemy.Type.Fighter:
                enemy.Attack();
                break;

            case Enemy.Type.Destroyer:
                enemy.CanonBoatAttack();
                break;

            case Enemy.Type.Healer:
                enemy.Heal();
                enemy.Boost();
                break;

            case Enemy.Type.AOE:
                enemy.AllAttack();
                break;

            case Enemy.Type.Boss:
                int choice = Random.Range(0, 3);
                if (choice == 0) enemy.AllAttack();
                else if (choice == 1) enemy.CanonBoatAttack();
                else enemy.Attack();
                break;
        }

        isTurnOver = true;
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fight : MonoBehaviour
{
    [Header("Player")]
    public int playerMaxHealth = 100;
    public int playerHealth;
    public int playerStrength = 25;
    public int playerHeal = 50;
    public TMP_Text playerHealthText;
    public List<GameObject> players = new List<GameObject>();

    [Header("Monster")]
    public int monsterMaxHealth = 100;
    public int monsterHealth;
    public int monsterStrength = 15;
    public int monsterDamageBoatCanon;
    public int monsterHeal;
    public int monsterBoost;
    public TMP_Text monsterHealthText;
    public List<GameObject> monsters = new List<GameObject>();

    [Header("Bâteau")]
    public int BoatHealth;

    [Header("Canon")]
    public int CanonHealth;
    public int CanonStrength;

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
        playerHealth = playerMaxHealth;
        monsterHealth = monsterMaxHealth;

        // Met à jour les points de vie affichés au démarrage
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        playerHealthText.text = playerHealth + " / " + playerMaxHealth;
        monsterHealthText.text = monsterHealth + " / " + monsterMaxHealth;
    }

    public void Attaquer()
    {
        if (playerTurn)
        {
            StartCoroutine(CoroutineAttaquer());
        }
    }

    IEnumerator CoroutineAttaquer()
    {
        // Le joueur attaque en premier
        BoutonAttaquer.SetActive(false);
        BoutonHeal.SetActive(false);
        monsterHealth -= playerStrength;
        UpdateHealthText();
        yield return new WaitForSeconds(1);

        // Vérifie si le monstre est vaincu
        if (monsterHealth <= 0)
        {
            Debug.Log("Monster defeated!");
            yield break; // Arrête la coroutine si le monstre est vaincu
        }

        // Passe au tour de l'ennemi
        playerTurn = false;
        monsterTurn = true;
        yield return StartCoroutine(EnemyTurn());
    }

    public void CanonFight()
    {
        if (playerTurn)
        {
            StartCoroutine(CoroutineCanon());
        }
    }

    IEnumerator CoroutineCanon()
    {
        // Le joueur attaque en premier
        BoutonCanon.SetActive(false);
        BoutonHeal.SetActive(false);
        monsterHealth -= CanonStrength;
        UpdateHealthText();
        yield return new WaitForSeconds(1);

        // Vérifie si le monstre est vaincu
        if (monsterHealth <= 0)
        {
            Debug.Log("Monster defeated!");
            yield break; // Arrête la coroutine si le monstre est vaincu
        }

        // Passe au tour de l'ennemi
        playerTurn = false;
        monsterTurn = true;
        yield return StartCoroutine(EnemyTurn());
    }

    public void Heal()
    {
        if (playerTurn)
        {
            StartCoroutine(CoroutineHeal());
        }
    }

    IEnumerator CoroutineHeal()
    {
        if (playerHealth < playerMaxHealth)
        {
            BoutonAttaquer.SetActive(false);
            BoutonHeal.SetActive(false);

            playerHealth = Mathf.Min(playerHealth + 50, playerMaxHealth);  // Soigne jusqu'au max
            UpdateHealthText();
            yield return new WaitForSeconds(1);

            // Passe au tour de l'ennemi
            playerTurn = false;
            monsterTurn = true;
            yield return StartCoroutine(EnemyTurn());
        }
        else
        {
            Debug.Log("Player health is already full, no healing applied.");
        }
    }

    IEnumerator EnemyTurn()
    {
        if (monsterTurn)
        {
            if (monsterHealth > monsterMaxHealth / 2)
            {
                // Attaque de l'ennemi
                yield return new WaitForSeconds(1);
                playerHealth -= monsterStrength;
                UpdateHealthText();
                Debug.Log("Enemy attacked! Player health: " + playerHealth);
                playerTurn = true;
                monsterTurn = false;

                // Vérifie si le joueur est vaincu
                if (playerHealth <= 0)
                {
                    Debug.Log("Player defeated!");
                    
                    yield break; // Arrête la coroutine si le joueur est vaincu
                }
            }

            else
            {
                // Heal
                yield return new WaitForSeconds(1);
                monsterHealth += 20;
                UpdateHealthText();
                Debug.Log("Enemy healed ! ");
                playerTurn = true;
                monsterTurn = false;

                // Vérifie si le joueur est vaincu
                if (playerHealth <= 0)
                {
                    Debug.Log("Player defeated!");
                    
                    yield break; // Arrête la coroutine si le joueur est vaincu
                }
            }

            
            BoutonAttaquer.SetActive(true);
            BoutonHeal.SetActive(true);
        }
    }
}
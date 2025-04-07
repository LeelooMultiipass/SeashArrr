using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ennemy : MonoBehaviour
{
    [SerializeField] private int HPMax;
    [SerializeField] private int ATT;
    [SerializeField] private int HealPower;
    [SerializeField] private int BoostPower;
    private bool boosted = false;

    private static int att;
    private static int heal;
    private static int boost;
    private static bool isBoosted;
    

    
    [SerializeField] private EnnemyType Type;
    private int HP;

    private List<Player> listPlayers = Fight.Players;
    private List<Ennemy> listEnnemies = Fight.Ennemies;
    
    public enum EnnemyType
    {
        Fighter,
        Destroyer,
        Healer,
        AOE,
        Boss
    }
    
    public static void AttackPlayer(Player target, int DMG)
    {
        target.SetHP(target.GetHP()-DMG);
        
        Debug.Log("J'attaque " + target + " !!!");
        
        if (isBoosted)
        {
            att -= boost;
            isBoosted = false;
        }

        UI_Manager.UiUpdateHealthBar();
    }

    public static void AttackAll(int DMG)
    {
        foreach (var player in Fight.Players)
        {
            player.SetHP(player.GetHP()-DMG);
        }
        
        Debug.Log("J'attaque tout le monde !!!");
        
        if (isBoosted)
        {
            att -= boost;
            isBoosted = false;
        }
    }

    public static void AttackBoat(int DMG)
    {
        // BoatHP - DMG
        Debug.Log("J'attaque le bateau !!!");
        
        if (isBoosted)
        {
            att -= boost;
            isBoosted = false;
        }
    }

    public static void AttackCanon(int DMG)
    {
        // CanonHP - DMG
        Debug.Log("J'attaque le canon !!!");
        
        if (isBoosted)
        {
            att -= boost;
            isBoosted = false;
        }
    }
    
    public class Fighter : Ennemy
    {
        public static IEnumerator Action()
        {
            Debug.Log("Je joue");
            
            var playerLow = false;
            foreach (var player in Fight.Players)
            {
                if (player.GetHP() <= att)
                {
                    AttackPlayer(player, att);
                    playerLow = true;
                    break;
                }
            }

            if (!playerLow)
            {
                AttackPlayer(Fight.Players[Random.Range(0, Fight.Players.Count)], att);
            }
            
            UI_Manager.UiUpdateHealthBar();
            Fight.isTurnOver = true;
            yield return null;
        }
    }

    public class Destroyer : Ennemy
    {
        public static IEnumerator Action()
        {
            Debug.Log("Je joue");
            var focus = Random.Range(1, 4);

            if (focus <= 3)
            {
                AttackBoat(att);
            }
            else
            {
                AttackCanon(att);
            }

            Fight.isTurnOver = true;
            yield return null;
        }
        
    }

    public class Healer : Ennemy
    {
        public static IEnumerator Action()
        {
            Debug.Log("Je joue");
            Ennemy target = null;
            int treshold = heal;
            bool ennemyLow = false;

            var tempList = Fight.Ennemies;
            foreach (var ennemy in tempList.ToList())
            {
                if (ennemy.Type == EnnemyType.Healer)
                    tempList.Remove(ennemy);
            }
            
            if(Fight.Ennemies.Count > 1)
            {
                foreach (var ennemy in Fight.Ennemies)
                {
                    var diff = ennemy.HPMax - ennemy.HP;
                    if (diff >= treshold)
                    {
                        target = ennemy;
                        treshold = diff;
                        ennemyLow = true;
                    }
                }

                if (ennemyLow)
                {
                    Heal(target);
                    Debug.Log("Je heal " + target);
                }
                else
                {
                    Boost(Fight.Ennemies[Random.Range(0, Fight.Ennemies.Count)]);
                    Debug.Log("Je boost " + target);
                }
            }
            else
            {
                AttackPlayer(Fight.Players[Random.Range(0,Fight.Players.Count)], att);
                Debug.Log("J'attaque un joueur");
            }

            Fight.isTurnOver = true;
            yield return null;
        }

        public static void Heal(Ennemy target)
        {
            target.HP += heal;
        }

        public static void Boost(Ennemy target)
        {
            att += boost;
        }
        
    }

    public class AOE : Ennemy
    {
        public static IEnumerator Action()
        {
            Debug.Log("Je joue");
            var chance = Random.Range(1, 100);

            if (chance <= 15)
            {
                att = 5;
            }
            else if (chance <= 50)
            {
                att = 10;
            }
            else if (chance <= 85)
            {
                att = 15;
            }
            else
            {
                att = 20;
            }
            
            AttackAll(att);
            Fight.isTurnOver = true;

            yield return null;
        }
    }

    public class Boss : Ennemy
    {

    }
    
    // Start is called before the first frame update
    void Start()
    {
        HP = HPMax;
        att = ATT;
        heal = HealPower;
        boost = BoostPower;
        isBoosted = boosted;
    }
    
    public int GetHP()
    {
        return HP;
    }

    public void SetHP(int newHP)
    {
        HP = newHP;
    }

    public int GetHPMax()
    {
        return HPMax;
    }

    public EnnemyType GetEnnemyType()
    {
        return Type;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

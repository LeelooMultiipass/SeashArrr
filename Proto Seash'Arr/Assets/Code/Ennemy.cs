using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ennemy : MonoBehaviour
{
    [SerializeField] private int HPMax;
    [SerializeField] private static int ATT;
    [SerializeField] private static int HealPower;
    [SerializeField] private static int BoostPower;
    private static bool boosted = false;

    
    [SerializeField] private static EnnemyType Type;
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
        
        if (boosted)
        {
            ATT -= BoostPower;
            boosted = false;
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
        
        if (boosted)
        {
            ATT -= BoostPower;
            boosted = false;
        }
    }

    public static void AttackBoat(int DMG)
    {
        // BoatHP - DMG
        Debug.Log("J'attaque le bateau !!!");
        
        if (boosted)
        {
            ATT -= BoostPower;
            boosted = false;
        }
    }

    public static void AttackCanon(int DMG)
    {
        // CanonHP - DMG
        Debug.Log("J'attaque le canon !!!");
        
        if (boosted)
        {
            ATT -= BoostPower;
            boosted = false;
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
                Debug.Log("player : " + player);
                if (player.GetHP() <= ATT)
                {
                    AttackPlayer(player, ATT);
                    playerLow = true;
                    break;
                }
            }

            if (!playerLow)
            {
                AttackPlayer(Fight.Players[Random.Range(0, Fight.Players.Count)], ATT);
            }
            
            UI_Manager.UiUpdateHealthBar();
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
                AttackBoat(ATT);
            }
            else
            {
                AttackCanon(ATT);
            }

            yield return null;
        }
        
    }

    public class Healer : Ennemy
    {
        public static IEnumerator Action()
        {
            Debug.Log("Je joue");
            Ennemy target = new Ennemy();
            int treshold = HealPower;
            bool ennemyLow = false;

            var tempList = Fight.Players;
            foreach (var ennemy in tempList.ToList())
            {
                if (Type == EnnemyType.Healer)
                    tempList.Remove(ennemy);
            }
            
            if(Fight.Players.Count > 1)
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
                }
                else
                {
                    Boost(Fight.Ennemies[Random.Range(0, Fight.Ennemies.Count)]);
                }
            }
            else
            {
                AttackPlayer(Fight.Players[Random.Range(0,Fight.Players.Count)], ATT);
            }

            yield return null;
        }

        public static void Heal(Ennemy target)
        {
            target.HP += HealPower;
        }

        public static void Boost(Ennemy target)
        {
            ATT += BoostPower;
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
                ATT = 5;
            }
            else if (chance <= 50)
            {
                ATT = 10;
            }
            else if (chance <= 85)
            {
                ATT = 15;
            }
            else
            {
                ATT = 20;
            }
            
            AttackAll(ATT);

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

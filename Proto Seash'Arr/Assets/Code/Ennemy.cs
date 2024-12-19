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
    
    public void AttackPlayer(Player target, int DMG)
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

    public void AttackAll(int DMG)
    {
        foreach (var player in listPlayers)
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

    public void AttackBoat(int DMG)
    {
        // BoatHP - DMG
        Debug.Log("J'attaque le bateau !!!");
        
        if (boosted)
        {
            ATT -= BoostPower;
            boosted = false;
        }
    }

    public void AttackCanon(int DMG)
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
        public IEnumerator Action()
        {
            Debug.Log("Je joue");
            
            var playerLow = false;
            foreach (var player in listPlayers)
            {
                if (player.GetHP() <= ATT)
                {
                    AttackPlayer(player, ATT);
                    playerLow = true;
                    break;
                }
            }

            if (!playerLow)
            {
                AttackPlayer(listPlayers[Random.Range(0, listPlayers.Count)], ATT);
            }
            
            UI_Manager.UiUpdateHealthBar();
            yield return null;
        }
    }

    public class Destroyer : Ennemy
    {
        public IEnumerator Action()
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
        public IEnumerator Action()
        {
            Debug.Log("Je joue");
            Ennemy target = new Ennemy();
            int treshold = HealPower;
            bool ennemyLow = false;

            var tempList = listEnnemies;
            foreach (var ennemy in tempList.ToList())
            {
                if (Type == EnnemyType.Healer)
                    tempList.Remove(ennemy);
            }
            
            if(listEnnemies.Count > 1)
            {
                foreach (var ennemy in listEnnemies)
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
                    Boost(listEnnemies[Random.Range(0, listEnnemies.Count)]);
                }
            }
            else
            {
                AttackPlayer(listPlayers[Random.Range(0,listPlayers.Count)], ATT);
            }

            yield return null;
        }

        public void Heal(Ennemy target)
        {
            target.HP += HealPower;
        }

        public void Boost(Ennemy target)
        {
            target.ATT += BoostPower;
        }
        
    }

    public class AOE : Ennemy
    {
        public IEnumerator Action()
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

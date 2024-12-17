using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Timeline;
using Random = UnityEngine.Random;

public class Ennemy : MonoBehaviour
{
    [SerializeField] private int HPMax;
    [SerializeField] private int ATT;
    [SerializeField] private int HealPower;
    [SerializeField] private int BoostPower;
    private bool boosted = false;

    
    [SerializeField] private EnnemyType Type;
    private int HP { get; set; }

    private List<Player> listPlayers = Fight.players;
    private List<Ennemy> listEnnemies = Fight.ennemies;
    
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
        
        if (boosted)
        {
            ATT -= BoostPower;
            boosted = false;
        }
    }

    public void AttackAll(int DMG)
    {
        foreach (var player in listPlayers)
        {
            player.SetHP(player.GetHP()-DMG);
        }
        
        if (boosted)
        {
            ATT -= BoostPower;
            boosted = false;
        }
    }

    public void AttackBoat(int DMG)
    {
        // BoatHP - DMG
        
        if (boosted)
        {
            ATT -= BoostPower;
            boosted = false;
        }
    }

    public void AttackCanon(int DMG)
    {
        // CanonHP - DMG
        
        if (boosted)
        {
            ATT -= BoostPower;
            boosted = false;
        }
    }
    
    public class Fighter : Ennemy
    {
        void Action()
        {
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
            
            //MAJ UI
        }
    }

    public class Destroyer : Ennemy
    {
        void Action()
        {
            var focus = Random.Range(1, 4);

            if (focus <= 3)
            {
                AttackBoat(ATT);
            }
            else
            {
                AttackCanon(ATT);
            }
        }
        
    }

    public class Healer : Ennemy
    {
        public void Action()
        {
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
        public void Action()
        {
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

    // Update is called once per frame
    void Update()
    {
        
    }

}

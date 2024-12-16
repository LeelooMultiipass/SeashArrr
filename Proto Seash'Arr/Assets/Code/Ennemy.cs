using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class Ennemy : MonoBehaviour
{

    public enum EnnemyType
    {
        Fighter,
        Destroyer,
        Healer,
        AOE,
        Boss
    }
    
    public class Fighter : Ennemy
    {
        [SerializeField] private int HPMax;
        [SerializeField] private int ATT;
        
        public void Attack()
        {
            target.SetHP(target.GetHP()-ATT);
        }
    }

    public class Destroyer : Ennemy
    {
        [SerializeField] private int HPMax;
        [SerializeField] private int ATT;

        public void Attack()
        {
            
        }
    }

    public class Healer : Ennemy
    {
        [SerializeField] private int HPMax;
        [SerializeField] private int HealPower;
        [SerializeField] private int BoostPercentage;
        [SerializeField] private int ATT;

        public void Action()
        {
            
        }

        public void Heal()
        {
            
        }

        public void Boost()
        {
            
        }

        public void Attack()
        {
            
        }
        
    }

    public class AOE : Ennemy
    {
        [SerializeField] private int HPMax;
        [SerializeField] private int ATT;

        public void Attack()
        {
            
        }
    }

    public class Boss : Ennemy
    {
        [SerializeField] private int HPMax;
        [SerializeField] private int ATT;
    }

    [SerializeField] private EnnemyType Type;
    private int HP { get; set; }

    private List<Player> listPlayers;
    private Player target;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

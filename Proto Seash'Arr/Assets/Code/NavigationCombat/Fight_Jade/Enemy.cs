using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{

    public enum Type
    {
        Fighter,
        Destroyer,
        Healer,
        AOE,
        Boss
    }

    private static int roleIndex = 0;

    [SerializeField] private int HPMax;
    [SerializeField] private int ATT;
    [SerializeField] private int CanonBoatATT;
    [SerializeField] private int AllATT;
    [SerializeField] private int HealPower;
    [SerializeField] private int BoostPower;
    

    private bool isBoosted;
    public Type type;
    public GameObject AxolotlPF;
    public GameObject MedusePF;
    public GameObject BlobFishPF;
    public GameObject CalamarPF;

    private Player player;
    private StatsManager statsManager;

    private int HP { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        switch (type)
        {
            case Type.Fighter:
                break;
            case Type.Destroyer:
                break;
            case Type.Healer:
                break;
            case Type.AOE:
                break;
        }
        
        AssignType();
        ChangePrefab();
        HP = HPMax;
        
    }

    //Bases pour randomiser le type de monstre et relier leurs stats et prefab dès leur instantiation

    private void AssignType()
    {
        roleIndex = UnityEngine.Random.Range(0, 4);

        // Définir le rôle basé sur l'index aléatoire
        type = (Type)roleIndex;
    }

    public void ChangePrefab()
    {
        if (roleIndex == 1)
        {
            AxolotlPF.SetActive(true);
            HPMax = 75;
            ATT = 25;
            CanonBoatATT = 0;
            AllATT = 0;
            HealPower = 0;
            BoostPower = 0;
        }
        if (roleIndex == 2)
        {
            CalamarPF.SetActive(true);
            HPMax = 100;
            ATT = 0;
            CanonBoatATT = 75;
            AllATT = 0;
            HealPower = 0;
            BoostPower = 0;
        }
        if (roleIndex == 3)
        {
            BlobFishPF.SetActive(true);
            HPMax = 75;
            ATT = 10;
            CanonBoatATT = 0;
            AllATT = 0;
            HealPower = 20;
            BoostPower = 15;
        }
        if (roleIndex == 4)
        {
            MedusePF.SetActive(true);
            HPMax = 75;
            ATT = 0;
            CanonBoatATT = 0;
            AllATT = 10;
            HealPower = 0;
            BoostPower = 0;
        }
    }

    public void Attack()
    {
        player.SetHP(HP -= ATT);
    }
    public void CanonBoatAttack()
    {
        var focus = Random.Range(1, 4);

        if (focus <= 3)
        {
            statsManager.boatHealth-=CanonBoatATT;
        }
        else
        {
            statsManager.canonHealth -= CanonBoatATT;
        }
    }

    public void AllAttack()
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

        Attack();
    }

    public void Boost()
    {
        isBoosted = true;
        ATT += BoostPower;
    }

    public void Heal()
    {
        HP += HealPower;
    }
}

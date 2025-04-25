using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public enum Role
    {
        Captain,
        //Cook,
       // Carpenter,
       // Engineer,
        Doctor,
        Fighter,
        //Cannonier
    }

    private static int roleIndex = 0;

    [SerializeField] private int HPMax;
    [SerializeField] private int ATT;
    [SerializeField] private int CanonPower;
    [SerializeField] private int HealPower;
    [SerializeField] private float BoostPower;
    [SerializeField] private int FixPower;
    [SerializeField] private UI_Manager UIManager;

    private bool isBoosted;
    public Role role;
    public GameObject CaptainPrefab;
    public GameObject DoctorPrefab;

    private int HP { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        // Set the good skin on the prefab
        switch (role)
        {
            case Role.Captain:
                break;
            //case Role.Cook:
              //  break;
            //case Role.Carpenter:
              //  break;
            //case Role.Engineer:
              //  break;
            case Role.Doctor:
                break;
            case Role.Fighter:
                break;
            //case Role.Cannonier:
              //  break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        HP = HPMax;
        AssignRole();
        ChangePrefab();

    }

    private void AssignRole()
    {
        // Définir le rôle basé sur l'index global
        role = (Role)roleIndex;

        // Incrémenter l'index global et revenir au début si nécessaire
        roleIndex = (roleIndex + 1) % Enum.GetValues(typeof(Role)).Length;
    }

        
    public void ChangePrefab()
    {
        if (roleIndex == 1)
            {
            CaptainPrefab.SetActive(true);
            ATT = 25;
            CanonPower = 10;
            HealPower = 50;
            BoostPower = 0.5f;
            FixPower = 100;
            }
        if (roleIndex == 2)
        {
            DoctorPrefab.SetActive(true);
            ATT = 25;
            CanonPower = 10;
            HealPower = 100;
            BoostPower = 0f;
            FixPower = 100;
        }
    }

    
    public IEnumerator Action()
    {
        (int, int) choice = UIManager.Starter(this);
        int action = choice.Item1;
        int target = choice.Item2;
        
        Debug.Log(action +"," +target);
        switch (action)
        {
            case 0: // Attaquer
                Attack(target);
                break;
            case 1: // Canon
                Canon();
                break;
            case 2: // Réparer
                Fix(target);
                break;
            case 3: // Soigner
                Heal(target);
                break;
            case 4: // Booster
                Boost(target);
                break;
        }

        yield return null;
    }
    

    private void Attack(int target)
    {
       /* Ennemy ennemy = Fight.Ennemies[target];
        ennemy.SetHP(ennemy.GetHP()-ATT);*/
       Debug.Log(Fight.Ennemies[target]);
       Fight.Ennemies[target].SetHP(Fight.Ennemies[target].GetHP()-ATT);
    }
    
    private void Canon()
    {
        if (!Fight.IsCanonUsed)
        {
            Fight.IsCanonUsed = true;
        }
        else
        {
            foreach (var ennemy in Fight.Ennemies)
            {
                ennemy.SetHP(ennemy.GetHP()-CanonPower);
            }
        }
    }

    private void Fix(int target)
    {
        switch (target)
        {
            case 0:
                // HEal bateau
                break;
            case 1:
                // Heal canon
                break;
        }
    }

    private void Heal(int target)
    {
        Player player = Fight.Players[target];
        player.SetHP(player.GetHP()+HealPower);
    }

    private void Boost(int target)
    {
        Fight.Players[target].isBoosted = true;
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

    public int GetRoleIndex()
    {
        return roleIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    [SerializeField] private UIManager UIManager;
    [SerializeField] private StatsManager statsManager;
    public Battle_Handler battleHandler;


    private bool isBoosted;
    public Role role;
    public GameObject CaptainPrefab;
    public GameObject DoctorPrefab;

    private int HP { get; set; }

    public InputAction AttackInput;
    public InputAction HealInput;
    public InputAction BoostInput;
    public InputAction CanonInput;
    public InputAction FixInput;

    private int currentTargetIndex;

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

        AttackInput.Enable();
        AttackInput.performed += OnAttack;

        HealInput.Enable();
        HealInput.performed += OnHeal;

        BoostInput.Enable();
        BoostInput.performed += OnBoost;

        CanonInput.Enable();
        CanonInput.performed += OnCanon;

        FixInput.Enable();
        FixInput.performed += OnFix;

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
            case 0: OnAttack(new InputAction.CallbackContext()); break;
            case 1: OnCanon(new InputAction.CallbackContext()); break;
            case 2: OnFix(new InputAction.CallbackContext()); break;
            case 3: OnHeal(new InputAction.CallbackContext()); break;
            case 4: OnBoost(new InputAction.CallbackContext()); break;
        }

        yield return null;
        battleHandler.isTurnOver = true;
    }


    private void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("Attacking with input...");
        var enemy = Fight.Ennemies[currentTargetIndex];
        enemy.SetHP(enemy.GetHP() - ATT);
    }

    private void OnCanon(InputAction.CallbackContext context)
    {
        if (!Fight.IsCanonUsed)
        {
            Fight.IsCanonUsed = true;
        }
        else
        {
            foreach (var enemy in Fight.Ennemies)
            {
                enemy.SetHP(enemy.GetHP() - CanonPower);
            }
        }
    }

    private void OnHeal(InputAction.CallbackContext context)
    {
        Player targetPlayer = Fight.Players[currentTargetIndex];
        targetPlayer.SetHP(targetPlayer.GetHP() + HealPower);
    }

    private void OnBoost(InputAction.CallbackContext context)
    {
        Fight.Players[currentTargetIndex].isBoosted = true;
    }


private void Fix(int target)
    {
        // 0 = boat, 1 = cannon
        switch (target)
        {
            case 0:
                statsManager.boatHealth += FixPower;
                Debug.Log("Fixed Boat for " + FixPower + " HP.");
                break;
            case 1:
                statsManager.canonHealth += FixPower;
                Debug.Log("Fixed Canon for " + FixPower + " HP.");
                break;
            default:
                Debug.LogWarning("Invalid target index for Fix");
                break;
        }
    }

    private void OnFix(InputAction.CallbackContext context)
    {
        Debug.Log("Fixing target " + currentTargetIndex);
        Fix(currentTargetIndex);
    }

    void OnDestroy()
    {
        AttackInput.performed -= OnAttack;
        HealInput.performed -= OnHeal;
        BoostInput.performed -= OnBoost;
        CanonInput.performed -= OnCanon;
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

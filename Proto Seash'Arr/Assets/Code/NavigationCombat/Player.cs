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
    [SerializeField]public GameObject UIBattle; 
    [SerializeField] public GameObject UIBattleItems;
    [SerializeField] public GameObject UIBattleFix;

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
    public InputAction ItemInput;
    public InputAction CanonFixInput;
    public InputAction BoatFixInput;
    public InputAction Annuler;

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

        GameObject playerObject = GameObject.FindGameObjectWithTag("StatsManager");
        GameObject battleManager = GameObject.FindGameObjectWithTag("BattleManager");
        GameObject UIManagerObject = GameObject.FindGameObjectWithTag("BattleManager");

        statsManager = playerObject.GetComponent<StatsManager>();
        UIManager = UIManagerObject.GetComponent<UIManager>();
        battleHandler = battleManager.GetComponent<Battle_Handler>();

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

        ItemInput.Enable();
        ItemInput.performed += OnItem;

        CanonFixInput.Enable();
        CanonFixInput.performed += OnCanonFix;

        BoatFixInput.Enable();
        BoatFixInput.performed += OnBoatFix;

        Annuler.Enable();
        Annuler.performed += OnCancel;

        UIBattle.SetActive(false);
        UIBattleItems.SetActive(false);
       
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
        if(statsManager.Fight == true)
        {
            UIBattle.SetActive(true);
            (int, int) choice = UIManager.Starter(this);
            int action = choice.Item1;
            int target = choice.Item2;

            Debug.Log(action + "," + target);
            switch (action)
            {
                case 0: OnAttack(new InputAction.CallbackContext()); break;
                case 1: OnCanon(new InputAction.CallbackContext()); break;
                case 2: OnFix(new InputAction.CallbackContext()); break;
                case 3: OnItem(new InputAction.CallbackContext()); break;
            }

            yield return null;
            battleHandler.isTurnOver = true;
        }
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

    private void OnItem(InputAction.CallbackContext context)
    {
        UIBattle.SetActive(false);
        UIBattleItems.SetActive(true);
    }

    private void OnHeal(InputAction.CallbackContext context)
    {
        if(UIBattleItems.activeInHierarchy)
        {
            Player targetPlayer = Fight.Players[currentTargetIndex];
            targetPlayer.SetHP(targetPlayer.GetHP() + HealPower);
        }
        
    }

    private void OnBoost(InputAction.CallbackContext context)
    {
        if(UIBattleItems.activeInHierarchy)
        {
            Fight.Players[currentTargetIndex].isBoosted = true;
        }
        
    }

    private void OnFix(InputAction.CallbackContext context)
    {
        UIBattle.SetActive(false);
        UIBattleFix.SetActive(true);
    }

    private void OnCanonFix(InputAction.CallbackContext context)
    {
        if(UIBattleFix.activeInHierarchy)
        {
            statsManager.canonHealth += FixPower;
            Debug.Log("Fixed Canon for " + FixPower + " HP.");
        }
    }

    private void OnBoatFix(InputAction.CallbackContext context)
    {
        if (UIBattleFix.activeInHierarchy)
        {
            statsManager.boatHealth += FixPower;
            Debug.Log("Fixed Boat for " + FixPower + " HP.");
        }
    }

    private void OnCancel(InputAction.CallbackContext context)
    {
        if (UIBattleFix.activeInHierarchy)
        {
            UIBattleFix.SetActive(!true);
            UIBattle.SetActive(true);
        }

        else if (UIBattleItems.activeInHierarchy)
        {
            UIBattleItems.SetActive(!true);
            UIBattle.SetActive(true);
        }
    }

    void OnDestroy()
    {
        AttackInput.performed -= OnAttack;
        HealInput.performed -= OnHeal;
        BoostInput.performed -= OnBoost;
        CanonInput.performed -= OnCanon;
        FixInput.performed -= OnFix;
        ItemInput.performed -= OnItem;
        CanonFixInput.performed -= OnCanonFix;
        BoatFixInput.performed -= OnBoatFix;
        Annuler.performed -= OnCancel;

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

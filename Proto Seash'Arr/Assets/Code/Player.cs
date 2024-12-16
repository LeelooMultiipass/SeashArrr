using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public enum Role
    {
        Captain,
        Cook,
        Carpenter,
        Engineer,
        Doctor,
        Fighter,
        Cannonier
    }

    [SerializeField] private int HPMax;
    public Role role;

    private int HP;
    
    // Start is called before the first frame update
    void Start()
    {
        // Set the good skin on the prefab
        switch (role)
        {
            case Role.Captain:
                break;
            case Role.Cook:
                break;
            case Role.Carpenter:
                break;
            case Role.Engineer:
                break;
            case Role.Doctor:
                break;
            case Role.Fighter:
                break;
            case Role.Cannonier:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
    }

    public int GetHP()
    {
        return HP;
    }

    public void SetHP(int newHP)
    {
        HP = newHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

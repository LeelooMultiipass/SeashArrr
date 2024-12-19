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

    public List<Material> CharactersRoles;
    private static int roleIndex = 0;

    [SerializeField] private int HPMax;
    [SerializeField] private int ATT;
    [SerializeField] private int CanonPower;
    [SerializeField] private int HealPower;
    [SerializeField] private int BoostPower;
    [SerializeField] private int FixPower;

    private bool isBoosted;
    public Role role;

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
        AssignMaterial();

    }

    private void AssignRole()
    {
        // Définir le rôle basé sur l'index global
        role = (Role)roleIndex;

        // Incrémenter l'index global et revenir au début si nécessaire
        roleIndex = (roleIndex + 1) % Enum.GetValues(typeof(Role)).Length;
    }

    private void AssignMaterial()
    {
        // Vérifier que la liste des matériaux contient suffisamment d'éléments
        if (CharactersRoles.Count > 0 && TryGetComponent<Renderer>(out Renderer renderer))
        {
            int roleMaterialIndex = (int)role;

            if (roleMaterialIndex >= 0 && roleMaterialIndex < CharactersRoles.Count)
            {
                // Appliquer le matériau correspondant au rôle
                renderer.material = CharactersRoles[roleMaterialIndex];
            }
            else
            {
                Debug.LogWarning("Pas de matériau disponible pour ce rôle.");
            }
        }
        else
        {
            Debug.LogWarning("Pas de matériaux ou Renderer non trouvé.");
        }
    }

    
    public IEnumerator Action()
    {
        (int, int) choice = UI_Manager.Starter(this);
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

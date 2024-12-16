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

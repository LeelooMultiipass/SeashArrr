using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{

    [SerializeField] private Image  _Player1_Hp;
    [SerializeField] private  Image _Player2_Hp;
    [SerializeField] private  Image _Player3_Hp;
    
    [SerializeField] private  Image _Ennemy1_Hp;
    [SerializeField] private  Image _Ennemy2_Hp;
    [SerializeField] private  Image _Ennemy3_Hp;
    [SerializeField] private  Image _Ennemy4_Hp;
    [SerializeField] private  Image _Ennemy5_Hp;
    
    [SerializeField] private  GameObject _ChoixJoueur1;
    [SerializeField] private  GameObject _ChoixJoueur2;
    [SerializeField] private  GameObject _ChoixJoueur3;
    
    [SerializeField] private  GameObject _Confirmation;
    [SerializeField] private  GameObject _ChoixReparer;
    [SerializeField] private  GameObject _ChoixItem;
    
    public static  Image Player1_Hp;
    public static  Image Player2_Hp;
    public static  Image Player3_Hp;
    
    public static  Image Ennemy1_Hp;
    public static  Image Ennemy2_Hp;
    public static  Image Ennemy3_Hp;
    public static  Image Ennemy4_Hp;
    public static  Image Ennemy5_Hp;
    
    public static  GameObject ChoixJoueur1;
    public static  GameObject ChoixJoueur2;
    public static  GameObject ChoixJoueur3;
    public static  GameObject Confirmation;
    public static  GameObject ChoixReparer;
    public static  GameObject ChoixItem;

    public static float testHP = 100f;
 
    
    // Start is called before the first frame update
    void Start()
    {
        Player1_Hp = _Player1_Hp;
        Player2_Hp = _Player2_Hp;
        Player3_Hp = _Player3_Hp;
        
        Ennemy1_Hp = _Ennemy1_Hp;
        Ennemy2_Hp = _Ennemy2_Hp;
        Ennemy3_Hp = _Ennemy3_Hp;
        Ennemy4_Hp = _Ennemy4_Hp;
        Ennemy5_Hp = _Ennemy5_Hp;
        
        ChoixJoueur1 = _ChoixJoueur1;
        ChoixJoueur2 = _ChoixJoueur2;
        ChoixJoueur3 = _ChoixJoueur3;
        
        Confirmation = _Confirmation;
        ChoixReparer = _ChoixReparer;
        ChoixItem = _ChoixItem;
        
        ChoixJoueur1.SetActive(false);
        ChoixJoueur2.SetActive(false);
        ChoixJoueur3.SetActive(false);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0 && ChoixJoueur1.activeInHierarchy)
        {
            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _choixJoueur1();
        }

        if (Input.GetMouseButtonDown(0))
        {
            _choixJoueur2();
         
        }
        if (Input.GetMouseButtonDown(1))
        {
            _choixJoueur3();
        }
        
        
    }

    public static void UiUpdateHealthBar()
    {
        var _player1CurentHp = testHP;
        var _playerMaxHp = Fight.Player1.GetHPMax();
        Player1_Hp.fillAmount = _player1CurentHp / _playerMaxHp;

        var _player2CurentHp = Fight.Player2.GetHP();
        Player2_Hp.fillAmount = _player2CurentHp / _playerMaxHp;

        var _player3CurentHp = Fight.Player3.GetHP();
        Player3_Hp.fillAmount = _player2CurentHp / _playerMaxHp;


        var _ennemy1CurentHp = Fight.Ennemy1.GetHP();
        var _ennemy1MaxHp = Fight.Ennemy1.GetHPMax();
        Ennemy1_Hp.fillAmount = _ennemy1CurentHp / _ennemy1MaxHp;

        var _ennemy2CurentHp = Fight.Ennemy2.GetHP();
        var _ennemy2MaxHp = Fight.Ennemy2.GetHPMax();
        Ennemy2_Hp.fillAmount = _ennemy2CurentHp / _ennemy2MaxHp;

        var _ennemy3CurentHp = Fight.Ennemy3.GetHP();
        var _ennemy3MaxHp = Fight.Ennemy3.GetHPMax();
        Ennemy3_Hp.fillAmount = _ennemy3CurentHp / _ennemy3MaxHp;

        var _ennemy4CurentHp = Fight.Ennemy4.GetHP();
        var _ennemy4MaxHp = Fight.Ennemy4.GetHPMax();
        Ennemy4_Hp.fillAmount = _ennemy4CurentHp / _ennemy4MaxHp;

        var _ennemy5CurentHp = Fight.Ennemy5.GetHP();
        var _ennemy5MaxHp = Fight.Ennemy5.GetHPMax();
        Ennemy5_Hp.fillAmount = _ennemy5CurentHp / _ennemy5MaxHp;
    }

    public static void _choixJoueur1()
    {
        ChoixJoueur1.SetActive(true);
        ChoixJoueur2.SetActive(false);  
        ChoixJoueur3.SetActive(false);
    }
    
    public static void _choixJoueur2()
    {
        ChoixJoueur2.SetActive(true);
        ChoixJoueur1.SetActive(false);  
        ChoixJoueur3.SetActive(false);
    }
    
    public static void _choixJoueur3()
    {
        ChoixJoueur3.SetActive(true);
        ChoixJoueur2.SetActive(false);  
        ChoixJoueur1.SetActive(false);
    }

    public static void _choixReparer()
    {
        ChoixReparer.SetActive(true);
        
    }
}
    

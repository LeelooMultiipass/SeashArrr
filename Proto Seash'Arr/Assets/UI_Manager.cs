using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{

    [Header ("Les Barres d'Hp")]
    
    [SerializeField] private Image  _Player1_Hp;
    [SerializeField] private  Image _Player2_Hp;
    [SerializeField] private  Image _Player3_Hp;
    
    [SerializeField] private  Image _Ennemy1_Hp;
    [SerializeField] private  Image _Ennemy2_Hp;
    [SerializeField] private  Image _Ennemy3_Hp;
    [SerializeField] private  Image _Ennemy4_Hp;
    [SerializeField] private  Image _Ennemy5_Hp;
    
    [Header ("Buttons Choix")]
    
    [SerializeField] private  GameObject _ChoixJoueurs;
    [SerializeField] private  GameObject _Confirmation;
    [SerializeField] private  GameObject _ChoixReparer;
    [SerializeField] private  GameObject _ChoixItem;
    [SerializeField] private  GameObject _CibleAttaque;
    [SerializeField] private  GameObject _CibleSoin;
    
    public static  Image Player1_Hp;
    public static  Image Player2_Hp;
    public static  Image Player3_Hp;
    
    public static  Image Ennemy1_Hp;
    public static  Image Ennemy2_Hp;
    public static  Image Ennemy3_Hp;
    public static  Image Ennemy4_Hp;
    public static  Image Ennemy5_Hp;
    
    
    
    public static  GameObject ChoixJoueurs;
    public static  GameObject Confirmation;
    public static  GameObject ChoixReparer;
    public static  GameObject ChoixItem;
    public static  GameObject PNG_CibleAttaque;
    public static  GameObject PNG_CibleSoin;

    private bool _choiceMade = false;
    

    public static float testHP = 100f;
    
    [Header ("La position des choix Allié")]
    
    [SerializeField] private Vector3 ChoixJoueursPos1; 
    [SerializeField] private Vector3 ChoixJoueursPos2;
    [SerializeField] private Vector3 ChoixJoueursPos3;
    
    [Header ("La position des choix Allié")]
    
    [SerializeField] private Vector3 Ancrage_pos1;
    [SerializeField] private Vector3 Ancrage_pos2;
    [SerializeField] private Vector3 Ancrage_pos3;
    
    [Header ("La position des ennemies")]
    
    [SerializeField] private Vector3 Ennemy_pos1;
    [SerializeField] private Vector3 Ennemy_pos2;
    [SerializeField] private Vector3 Ennemy_pos3;
    [SerializeField] private Vector3 Ennemy_pos4;
    [SerializeField] private Vector3 Ennemy_pos5;
    
    int CurrentPlayer = 0;
    private int INT_CibleEnnemies = 1;
    private int INT_CibleSoin = 1;
    private bool AttackUsed = false;
    private bool ReparerUsed = false;
    private bool ItemUsed = false;
    private bool CanonUsed = false;
    private bool RagoutUsed = false;
    private bool RhumUsed = false;
    private bool BateauUsed = false;
    private bool RepCanonUsed = false;
    private bool UsedAction = false;
    public static int _actionUsed = 0;
    public static int _target = 0;
    
    
   
 
    
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
        
        ChoixJoueurs = _ChoixJoueurs;
        Confirmation = _Confirmation;
        ChoixReparer = _ChoixReparer;
        ChoixItem = _ChoixItem;
        PNG_CibleAttaque = _CibleAttaque;
        PNG_CibleSoin = _CibleSoin;
        
        ChoixJoueurs.SetActive(false);
        ChoixItem.SetActive(false);
        ChoixReparer.SetActive(false);
        Confirmation.SetActive(false);
        PNG_CibleAttaque.SetActive(false);
        PNG_CibleSoin.SetActive(false);
        
        ChoixJoueursPos1 = new Vector3(-260, 25, 0);
        ChoixJoueursPos2 = new Vector3(-170, -30, 0);
        ChoixJoueursPos3 = new Vector3(-70, -100, 0);
        
        Ancrage_pos1 = new Vector3(0f, 0f, 0f);
        Ancrage_pos2 = new Vector3(85f, -60f, 0f);
        Ancrage_pos3 = new Vector3(180f, -140f, 0f);
        
        
        Ennemy_pos1 = new Vector3(-50f, 100f, 0f);
        Ennemy_pos2 = new Vector3(20f, 90f, 0f);
        Ennemy_pos3 = new Vector3(80f, 70f, 0f);
        Ennemy_pos4 = new Vector3(145f, 45f, 0f);
        Ennemy_pos5 = new Vector3(235f, 20f, 0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // Choix du jouer de base quand c'est à son tour 
        //----------------------------------------------------------
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
        //-----------------------------------------------------------
       */
        
        
        
        // Si le joueur choisi "Item" 
        //-----------------------------------------------------------
        if (Input.GetKeyUp(KeyCode.UpArrow) && CurrentPlayer == 1 && ChoixReparer.activeInHierarchy == false && Confirmation.activeInHierarchy == false && ChoixJoueurs.activeInHierarchy)
        {
            _choixItem1();
            ItemUsed = true;
            UsedAction = true;
        }
        
        if (Input.GetKeyUp(KeyCode.UpArrow) && CurrentPlayer == 2 && ChoixReparer.activeInHierarchy == false && Confirmation.activeInHierarchy == false && ChoixJoueurs.activeInHierarchy)
        {
            _choixItem2();
            ItemUsed = true;
            UsedAction = true;
        }
        
        if (Input.GetKeyUp(KeyCode.UpArrow) && CurrentPlayer == 3 && ChoixReparer.activeInHierarchy == false && Confirmation.activeInHierarchy == false && ChoixJoueurs.activeInHierarchy)
        {
            _choixItem3();
            ItemUsed = true;
            UsedAction = true;
        }
        //-----------------------------------------------------------
        
        
        
        
        
        
        
        
        // Si le jouer choisi le râgout
        //-----------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.LeftArrow) && CurrentPlayer == 1 && ChoixItem.activeInHierarchy && ItemUsed == true)
        {
            _ChoixConfirmation1();
            RagoutUsed = true;
            PNG_CibleSoin.SetActive(true);
            _actionUsed = 3;
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && CurrentPlayer == 2 && ChoixItem.activeInHierarchy && ItemUsed == true)
        {
            _ChoixConfirmation2();
            RagoutUsed = true;
            PNG_CibleSoin.SetActive(true);
            _actionUsed = 3;
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && CurrentPlayer == 3 && ChoixItem.activeInHierarchy && ItemUsed == true)
        {
            _ChoixConfirmation3();
            RagoutUsed = true;
            PNG_CibleSoin.SetActive(true);
            _actionUsed = 3;
        }
        //-----------------------------------------------------------
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        // SI le jouer choisi le rhum
        //-----------------------------------------------------------
        if (Input.GetKeyUp(KeyCode.DownArrow) && CurrentPlayer == 1 && ChoixItem.activeInHierarchy && ItemUsed == true)
        {
            _ChoixConfirmation1();
            RhumUsed = true;
            PNG_CibleSoin.SetActive(true);
            _actionUsed = 4;
        }
        
        if (Input.GetKeyUp(KeyCode.DownArrow) && CurrentPlayer == 2 && ChoixItem.activeInHierarchy && ItemUsed == true)
        {
            _ChoixConfirmation2();
            RhumUsed = true; 
            PNG_CibleSoin.SetActive(true);
            _actionUsed = 4;
        }
        
        if (Input.GetKeyUp(KeyCode.DownArrow) && CurrentPlayer == 3 && ChoixItem.activeInHierarchy && ItemUsed == true)
        {
            _ChoixConfirmation3();
            RhumUsed = true;
            PNG_CibleSoin.SetActive(true);
            _actionUsed = 4;
        }
        //-----------------------------------------------------------
            
            
            
            
        
        
        
        
        // Le joueur choisi sa cible pour le soin/boost 
        //-----------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.LeftArrow) && ItemUsed == true && INT_CibleSoin > 1)
        {
            INT_CibleSoin -= 1;
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow) && ItemUsed == true && INT_CibleSoin < 3)
        {
            INT_CibleSoin += 1;
        }

        if (INT_CibleSoin == 1)
        {
            CibleSoin1();
            _target = 0;
            
        }

        if (INT_CibleSoin == 2)
        {
            CibleSoin2();
            _target = 1;
        }

        if (INT_CibleSoin == 3)
        {
            CibleSoin3();
            _target = 2;
        }
        
        
        
        // Si le joueur choisi "Réparer"
        //-----------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.LeftArrow) && CurrentPlayer == 1 && ChoixItem.activeInHierarchy == false && Confirmation.activeInHierarchy == false && ChoixJoueurs.activeInHierarchy)
        {
            _choixReparer1();
            ReparerUsed = true;
            UsedAction = true;
            _actionUsed = 2;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) && CurrentPlayer == 2 && ChoixItem.activeInHierarchy == false && Confirmation.activeInHierarchy == false && ChoixJoueurs.activeInHierarchy)
        {
            _choixReparer2();
            ReparerUsed = true;
            UsedAction = true;
            _actionUsed = 2;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) && CurrentPlayer == 3 && ChoixItem.activeInHierarchy == false && Confirmation.activeInHierarchy == false && ChoixJoueurs.activeInHierarchy)
        {
            _choixReparer3();
            ReparerUsed = true;
            UsedAction = true;
            _actionUsed = 2;
        }
        //-----------------------------------------------------------
        
        
        
        
        
        
        
        
        
        
        // SI le jouer Répoare le Bateau 
        //-----------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.UpArrow) && CurrentPlayer == 1 && ChoixReparer.activeInHierarchy && ReparerUsed == true)
        {
            _ChoixConfirmation1();
            BateauUsed = true;
            _target = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && CurrentPlayer == 2 && ChoixReparer.activeInHierarchy && ReparerUsed == true)
        {
            _ChoixConfirmation2();
            BateauUsed = true;
            _target = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && CurrentPlayer == 3 && ChoixReparer.activeInHierarchy && ReparerUsed == true)
        {
            _ChoixConfirmation3();
            BateauUsed = true;
            _target = 0;
        }
        //-----------------------------------------------------------
        
        
        
        
        
        
        
        
        
        
        // SI le joueur Répoare le Canon 
        //-----------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.DownArrow) && CurrentPlayer == 1 && ChoixReparer.activeInHierarchy && ReparerUsed == true)
        {
            _ChoixConfirmation1();
            RepCanonUsed = true;
            _target = 1;
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow) && CurrentPlayer == 2 && ChoixReparer.activeInHierarchy && ReparerUsed == true)
        {
            _ChoixConfirmation2();
            RepCanonUsed = true;
            _target = 1;
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow) && CurrentPlayer == 3 && ChoixReparer.activeInHierarchy && ReparerUsed == true)
        {
            _ChoixConfirmation3();
            RepCanonUsed = true;
            _target = 1;
        }
        //-----------------------------------------------------------
        
        
        
        
        
        
        
        
        // Si le joueur choisi "Attaquer"
        //-----------------------------------------------------------
        if (Input.GetKeyUp(KeyCode.RightArrow) && CurrentPlayer == 1 && ChoixItem.activeInHierarchy == false && ChoixReparer.activeInHierarchy == false && ChoixJoueurs.activeInHierarchy)
        {
            _ChoixConfirmation1();
            AttackUsed = true;
            UsedAction = true;
            PNG_CibleAttaque.SetActive(true);
            _actionUsed = 0;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && CurrentPlayer == 2 && ChoixItem.activeInHierarchy == false && ChoixReparer.activeInHierarchy == false && ChoixJoueurs.activeInHierarchy)
        {
            _ChoixConfirmation2();
            AttackUsed = true;
            UsedAction = true;
            PNG_CibleAttaque.SetActive(true);
            _actionUsed = 0;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && CurrentPlayer == 3 && ChoixItem.activeInHierarchy == false && ChoixReparer.activeInHierarchy == false && ChoixJoueurs.activeInHierarchy)
        {
            _ChoixConfirmation3();
            AttackUsed = true;
            UsedAction = true;
            PNG_CibleAttaque.SetActive(true);
            _actionUsed = 0;
        }
        //-----------------------------------------------------------
        
        
        
        
        
        
        
        
        
        
        
        
        // Le Joueur choisi sa cible d'attaque
        //-----------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.LeftArrow) && AttackUsed && INT_CibleEnnemies > 1)
        {
            INT_CibleEnnemies = INT_CibleEnnemies - 1;
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow) && AttackUsed && INT_CibleEnnemies < 5)
        {
            INT_CibleEnnemies = INT_CibleEnnemies + 1;
        }

        if (INT_CibleEnnemies == 1)
        {
            CibleEnnemy1();
        }

        if (INT_CibleEnnemies == 2)
        {
            CibleEnnemy2();
        }

        if (INT_CibleEnnemies == 3)
        {
            CibleEnnemy3();
        }

        if (INT_CibleEnnemies == 4)
        {
            CibleEnnemy4();
        }

        if (INT_CibleEnnemies == 5)
        {
            CibleEnnemy5();
        }
        //-----------------------------------------------------------
        
        
        
        
        
        
        
        
        
        
        // si le joueur choisi "Canon"
        //-----------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.DownArrow) && CurrentPlayer == 1 && ChoixReparer.activeInHierarchy == false && Confirmation.activeInHierarchy == false && ChoixJoueurs.activeInHierarchy)
        {
            _ChoixConfirmation1();
            CanonUsed = true;
            UsedAction = true;
            _actionUsed = 1;
            _target = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow) && CurrentPlayer == 2 && ChoixReparer.activeInHierarchy == false && Confirmation.activeInHierarchy == false && ChoixJoueurs.activeInHierarchy)
        {
            _ChoixConfirmation2();
            CanonUsed = true;
            UsedAction = true;
            _actionUsed = 1;
            _target = 0;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && CurrentPlayer == 3 && ChoixReparer.activeInHierarchy == false && Confirmation.activeInHierarchy == false && ChoixJoueurs.activeInHierarchy)
        {
            _ChoixConfirmation3();
            CanonUsed = true;
            UsedAction = true;
            _actionUsed = 1;
            _target = 0;
        }
        //-----------------------------------------------------------
        
        
        
        
        
        
        
        
        
        
        // Si le joueur valide son action
        //-----------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.UpArrow) && AttackUsed == true)
        {
            Attack();
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && BateauUsed == true)
        {
            Bateau();
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && RepCanonUsed == true)
        {
            RepCanon();
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && RagoutUsed == true)
        {
            Ragout();
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && RhumUsed == true)
        {
            Rhum();
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && CanonUsed == true)
        {
            Canon();
        }

       
        
        
        
        
        
        
        
        
        // Si le joueur annule son action 
        //-----------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.Tab) && UsedAction == true)
        {
            _Annuler();
        }
        //-----------------------------------------------------------
        
        
        
        
        
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

    public IEnumerator _choixJoueur1()
    {
        ChoixItem.SetActive(false);
        Confirmation.SetActive(false);
        ChoixReparer.SetActive(false);
        ChoixJoueurs.SetActive(true);
        ChoixJoueurs.transform.position = transform.position + ChoixJoueursPos1;
        CurrentPlayer = 1;
        while (!_choiceMade)
        {
            yield return null;
        }
    }
    
    public IEnumerator _choixJoueur2()
    {
        ChoixItem.SetActive(false);
        Confirmation.SetActive(false);
        ChoixReparer.SetActive(false);
        ChoixJoueurs.SetActive(true);
        ChoixJoueurs.transform.position = transform.position + ChoixJoueursPos2;
        CurrentPlayer = 2;
        while (!_choiceMade)
        {
            yield return null;
        }
    }
    
    public IEnumerator _choixJoueur3()
    {
        ChoixItem.SetActive(false);
        ChoixReparer.SetActive(false);
        Confirmation.SetActive(false);
        ChoixJoueurs.SetActive(true);
        ChoixJoueurs.transform.position = transform.position + ChoixJoueursPos3;
        CurrentPlayer = 3;
        while (!_choiceMade)
        {
            yield return null;
        }
    }

    public void _choixItem1()
    {
        ChoixItem.SetActive(true);
        Confirmation.SetActive(false);
        ChoixReparer.SetActive(false);
        ChoixJoueurs.SetActive(false);
        ChoixItem.transform.position = transform.position + Ancrage_pos1;
    }
    public void _choixItem2()
    {
        ChoixItem.SetActive(true);
        Confirmation.SetActive(false);
        ChoixReparer.SetActive(false);
        ChoixJoueurs.SetActive(false);
        ChoixItem.transform.position = transform.position + Ancrage_pos2;
    }
    public void _choixItem3()
    {
        ChoixItem.SetActive(true);
        Confirmation.SetActive(false);
        ChoixReparer.SetActive(false);
        ChoixJoueurs.SetActive(false);
        ChoixItem.transform.position = transform.position + Ancrage_pos3;
    }

    public void _choixReparer1()
    {
        ChoixReparer.SetActive(true);
        Confirmation.SetActive(false);
        ChoixItem.SetActive(false);
        ChoixJoueurs.SetActive(false);
        _ChoixReparer.transform.position = transform.position + Ancrage_pos1;
    }
    
    public void _choixReparer2()
    {
        ChoixReparer.SetActive(true);
        Confirmation.SetActive(false);
        ChoixItem.SetActive(false);
        ChoixJoueurs.SetActive(false);
        ChoixReparer.transform.position = transform.position + Ancrage_pos2;
    }
    
    public void _choixReparer3()
    {
        ChoixReparer.SetActive(true);
        Confirmation.SetActive(false);
        ChoixItem.SetActive(false);
        ChoixJoueurs.SetActive(false);
        ChoixReparer.transform.position = transform.position + Ancrage_pos3;
    }

    public void _ChoixConfirmation1()
    {
        Confirmation.SetActive(true);
        ChoixReparer.SetActive(false);
        ChoixItem.SetActive(false);
        ChoixJoueurs.SetActive(false);
        Confirmation.transform.position = transform.position + Ancrage_pos1;
    }
    
    public void _ChoixConfirmation2()
    {
        Confirmation.SetActive(true);
        ChoixReparer.SetActive(false);
        ChoixItem.SetActive(false);
        ChoixJoueurs.SetActive(false);
        Confirmation.transform.position = transform.position + Ancrage_pos2;
    }
    
    public void _ChoixConfirmation3()
    {
        Confirmation.SetActive(true);
        ChoixReparer.SetActive(false);
        ChoixItem.SetActive(false);
        ChoixJoueurs.SetActive(false);
        Confirmation.transform.position = transform.position + Ancrage_pos3;
        
    }

    public void _Annuler()
    {
        ChoixJoueurs.SetActive(true);
        ChoixReparer.SetActive(false);
        ChoixItem.SetActive(false);
        Confirmation.SetActive(false);
        PNG_CibleAttaque.SetActive(false);
        AttackUsed = false;
        ReparerUsed = false;
        ItemUsed = false;
        CanonUsed = false;
        RagoutUsed = false;
        RhumUsed = false;
        BateauUsed = false;
        RepCanonUsed = false;
        UsedAction = false;
    }

    public void Attack()
    {
        Debug.Log("J'attaque y'aaaa");
        AttackUsed = false;
        Confirmation.SetActive(false);
        UsedAction = false;
        PNG_CibleAttaque.SetActive(false);

        _choiceMade = true;
    }
    
    public void RepCanon()
    {
        Debug.Log("Je répare le canon");
        ReparerUsed = false;
        RepCanonUsed = false;
        Confirmation.SetActive(false);
        UsedAction = false;
        
        _choiceMade = true;
    }
    
    public void Bateau()
    {
        Debug.Log("LE bateau se répare");
        ReparerUsed = false;
        BateauUsed = false;
        Confirmation.SetActive(false);
        UsedAction = false;
        
        _choiceMade = true;
    }
    public void Ragout()
    {
        Debug.Log("Jme Soigne");
        ItemUsed = false;
        RagoutUsed = false;
        Confirmation.SetActive(false);
        UsedAction = false;
        PNG_CibleSoin.SetActive(false);
        
        _choiceMade = true;
    }
    
    public void Rhum()
    {
        Debug.Log("GlouGlou");
        ItemUsed = false;
        RhumUsed = false;
        Confirmation.SetActive(false);
        UsedAction = false;
        PNG_CibleSoin.SetActive(false);
        
        _choiceMade = true;
    }
    
    public void Canon()
    {
        Debug.Log("Piou le canon");
        CanonUsed = false;
        Confirmation.SetActive(false);
        UsedAction = false;
        
        _choiceMade = true;
    }

    public void CibleEnnemy1()
    {
        PNG_CibleAttaque.transform.position = transform.position + Ennemy_pos1;
        _target = 0;
    }
    
    public void CibleEnnemy2()
    {
        PNG_CibleAttaque.transform.position = transform.position + Ennemy_pos2;
        _target = 1;
    }
    
    public void CibleEnnemy3()
    {
        PNG_CibleAttaque.transform.position = transform.position + Ennemy_pos3;
        _target = 2;
    }
    
    public void CibleEnnemy4()
    {
        PNG_CibleAttaque.transform.position = transform.position + Ennemy_pos4;
        _target = 3;
    }
    
    public void CibleEnnemy5()
    {
        PNG_CibleAttaque.transform.position = transform.position + Ennemy_pos5;
        _target = 4;
    }

    public void CibleSoin1()
    {
        PNG_CibleSoin.transform.position = transform.position + Ancrage_pos1;
    }

    public void CibleSoin2()
    {
        PNG_CibleSoin.transform.position = transform.position + Ancrage_pos2;
    }

    public void CibleSoin3()
    {
        PNG_CibleSoin.transform.position = transform.position + Ancrage_pos3;
    }
    
    public (int, int) Starter(Player player)
    {
        switch (player.GetRoleIndex())
        {
            case 0:
                StartCoroutine("_choixJoueur1");
                break;
            case 1:
                StartCoroutine("_choixJoueur2");
                break;
            case 2: 
                StartCoroutine("_choixJoueur3");
                break;
        }

        Fight.isTurnOver = true;
        return (_actionUsed, _target);
    }
}
    

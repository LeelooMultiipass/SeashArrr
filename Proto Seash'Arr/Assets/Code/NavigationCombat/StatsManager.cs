using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StatsManager : MonoBehaviour
{
   // Temps de jeu
    [Header("Temps globaux")]
    public float TempsNavigation = 0;
    public float TempsCombat = 0;
    public float TempsFight = 0;
    public int TempsMinBeforeFight = 50;
    public int TempsMaxBeforeFight = 75;
    public int TempsBeforeIsland = 90;
    public float TimerFightCooldown = 5;

    [Space(20)]

    // Random et switch entre caméras
    [Header("Temps avant le switch de camera")]
    public int LancementFight;
    public int LancementNavig = 10;
    [Space(20)]

    //Etat de jeu
    [Header("Etat des phases")]
    public bool Navigation = true;
    public bool Fight = false;
    [Space(20)]

    // Objets à toggle
    [Header("Objets Toggle")]
    public GameObject CameraFight;
    public GameObject CameraNavigation;
    public GameObject UIPopUpEnnemies;
    public Slider slider;
    
    [Space(20)]

    [Header("Statistiques")]
    public int boatHealth;
    public int canonHealth;
    public int nbrWood;
    public int nbrIron;
    public int nbrFood;
    public int nbrRhum;
    public int nbrRagout;
    public int boatMaxHealth=300;
    public int canonMaxHealth=100;
    [Space(20)]

    [Header("Texts")]
    public TMP_Text boatHealthText;
    public TMP_Text canonHealthText;
    public TMP_Text nbrWoodText;
    public TMP_Text nbrIronText;
    public TMP_Text nbrFoodText;
    public TMP_Text nbrRhumText;
    public TMP_Text nbrRagoutText;
    [Space(20)]
    
    // Le random
    System.Random rnd = new System.Random();


    // Start is called before the first frame update
    void Start()
    {
        LancementFight = rnd.Next(TempsMinBeforeFight, TempsMaxBeforeFight); //Randomise automatiquement le premier lancement de combat
        slider.maxValue = TempsBeforeIsland;
        slider.value = 0;
        boatHealth = boatMaxHealth;
        canonHealth = canonMaxHealth;
        UpdateText();
    }

    public void UpdateText()
    {
        boatHealthText.text = boatHealth + " / " + boatMaxHealth;
        canonHealthText.text = canonHealth + " / " + canonMaxHealth;
        nbrWoodText.text = nbrWood +"";
        nbrIronText.text = nbrIron + "";
        nbrFoodText.text = nbrFood + "";
        nbrRhumText.text = nbrRhum + "";
        nbrRagoutText.text = nbrRagout + "";

    }

    // Update is called once per frame
    void Update()
    {
        if (Navigation == true)
        {
            TempsNavigation += Time.deltaTime;
            TempsCombat += Time.deltaTime;
            slider.value = TempsNavigation;

            if (TempsCombat >= LancementFight- TimerFightCooldown)
                {
                    UIPopUpEnnemies.SetActive(true);
                }

            if (Mathf.Abs(TempsCombat - LancementFight) < 0.1f)
            {
                Navigation = false;
                Fight = true;
                
                
               


                CameraNavigation.SetActive(!CameraNavigation.activeSelf);
                slider.maxValue = TempsBeforeIsland;
                slider.value = LancementFight;
                TempsNavigation = LancementFight;
                CameraFight.SetActive(!CameraFight.activeSelf);
                UIPopUpEnnemies.SetActive(!UIPopUpEnnemies.activeSelf);
                
                //SceneManager.LoadScene("FightTest"); // Remplacez "FightScene" par le nom de votre scène de combat
                //UI.SetActive(!UI.activeSelf);

                // Réinitialiser TempsNavigation pour arrêter le timer
                TempsNavigation += Time.deltaTime;
                slider.value = TempsNavigation;


                // Redéfinir Lancement pour le prochain combat aléatoire
                LancementFight = rnd.Next(TempsMinBeforeFight, TempsMaxBeforeFight);
                TempsCombat = 0;
            }
        }

        if (Fight == true)
        {
            //SceneManager.LoadScene("FightTest");

            TempsFight += Time.deltaTime;
            if (Mathf.Abs(TempsFight - LancementNavig) < 0.1f)
            {
                Fight = false;
                Navigation = true;
                CameraNavigation.SetActive(!CameraNavigation.activeSelf);
                CameraFight.SetActive(!CameraFight.activeSelf);
               // UI.SetActive(!UI.activeSelf);

                // Réinitialiser TempsFight pour arrêter le timer
                TempsFight = 0;
            }
        }
    }
}

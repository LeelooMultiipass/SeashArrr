using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAtelier : MonoBehaviour
{
    public StatsManager StatsManager;

    public void AmeliorationBateau()
    {
        StatsManager.nbrWood = StatsManager.nbrWood - 100;
        StatsManager.nbrIron = StatsManager.nbrIron - 50;

        StatsManager.UpdateText();
    }


    public void AmeliorationCanon()
    {
        StatsManager.nbrWood = StatsManager.nbrWood - 70;
        StatsManager.nbrIron = StatsManager.nbrIron - 30; 

        StatsManager.UpdateText();
    }

    public void ReparerCanon()
    {
        StatsManager.nbrIron = StatsManager.nbrIron - 20;
        StatsManager.UpdateText();
    }

    public void ReparerBateau()
    {
        StatsManager.nbrIron = StatsManager.nbrIron - 20;
        StatsManager.UpdateText();
    }

    public void CuisinerRhum()
    {
        StatsManager.nbrFood = StatsManager.nbrFood - 20;
        StatsManager.nbrRhum = StatsManager.nbrRhum + 1;
        StatsManager.UpdateText();
    }

    public void CuisinerRagout() 
    {
        StatsManager.nbrFood = StatsManager.nbrFood - 20;
        StatsManager.nbrRagout = StatsManager.nbrRagout + 1;
        StatsManager.UpdateText();
    }


    public void Manger()
    {
       StatsManager.nbrRagout = StatsManager.nbrRagout - 1;
        StatsManager.UpdateText();
    }
}

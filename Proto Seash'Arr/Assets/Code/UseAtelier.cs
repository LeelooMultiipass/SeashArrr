using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAtelier : MonoBehaviour
{

    private StatsManager StatsManager;

    

    public void AmeliorerBateau()
    {
        StatsManager.nbrWood = StatsManager.nbrWood - 100;
        StatsManager.nbrIron = StatsManager.nbrIron - 50;
        StatsManager.UpdateText();
    }

    public void AmeliorerCanon()
    {
    }

    public void Cuisiner()
    {
    }

    public void Manger()
    {
    }

    public void ReparerBateau()
    {
    }

    public void ReparerCanon()
    { 
    }


    
}

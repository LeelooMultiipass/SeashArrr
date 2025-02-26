using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAtelier : MonoBehaviour
{
    public StatsManager StatsManager;
    public AtelierManager AtelierManager;
    public int tempsAvantInteraction = 1; // Délai avant l'action
    public int tempsApresInteraction = 3; // Délai après l'action

    public void AmeliorationBateau()
    {
        if (AtelierManager.PanelTableIngenieur.activeSelf)
        {
            if (StatsManager.nbrWood >= 100 && StatsManager.nbrIron >= 50)
            {
                StartCoroutine(EffectuerActionAvecDelais(() =>
            {
                StatsManager.nbrWood -= 100;
                StatsManager.nbrIron -= 50;
                StatsManager.UpdateText();
            }));
            }
        }
    }

    public void AmeliorationCanon()
    {
        if (AtelierManager.PanelTableIngenieur.activeSelf)
        {
            if (StatsManager.nbrWood >= 70 && StatsManager.nbrIron >= 30)
            {
                StartCoroutine(EffectuerActionAvecDelais(() =>
            {
                StatsManager.nbrWood -= 70;
                StatsManager.nbrIron -= 30;
                StatsManager.UpdateText();
            }));
            }
        }
    }

    public void ReparerCanon()
    {
        if (AtelierManager.PanelCanon.activeSelf)
        {
            if (StatsManager.nbrWood >= 20)
            {
                StartCoroutine(EffectuerActionAvecDelais(() =>
            {
                StatsManager.nbrWood -= 20;
                StatsManager.UpdateText();
            }));
            }
        }
    }

    public void ReparerBateau()
    {
        if (StatsManager.nbrIron >= 20)
        {
            StartCoroutine(EffectuerActionAvecDelais(() =>
        {
            StatsManager.nbrIron -= 20;
            StatsManager.UpdateText();
        }));
        }
    }

    public void CuisinerRhum()
    {
        if (AtelierManager.PanelCuisine.activeSelf)
        {
            if (StatsManager.nbrFood >= 20)
            {
                StartCoroutine(EffectuerActionAvecDelais(() =>
            {
                StatsManager.nbrFood -= 20;
                StatsManager.nbrRhum += 1;
                StatsManager.UpdateText();
            }));
            }
        }
    }

    public void CuisinerRagout()
    {
        if (AtelierManager.PanelCuisine.activeSelf)
        {
            if (StatsManager.nbrFood >= 20)
            {
                StartCoroutine(EffectuerActionAvecDelais(() =>
                {
                    StatsManager.nbrFood -= 20;
                    StatsManager.nbrRagout += 1;
                    StatsManager.UpdateText();
                }));
            }
        }
    }

    public void Manger()
    {
        if (AtelierManager.PanelPiqueNique.activeSelf)
        {
            if (StatsManager.nbrRagout > 0)
            {
                StartCoroutine(EffectuerActionAvecDelais(() =>
            {
                StatsManager.nbrRagout -= 1;
                StatsManager.UpdateText();
            }));
            }
        }
    }

    private IEnumerator EffectuerActionAvecDelais(System.Action action)
    {
        // Délai avant l'action
        yield return new WaitForSeconds(tempsAvantInteraction);

        // Exécution de l'action
        action?.Invoke();

        // Délai après l'action
        yield return new WaitForSeconds(tempsApresInteraction);
    }
}

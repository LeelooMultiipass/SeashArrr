using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseAtelier : MonoBehaviour
{
    public StatsManager StatsManager;
    public AtelierManager AtelierManager;
    public float tempsAction;
    public float timer;

    public bool isBusy = false;
    private AtelierManager[] allAteliers;

    private void Start()
    {
        allAteliers = FindObjectsOfType<AtelierManager>();
        Debug.Log("Nombre d'ateliers trouvés : " + allAteliers.Length);
    }

    private void TryAction(string actionName, System.Action action)
    {
        if (!isBusy)
        {
            StartCoroutine(ActionRoutine(actionName, action));
        }
        else
        {
            Debug.Log("Action bloquée : une autre est déjà en cours.");
        }
    }

    private IEnumerator ActionRoutine(string actionName, System.Action action)
    {
        isBusy = true;
        Debug.Log("Début de l'action : " + actionName);

        // Trouver le slider actif correspondant
        Slider activeSlider = null;

        if (AtelierManager.PanelCuisine.activeSelf) activeSlider = AtelierManager.CuisineSlider;
        else if (AtelierManager.PanelTableIngenieur.activeSelf) activeSlider = AtelierManager.IngeniorSlider;
        else if (AtelierManager.PanelCanon.activeSelf) activeSlider = AtelierManager.CanonSlider;
        else if (AtelierManager.PanelPiqueNique.activeSelf) activeSlider = AtelierManager.PiqueNiqueSlider;

        if (activeSlider != null)
        {
            activeSlider.gameObject.SetActive(true);
            activeSlider.maxValue = tempsAction;
            activeSlider.value = tempsAction;
        }

        action?.Invoke();

        Debug.Log("Action exécutée, temps de blocage (" + tempsAction + "s)");

        timer = 0f;
        if (activeSlider != null)
        {
            activeSlider.maxValue = tempsAction;
            activeSlider.value = 0;
        }

        while (timer < tempsAction)
        {
            timer += Time.deltaTime;
            if (activeSlider != null)
                activeSlider.value = timer;

            yield return null;
        }

        if (activeSlider != null)
            activeSlider.gameObject.SetActive(false);

        isBusy = false;
        Debug.Log("Fin de l'action : " + actionName);
    }

    public void AmeliorationBateau()
    {
        tempsAction = 20;
        TryAction("Amélioration Bateau", () =>
        {
            if (AtelierManager.PanelTableIngenieur.activeSelf &&
                StatsManager.nbrWood >= 100 && StatsManager.nbrIron >= 50)
            {
                StatsManager.nbrWood -= 100;
                StatsManager.nbrIron -= 50;
                StatsManager.UpdateText();
            }
        });
    }

    public void AmeliorationCanon()
    {
        tempsAction = 16;
        TryAction("AmeCanon",() =>
        {
            if (AtelierManager.PanelTableIngenieur.activeSelf &&
                StatsManager.nbrWood >= 70 && StatsManager.nbrIron >= 30)
            {
                StatsManager.nbrWood -= 70;
                StatsManager.nbrIron -= 30;
                StatsManager.UpdateText();
            }
        });
    }

    public void ReparerCanon()
    {
        tempsAction = 10;
        TryAction("RepCanon", () =>
        {
            if (AtelierManager.PanelCanon.activeSelf && StatsManager.nbrWood >= 20)
            {
                StatsManager.nbrWood -= 20;
                StatsManager.UpdateText();
            }
        });
    }

    public void ReparerBateau()
    {
        tempsAction = 10;
        TryAction("RepBateau", () =>
        {
            if (StatsManager.nbrIron >= 20)
            {
                StatsManager.nbrIron -= 20;
                StatsManager.UpdateText();
            }
        });
    }

    public void CuisinerRhum()
    {
        tempsAction = 10;
        TryAction("Rhum", () =>
        {
            if (AtelierManager.PanelCuisine.activeSelf && StatsManager.nbrFood >= 20)
            {
                StatsManager.nbrFood -= 20;
                StatsManager.UpdateText();
            }
        });
    }

    public void CuisinerRagout()
    {
        tempsAction = 10;
        TryAction("Ragout", () =>
        {
            if (AtelierManager.PanelCuisine.activeSelf && StatsManager.nbrFood >= 20)
            {
                StatsManager.nbrFood -= 20;
                StatsManager.UpdateText();
            }
        });
    }

    public void Manger()
    {
        tempsAction = 5;
        TryAction("Manger", () =>
        {
            if (AtelierManager.PanelPiqueNique.activeSelf && StatsManager.nbrRagout > 0)
            {
                StatsManager.nbrRagout -= 1;
                StatsManager.UpdateText();
            }
        });
    }
}
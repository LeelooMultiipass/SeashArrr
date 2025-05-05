using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject actionPanel;
    public GameObject targetPanel;

    public Button[] actionButtons; // 0: Attack, 1: Canon, 2: Fix, 3: Heal, 4: Boost
    public Button[] targetButtons; // Filled dynamically
    public TMP_Text promptText;

    private int selectedAction = -1;
    private int selectedTarget = -1;

    private bool actionChosen = false;
    private bool targetChosen = false;

    private Player currentPlayer;

    public (int, int) Starter(Player player)
    {
        currentPlayer = player;
        selectedAction = -1;
        selectedTarget = -1;
        actionChosen = false;
        targetChosen = false;

        StartCoroutine(ActionSelection());
        while (!targetChosen)
        {
            // Wait until both action and target are chosen
        }

        return (selectedAction, selectedTarget);
    }

    private IEnumerator ActionSelection()
    {
        actionPanel.SetActive(true);
        targetPanel.SetActive(false);
        promptText.text = "Choose your action";

        // Assign button listeners
        actionButtons[0].onClick.AddListener(() => SelectAction(0)); // Attack
        actionButtons[1].onClick.AddListener(() => SelectAction(1)); // Canon
        actionButtons[2].onClick.AddListener(() => SelectAction(2)); // Fix
        actionButtons[3].onClick.AddListener(() => SelectAction(3)); // Heal
        actionButtons[4].onClick.AddListener(() => SelectAction(4)); // Boost

        // Wait for action to be selected
        yield return new WaitUntil(() => actionChosen);

        // Now choose target
        yield return StartCoroutine(TargetSelection());

        yield return null;
    }

    private void SelectAction(int index)
    {
        selectedAction = index;
        actionChosen = true;
        actionPanel.SetActive(false);
    }

    private IEnumerator TargetSelection()
    {
        targetPanel.SetActive(true);
        targetChosen = false;

        // Clear old buttons
        foreach (Transform child in targetPanel.transform)
            Destroy(child.gameObject);

        promptText.text = "Choose your target";

        // Create buttons based on selectedAction
        List<string> targets = new List<string>();

        switch (selectedAction)
        {
            case 0: // Attack
            case 1: // Canon
                for (int i = 0; i < Fight.Ennemies.Count; i++)
                    targets.Add("Enemy " + i);
                break;

            case 2: // Fix
                targets.Add("Boat");
                targets.Add("Canon");
                break;

            case 3: // Heal
            case 4: // Boost
                for (int i = 0; i < Fight.Players.Count; i++)
                    targets.Add("Player " + i);
                break;
        }

        for (int i = 0; i < targets.Count; i++)
        {
            int index = i;
            GameObject btnObj = new GameObject("TargetBtn" + i);
            btnObj.transform.SetParent(targetPanel.transform);
            Button btn = btnObj.AddComponent<Button>();
            TMP_Text txt = btnObj.AddComponent<TMP_Text>();
            txt.text = targets[i];
            txt.fontSize = 24;
            btn.onClick.AddListener(() => SelectTarget(index));
        }

        yield return new WaitUntil(() => targetChosen);
        targetPanel.SetActive(false);
    }

    private void SelectTarget(int index)
    {
        selectedTarget = index;
        targetChosen = true;
    }

    public static void UiUpdateHealthBar()
    {
        foreach (Player player in Fight.Players)
        {
            Slider slider = player.GetComponentInChildren<Slider>();
            if (slider != null)
            {
                float ratio = (float)player.GetHP() / player.GetHPMax();
                slider.value = ratio;
            }
        }

        foreach (Ennemy enemy in Fight.Ennemies)
        {
            Slider slider = enemy.GetComponentInChildren<Slider>();
            if (slider != null)
            {
                float ratio = (float)enemy.GetHP() / enemy.GetHPMax();
                slider.value = ratio;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class UIController : MonoBehaviour
{

    private Label credits, round, remaining_enemies;


    void OnEnable()
    {
        var root_element = GetComponent<UIDocument>().rootVisualElement;
        credits = root_element.Q<Label>("Credits");
        round = root_element.Q<Label>("Round");
        remaining_enemies = root_element.Q<Label>("RemainingEnemies");
    }


    public void SetRound(int r)
    {
        round.text = $"{r}";
    }

    public void SetRemainingEnemies(int re)
    {
        remaining_enemies.text = $"{re}";
    }

    public void SetCredits(int c)
    {
        credits.text = $"{c}";
    }
}

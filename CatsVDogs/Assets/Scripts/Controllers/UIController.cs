using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI credits, round, remaining_enemies;

    public void SetCredits(int c)
    {   
        credits.text = "Credits: " + c;
    }

    public void SetRound(int r)
    {   
        round.text = r.ToString();
    }

    public void SetRemainingEnemies(int re)
    {   
        remaining_enemies.text = re.ToString();
    }
}

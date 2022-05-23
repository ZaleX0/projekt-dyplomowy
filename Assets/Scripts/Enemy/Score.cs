using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public ScoreUI scoreUI;

    public void AddScore(int amount)
    {
        scoreUI.AddScore(amount);
    }
}

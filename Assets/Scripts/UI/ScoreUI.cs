using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = $"Score: {score}";
    }
}

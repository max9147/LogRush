using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private int score = 0;

    public void AddScore()
    {
        score++;
        scoreText.text = $"�����: {score}";
    }

    public int GetScore()
    {
        return score;
    }
}

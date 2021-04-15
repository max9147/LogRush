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
        score += Mathf.RoundToInt(Mathf.Sqrt(GetComponent<TimeCount>().GetTimePassed()));
        scoreText.text = $"Очков: {score}";
    }

    public int GetScore()
    {
        return score;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControls : MonoBehaviour
{
    public GameObject pauseMenu;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI resultText;

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void FinalScore()
    {
        finalScoreText.text = $"�������� ����: {GetComponent<ScoreSystem>().GetScore()} �����";
        if (PlayerPrefs.HasKey("BestScore") && GetComponent<ScoreSystem>().GetScore()<=PlayerPrefs.GetInt("BestScore"))
        {
            resultText.text = $"������: {PlayerPrefs.GetInt("BestScore")}";
        }
        else
        {
            resultText.text = "����� ������!";
            PlayerPrefs.SetInt("BestScore", GetComponent<ScoreSystem>().GetScore());
        }
    }
}

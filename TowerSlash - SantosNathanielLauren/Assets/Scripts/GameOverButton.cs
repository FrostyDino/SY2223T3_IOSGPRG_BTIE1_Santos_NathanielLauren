using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{
    public TextMeshProUGUI FinalScoreText;
    public void Start()
    {
        FinalScoreText.text = "Final Score: " + PlayerData.Instance.Points;
    }
    public void RetryButton() 
    {
        PlayerData.Instance.ResetGame();
        SceneManager.LoadScene(0);
    }
}

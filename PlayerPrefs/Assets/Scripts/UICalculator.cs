using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICalculator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentScoreTxt;
    [SerializeField] private TextMeshProUGUI _highScoreTxt;
    private int _currentScore;
    private int _highScore;
    private void OnEnable()
    {
        EventManager.OnCollectedCoin += IncreaseScore;
        EventManager.OnArrivedFinish += GetHighScore;
    }

    private void GetHighScore()
    {
        if (_currentScore > _highScore)
        {
            _highScore = _currentScore;
            PlayerPrefs.SetInt("HighScore", _highScore);
            _highScoreTxt.text = "High score: " + _highScore.ToString();
        }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            _highScoreTxt.text = "High score: " + PlayerPrefs.GetInt("HighScore");
        }
    }
    void IncreaseScore()
    {
        _currentScore += 1;
        _currentScoreTxt.text = "Score: " + _currentScore.ToString();
        PlayerPrefs.SetInt("CurrentScore", _currentScore);
    }

}

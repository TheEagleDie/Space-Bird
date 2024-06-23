using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextUpdate : MonoBehaviour
{
    [SerializeField] ScoreCounter _scoreCounter;
    [SerializeField] TextMeshProUGUI _scoreText;


    private void OnEnable()
    {
        _scoreCounter.ScoreAdded += OnScoreAdded; 
    }
    private void OnDisable()
    {
        _scoreCounter.ScoreAdded -= OnScoreAdded;
    }

    private void OnScoreAdded()
    {
        _scoreText.text = _scoreCounter.GetCurrentScore().ToString();
    }
}

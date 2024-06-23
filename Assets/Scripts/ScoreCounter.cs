using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public event Action ScoreAdded;

    [SerializeField] private int _currentScore;
    [SerializeField] private int _scoreFromZone;


    private void OnEnable()
    {
        Game.GameRestarted += OnGameRestarted;
    }
    private void OnDisable()
    {
        Game.GameRestarted -= OnGameRestarted;
    }

    private void OnGameRestarted()
    {
        ResetScore();
    }
    public void Add()
    {
        _currentScore += TryToAddScore(_scoreFromZone);
        ScoreAdded?.Invoke();
    }
    public int GetCurrentScore()
    {
        return _currentScore;
    } 
    private int TryToAddScore(int scoreAmount)
    {
        if(scoreAmount < 0)
        {
            Debug.Log($"{scoreAmount} не может быть меньше нуля");
            return 0;
        }
        else
        {
            return scoreAmount;
        }
    }
    private void ResetScore()
    {
        _currentScore = 0;
        ScoreAdded?.Invoke();
    }
}

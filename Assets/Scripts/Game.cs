using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static event Action GameStarted;
    public static event Action GameRestarted;

    [SerializeField] private Player _player;
    [SerializeField] private AsteroidGenerator _asteroidGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClicked;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClicked;
        _player.PlayerDeath += OnPlayerDeath;
    }
    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClicked;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClicked;
        _player.PlayerDeath -= OnPlayerDeath;
    }
    private void Start()
    {
        Construct();
    }
    public void Construct()
    {
        Time.timeScale = 0;
        _startScreen.Open();
        _endGameScreen.Close();
    }
    private void StartGame()
    {
        _startScreen.Close();
        Time.timeScale = 1;
        GameStarted?.Invoke();
    }
    private void EndGame()
    {
        Time.timeScale = 0;
        _endGameScreen.Open();
    }

    private void OnPlayButtonClicked()
    {
        StartGame();
    }
    private void OnRestartButtonClicked()
    {
        GameRestarted?.Invoke();
        Construct();
    }
    private void OnPlayerDeath()
    {
        EndGame();
    }
    



}

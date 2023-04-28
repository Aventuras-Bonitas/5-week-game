using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public enum GameState
    {
        idle,
        ingame,
        gameover
    }

    public GameState gameState = GameState.ingame;
    public int puntos = 0;

    public void Point()
    {
        puntos += 1;
    }

    public void GameStart()
    {
        gameState = GameState.ingame;
    }

    public void GameOver()
    {
        gameState = GameState.gameover;
    }
}

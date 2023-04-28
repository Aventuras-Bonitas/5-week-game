using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTest : MonoBehaviour
{

    public float points = 0;

    public enum GameState
    {
        Idle,
        InGame,
        GameOver
    }

    public GameState gameState = GameState.Idle;

    public static GameManagerTest Instance;
    private void Awake()
    {
        if(Instance== null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Point()
    {
        points++;
    }

    public void GameStart()
    {
        gameState = GameState.InGame;
    }

    public void GameOver()
    {
        gameState = GameState.GameOver;
    }
}

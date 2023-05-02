using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float puntos = 0;
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
    

    public void Point()
    {
        Debug.Log("Point!: "+ puntos.ToString());
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

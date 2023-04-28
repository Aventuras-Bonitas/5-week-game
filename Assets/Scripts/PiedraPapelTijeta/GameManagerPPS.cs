using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManagerPPS : MonoBehaviour
{
    public enum State
    {
        MainMenu,
        InGame,
        Victory,
        GameOver

    }
    public State currentState;
    public int numJuegos;
    public int numVictorias;
    public int numDerrotas;
    public GameObject game;
    public GameObject mainMenu;
    public GameObject gameOver;
    public GameObject victory;

    public JuegoPPT juego;
    public static GameManagerPPS Instance;

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


    void Start()
    {
        MainMenu();
        juego = FindObjectOfType<JuegoPPT>();
    }

    void Update()
    {
        
    }
    public void MainMenu()
    {
        victory.SetActive(false);
        mainMenu.SetActive(true);
        gameOver.SetActive(false);
        currentState = State.MainMenu;
        numDerrotas = 0;
        numJuegos = 0;
        numVictorias = 0;
        juego.rondasJugadas = 0;
        juego.resultadoText.text = "";
        juego.eleccionJugador.sprite = null;
        juego.eleccionEnemigo.sprite = null;


    }
    public void StartGame()
    {
        numJuegos = 3;
        currentState = State.InGame;
        game.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void GameOver()
    {
        currentState = State.GameOver;
        gameOver.SetActive(true);
        game.SetActive(false);


    }
    public void GamesVictory()
    {
        numVictorias++;
    }

    public void Victory()
    {
        currentState = State.Victory;
        game.SetActive(false);
        victory.SetActive(true);

    }
    public void GamesLose()
    {
        numDerrotas++;
    }


}

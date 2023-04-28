using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JuegoPPT : MonoBehaviour
{

    public Button piedraButton;
    public Button papelButton;
    public Button tijeraButton;
    public int rondasJugadas;
    public Text resultadoText; // gamobject,Panel   
    public Image eleccionJugador;
    public Image eleccionEnemigo;

    public Sprite piedra;
    public Sprite papel;
    public Sprite tijera;

    private int jugadorSeleccion = -1; // -1 indica que el jugador aún no ha elegido
    private int computadoraSeleccion = -1; // -1 indica que la computadora aún no ha elegido

    void Start()
    {
        piedraButton.onClick.AddListener(() => seleccionJugador(0));
        piedraButton.onClick.AddListener(() => ImageSelection(0));
        papelButton.onClick.AddListener(() => seleccionJugador(1));
        papelButton.onClick.AddListener(() => ImageSelection(1));
        tijeraButton.onClick.AddListener(() => seleccionJugador(2));
        tijeraButton.onClick.AddListener(() => ImageSelection(2));

        rondasJugadas = 0;
    }

    void seleccionJugador(int seleccion)
    {
        jugadorSeleccion = seleccion;
        computadoraSeleccion = Random.Range(0, 3);
        ImageSelectionIA(computadoraSeleccion);
        resultadoText.text = "La computadora ha elegido: " + seleccionToString(computadoraSeleccion) + "\n";

        int resultado = determinarResultado(jugadorSeleccion, computadoraSeleccion);

        if (resultado == 0)
        {
            resultadoText.text += "¡Empates esta ronda!";
        }
        else if (resultado == 1)
        {
            resultadoText.text += "¡Ganaste esta ronda!";
            GameManagerPPS.Instance.GamesVictory();
            rondasJugadas++;

        }
        else
        {
            resultadoText.text += "¡Perdiste esta ronda!";
            GameManagerPPS.Instance.GamesLose();
            rondasJugadas++;

        }

        if (rondasJugadas == GameManagerPPS.Instance.numJuegos)
        {


            if (GameManagerPPS.Instance.numVictorias > GameManagerPPS.Instance.numDerrotas)
            {
                resultadoText.text += "\n¡Ganaste el juego!";
                GameManagerPPS.Instance.Victory();

            }
            else
            {
                resultadoText.text += "\n¡Perdiste el juego!";
                GameManagerPPS.Instance.GameOver();

            }
        }

    }

    public void ImageSelection(int seleccion)
    {
        if ( seleccion == 0)
        {
            eleccionJugador.sprite = piedra;
        }
        else if( seleccion ==1)
        {
            eleccionJugador.sprite = papel;
        }
        else if (seleccion ==2)
        {
            eleccionJugador.sprite = tijera;
        }
    }

    public void ImageSelectionIA(int seleccion)
    {
        if (seleccion == 0)
        {
            eleccionEnemigo.sprite = piedra;
        }
        else if (seleccion == 1)
        {
            eleccionEnemigo.sprite = papel;
        }
        else if (seleccion == 2)
        {
            eleccionEnemigo.sprite = tijera;
        }
    }

    string seleccionToString(int seleccion)
    {
        switch (seleccion)
        {
            case 0:
                return "piedra";
            case 1:
                return "papel";
            case 2:
                return "tijera";
            default:
                return "error";
        }
    }

    int determinarResultado(int jugadorSeleccion, int computadoraSeleccion)
    {
        if (jugadorSeleccion == computadoraSeleccion)
        {
            return 0; // Empate
        }
        else if (jugadorSeleccion == 0 && computadoraSeleccion == 2 ||
                 jugadorSeleccion == 1 && computadoraSeleccion == 0 ||
                 jugadorSeleccion == 2 && computadoraSeleccion == 1)
        {
            return 1; // Jugador gana
        }
        else
        {
            return -1; // Computadora gana
        }
    }
}


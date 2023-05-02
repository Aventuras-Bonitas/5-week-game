using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Add this line


public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI points;
    public GameObject StartScreen;
    public GameObject gameOverScreen;
    public GameObject player;

    private void Update()
    {
        if(GameManager.Instance!= null)
        {
            points.text = GameManager.Instance.puntos.ToString();

            if (GameManager.Instance.gameState == GameManager.GameState.ingame)
            {
                StartScreen.SetActive(false);
                points.gameObject.SetActive(true);
                player.SetActive(true);
            }
            if (GameManager.Instance.gameState == GameManager.GameState.gameover)
            {
                gameOverScreen.SetActive(true);
            }
        }
    }

    public void StartGameButtonClicked()
    {
        GameManager.Instance.gameState = GameManager.GameState.ingame;
    }

    public void PlayAgainButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Add this line
    }

    public void ExitGameButtonClicked()
    {
        Application.Quit(); // Add this line
    }
}

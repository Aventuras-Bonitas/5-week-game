using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameTest : MonoBehaviour
{
    public GameObject startScreenUI;
    public GameObject inGameScreenUI;

    public TextMeshProUGUI points;
         

    public void StartGameButtonClicked()
    {
        GameManagerTest.Instance.GameStart();
        startScreenUI.SetActive(false);
        inGameScreenUI.SetActive(true);
    }

    private void Update()
    {
        points.text = GameManagerTest.Instance.points.ToString();
    }
}

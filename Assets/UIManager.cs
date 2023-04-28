using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI points;

    private void Update()
    {
        if(GameManager.Instance!= null)
        {
            points.text = GameManager.Instance.puntos.ToString();
        }
    }
}

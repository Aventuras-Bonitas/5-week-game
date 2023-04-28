using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorDeTubos : MonoBehaviour
{
    public GameObject tubos;
    public float intervalo = 3f;
    float tiempoActual;
    public float minY;
    public float maxY;
    // Start is called before the first frame update
    void Start()
    {
        tiempoActual = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameManager.Instance != null && GameManager.Instance.gameState != GameManager.GameState.ingame)
        {
            return;
        }

        tiempoActual += Time.deltaTime;
        if (tiempoActual > intervalo)
        {
            tiempoActual = 0;
            var nuevoTubo = Instantiate(tubos);
            Vector3 nuevaPos = transform.position;
            nuevaPos.y = Random.Range(minY, maxY);
            nuevoTubo.transform.position = nuevaPos;
        }
    }
}

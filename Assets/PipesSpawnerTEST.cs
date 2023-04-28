using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawnerTEST : MonoBehaviour
{
    public GameObject pipes;
    public float interval = 3f;
    public float maxY = 5;
    public float minY = -5f;
    float currentTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerTest.Instance.gameState==GameManagerTest.GameState.InGame)
        {
            currentTime += Time.deltaTime;
            if (currentTime > interval)
            {
                currentTime = 0;
                var newPipe = Instantiate(pipes);
                var newPos = transform.position;
                newPos.y = Random.Range(minY, maxY);
                newPipe.transform.position = newPos;
            }
        }
    }
}

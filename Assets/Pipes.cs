using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;
    public float minPosX = -20;

    public bool point = false;

    // Update is called once per frame
    void Update()
    {
        if (GameManagerTest.Instance.gameState==GameManagerTest.GameState.InGame)
        {
            transform.position += transform.right * speed * -1 * Time.deltaTime;

            if (transform.position.x < 0 && !point)
            {
                point = true;
                GameManagerTest.Instance.Point();
            }

            if (transform.position.x < minPosX)
            {
                Destroy(gameObject);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<BirdTest>().Kill();
        }
    }
}

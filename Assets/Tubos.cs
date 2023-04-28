using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tubos : MonoBehaviour
{
    public float velocidad = 2f;
    public float minPosX = -15f;

    bool punto = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameState != GameManager.GameState.ingame)
        {
            return;
        }

        transform.position += (Vector3)Vector2.right * velocidad * -1;

        if(transform.position.x < -5.2f && !punto)
        {
            punto = true;
            GameManager.Instance.Point();
        }

        if (transform.position.x < minPosX)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("COLISION!");
        if (other.gameObject.CompareTag("Player"))
        {
            var ave = other.GetComponent<Ave>();
            ave.Matar();
        }
    }
}

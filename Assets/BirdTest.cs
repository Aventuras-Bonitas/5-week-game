using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTest : MonoBehaviour
{
    public bool isAlive = true;
    Vector2 velocity;

    public float gravity = 9.8f;
    public float flapForce = 2f;
    public float rotationSmoothFactor = 5f; // Factor de suavizado para la rotación

    static Vector3 deadRotation = new Vector3(0,0,-120);

    private void Update()
    {

        if (GameManagerTest.Instance.gameState == GameManagerTest.GameState.Idle)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1") && isAlive)
        {
            velocity = Vector2.up * flapForce;
        }

        velocity += Vector2.down * gravity * Time.deltaTime;

        transform.position += (Vector3)velocity * Time.deltaTime;

        //rotation
        if (isAlive)
        {
            float newRotZ = velocity.y > 0 ? 35f : -35f;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, newRotZ));
        }
        else
        {
            transform.Rotate(deadRotation * Time.deltaTime);
        }
    }

    public void Kill()
    {
        if (isAlive)
        {
            isAlive = false;
            velocity = Vector2.up * flapForce*1.3f;
            GameManagerTest.Instance.GameOver();
        }
    }
}
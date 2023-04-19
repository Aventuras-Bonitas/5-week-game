using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public float speed = 6f;
    public float force = 20f;

    public Vector3 posA;
    public Vector3 posB;

    [Range(0,1)]
    public float value = 0;

    public float maxX;
    public float minX;

    //lerp

    Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        RigidMove();
    }

    void LerpMove()
    {
        transform.position = Vector3.Lerp(posA, posB, value);
    }

    void RigidMove()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");
        var MoveVector = new Vector3(inputX, inputY, 0);
        rigidBody.AddForce(MoveVector*force*Time.deltaTime);

        if(inputX == 0 & inputY == 0)
        {
            rigidBody.velocity = Vector2.zero;
        }
    }

    void simpleMove()
    {
       transform.position += new Vector3(speed, speed, 0) * Time.deltaTime;
        if (transform.position.x > maxX)
        {
            speed = speed * -1;
        }
        if (transform.position.x < minX)
        {
            speed = speed * -1;
        }
    }
}

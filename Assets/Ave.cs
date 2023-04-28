using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ave : MonoBehaviour
{
    public bool estaViva = true;
    Vector2 velocidad;
    public float gravedad = 9.8f;
    public float flapForce = 1.1f;

    Vector3 rotacionMuerta = new Vector3(0, 0, 120);

    // Start is called before the first frame update
    void Start()
    {
        velocidad = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && estaViva)
        {
            velocidad = Vector2.up * flapForce;
        }

        velocidad += Vector2.down * gravedad * Time.deltaTime;
        if (velocidad.y < -gravedad)
        {
            velocidad.y = -gravedad;
        }

        if (estaViva)
        {
            float rotZ = velocidad.y > 0 ? 35 : -35;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotZ));
        }
        else {
            transform.Rotate(rotacionMuerta * Time.deltaTime);
        }

        transform.position += (Vector3)velocidad;
    }

    public void Matar()
    {
        if (estaViva)
        {
            estaViva = false;
            velocidad = Vector2.up * flapForce * 1.3f;
            GameManager.Instance.GameOver();
        }
    }
}

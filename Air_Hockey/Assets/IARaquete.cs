using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IARaquete : MonoBehaviour
{
    public Transform disco;
    public float speed = 3.0f;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Verifica se a bola está acima ou abaixo da raquete.
        if (disco.position.y > transform.position.y)
        {
            // Move a raquete para cima.
            rb2d.velocity = new Vector2(0, speed);
        }
        else if (disco.position.y < transform.position.y)
        {
            // Move a raquete para baixo.
            rb2d.velocity = new Vector2(0, -speed);
        }
        else
        {
            // Se a bola estiver na mesma altura que a raquete, pare de se mover.
            rb2d.velocity = Vector2.zero;
        }
    }
}

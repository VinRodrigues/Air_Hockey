using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 10.0f;
    public float boundY = 2.25f;
    public float minX = -1.0f;
    public float maxX = 10.0f;
    public float minY = -10.25f;
    public float maxY = 10.25f;

    public Rigidbody2D ballRigidbody; // Referência para o Rigidbody2D da bola.
    public float impactForce = 10.0f; // Força de impacto adicional a ser aplicada à bola.

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var pos = transform.position;

        pos.x = Mathf.Clamp(mousePos.x, minX, maxX);
        pos.y = Mathf.Clamp(mousePos.y, minY, maxY);

        transform.position = pos;
    }

    // Método para lidar com o impacto da raquete na bola.
    public void HitBall()
    {
        if (ballRigidbody != null)
        {
            // Calcule a intensidade do impacto com base na velocidade da raquete.
            float intensity = rb2d.velocity.magnitude;

            // Aplique uma força adicional à bola com base na intensidade.
            Vector2 impactDirection = (ballRigidbody.position - rb2d.position).normalized;
            ballRigidbody.AddForce(impactDirection * impactForce * intensity);
        }
    }
}

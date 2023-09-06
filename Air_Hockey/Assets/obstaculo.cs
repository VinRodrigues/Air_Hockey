using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaculo : MonoBehaviour
{
    private Vector3 initialPosition;
    private bool isDestroyed = false;

    private void Start()
    {
        // Salve a posição inicial do objeto.
        initialPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Disco") && !isDestroyed)
        {
            // Destrua o objeto quando atingido pela bola.
            Destroy(gameObject);
            isDestroyed = true;
        }
    }

    // Método para restaurar o objeto à sua posição inicial.
    public void ResetObject()
    {
        if (isDestroyed)
        {
            
            Instantiate(gameObject, initialPosition, Quaternion.identity);
            isDestroyed = false;
        }
    }
}

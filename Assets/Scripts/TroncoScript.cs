using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncoScript : MonoBehaviour
{
    // Variável para determinar a velocidade dos obstáculos
    private float velocidade = 4f;

    void Update ()
    {
        // Move o tronco para a esquerda
        transform.position += Vector3.left * velocidade * Time.deltaTime;
    }
}

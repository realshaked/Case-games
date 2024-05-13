using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chão : MonoBehaviour
{
    // Variável para determinar a velocidade que o chão se move
    private float velocidade = 4f;
    
    // Variável para limitar até onde o chão vai antes de reiniciar sua posição
    private float limite = -0.5f;

    void Update ()
    {
        // Move o chão para a esquerda
        transform.position += Vector3.left * velocidade * Time.deltaTime;

        // Reinicia a posição do chão quando ele atinge o limite, a fim de dar a ilusão de movimento
        if (transform.position.x < limite)
            transform.position = new Vector2 (-limite, transform.position.y);
    }
}

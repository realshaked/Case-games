using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chão : MonoBehaviour
{
    // Variável para determinar a velocidade que o chão se move
    private float velocidade = 4f;

    void Update ()
    {
        // Move o chão para a esquerda
        transform.position += Vector3.left * velocidade * Time.deltaTime;

        // Reinicia a posição do chão quando ele atinge um limite, a fim de dar a ilusão de movimento
        if (transform.position.x < -0.5f)
            transform.position = new Vector2 (0.5f, transform.position.y);
    }
}

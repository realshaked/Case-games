using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncoScript : MonoBehaviour
{
    // Variável para determinar a velocidade dos obstáculos
    private float velocidade = 4f;
    
    // Variável para limitar até onde o tronco pode ir na tela
    private float limite = -13f;

    void Update ()
    {
        // Move o tronco para a esquerda
        transform.position += Vector3.left * velocidade * Time.deltaTime;

        // Limita o quanto o tronco pode ir para a esquerda a fim de que ele não se mova infinitamente
        transform.position = new Vector2 (Mathf.Clamp (transform.position.x, limite, float.MaxValue), transform.position.y);
    }
}

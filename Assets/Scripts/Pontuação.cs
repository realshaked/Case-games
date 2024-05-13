using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pontuação : MonoBehaviour
{
    // Variável para armazenar o texto
    public TextMeshPro pontuacaoTexto;

    // Variável para manter a pontuação
    private int pontuacao = 0;

    void Start ()
    {
        // Inicializa a pontuação
        pontuacaoTexto.text = "" + pontuacao;
    }

    // Detecta quando o pássaro atravessa um obstáculo
    void OnTriggerEnter2D (Collider2D colisor)
    {
        // Incrementa a pontuação
        pontuacao++;

        // Atualiza a pontuação na tela
        pontuacaoTexto.text = "" + pontuacao;
    }
}

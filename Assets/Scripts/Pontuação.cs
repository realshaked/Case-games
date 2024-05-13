using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pontuação : MonoBehaviour
{
    // Variável para armazenar o texto
    public TextMeshPro pontuacaoTexto;

    // Variável para manter a pontuação do jogo atual
    private static int pontuacaoAtual = 0;

    // Variável para manter a maior pontuação já obtida
    private static int maiorPontuacao = 0;

    void Start ()
    {
        // Inicializa a maior pontuação
        maiorPontuacao = PlayerPrefs.GetInt ("Maior pontuação", 0);
    }

    // Detecta quando o pássaro atravessa um obstáculo
    void OnTriggerEnter2D (Collider2D colisor)
    {
        // Incrementa a pontuação
        pontuacaoAtual++;

        // Atualiza a pontuação na tela
        pontuacaoTexto.text = "" + pontuacaoAtual;
    }

    public static void AtualizaMaiorPontuacao ()
    {
        // Avalia se a pontuação obtida é maior que a maior pontuação
        if (pontuacaoAtual > maiorPontuacao)
        {
            // Atualiza a maior pontuação
            maiorPontuacao = pontuacaoAtual;

            // Atualiza o registro da maior pontuação
            PlayerPrefs.SetInt ("Maior pontuação", maiorPontuacao);
        }
    }
}

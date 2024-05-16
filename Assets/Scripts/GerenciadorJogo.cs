using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GerenciadorJogo : MonoBehaviour
{
    // Variável que mantém a pontuação atual
    private int pontuacao;

    // Variável que mantém o objeto do pássaro
    public GameObject passaro;

    // Variáveis que mantém os textos da pontuação atual e da maior pontuação
    public TextMeshPro pontuacaoTexto;
    public TextMeshPro maiorPontuacaoTexto;

    // Variáveis que mantém os elementos gráficos do jogo
    public GameObject titulo;
    public GameObject perdeu;
    public GameObject botaoJogar;
    public GameObject botaoSkins;
    public GameObject botaoSair;
    public GameObject botaoPause;
    public GameObject botaoMenu;
    public GameObject botaoVoltar;

    public void Awake ()
    {
        // Chama a função 'Pausar'
        Pausar ();
    }

    // Método chamado ao clicar no botão 'Jogar'
    public void Jogar ()
    {
        // Desativa o objeto do pássaro
        passaro.SetActive (false);
        
        // Inicializa a pontuação
        pontuacao = 0;

        // Atualiza o placar na tela
        pontuacaoTexto.text = pontuacao.ToString ();

        // Determina os elementos gráficos visíveis e não visíveis durante o estado de jogo
        botaoPause.SetActive (true);
        botaoJogar.SetActive (false);
        botaoSkins.SetActive (false);
        botaoSair.SetActive (false);
        perdeu.SetActive (false);
        titulo.SetActive (false);
        botaoMenu.SetActive (false);

        // Remove o texto de maior pontuação da tela
        maiorPontuacaoTexto.text = "";

        // Cria um vetor de elementos para armazenar os troncos existentes no jogo
        TroncoScript[] troncos = FindObjectsOfType<TroncoScript>();

        // Destrói os troncos presentes no jogo para reiniciar
        for (int i = 0; i < troncos.Length; i++)
            Destroy (troncos[i].gameObject);

        // Descongela o tempo
        Time.timeScale = 1;

        // Ativa o objeto pássaro
        passaro.SetActive (true);
    }

    // Método chamado ao clicar no botão 'Pause'
    public void menuPause ()
    {
        // Congela o tempo
        Time.timeScale = 0;

        // Determina os elementos gráficos visíveis e não visíveis no menu de pausa
        botaoPause.SetActive (false);
        botaoSair.SetActive (true);
        botaoVoltar.SetActive (true);
        botaoMenu.SetActive (true);
    }

    // Método chamado ao clicar no botão 'Voltar'
    public void Voltar ()
    {
        // Determina os elementos gráficos visíveis e não visíveis ao voltar para o jogo
        botaoSair.SetActive (false);
        botaoMenu.SetActive (false);
        botaoVoltar.SetActive (false);
        botaoPause.SetActive (true);

        // Obtém o elemento do corpo do pássaro
        Rigidbody2D corpo = passaro.GetComponent<Rigidbody2D> ();

        // Reinicia a valocidade do pássaro
        corpo.velocity = Vector2.zero;

        // Chama um método para despausar após 2 segundos
        StartCoroutine (Despausar ());
    }

    // Método para despausar o jogo
    public IEnumerator Despausar ()
    {
        // Inicia um timer de 3 segundos para realizar a próxima ação
        yield return new WaitForSecondsRealtime (2);

        // Descongela o jogo
        Time.timeScale = 1;
    }

    public void Menu ()
    {
        // Determina os elementos gráficos visíveis e não visíveis no menu
        botaoVoltar.SetActive (false);
        botaoMenu.SetActive (false);
        perdeu.SetActive (false);
        botaoJogar.SetActive (true);
        botaoSkins.SetActive (true);
        titulo.SetActive (true);

        // Remove os textos de pontuação e maior pontuação da tela
        pontuacaoTexto.text = "";
        maiorPontuacaoTexto.text = "";

        // Cria um vetor de elementos para armazenar os troncos existentes no jogo
        TroncoScript[] troncos = FindObjectsOfType<TroncoScript>();

        // Destrói os troncos presentes no jogo para reiniciar
        for (int i = 0; i < troncos.Length; i++)
            Destroy (troncos[i].gameObject);

        // Chama a função 'Pausar'
        Pausar ();
    }

    // Método para congelar o tempo e desativar o objeto do pássaro
    public void Pausar ()
    {
        // Para o tempo
        Time.timeScale = 0;

        // Desativa o objeto do pássaro
        passaro.SetActive (false);
    }

    // Método chamado sempre que o pássaro atravessa um obstáculo
    public void IncrementarPontuacao ()
    {
        // Incrementa a pontuação em uma unidade
        pontuacao++;

        // Atualiza a pontuação na tela
        pontuacaoTexto.text = pontuacao.ToString ();
    }

    // Método chamado quando o jogador perde
    public void Perdeu ()
    {
        // Determina os elementos gráficos visíveis e não visíveis na tela de derrota
        perdeu.SetActive (true);
        botaoJogar.SetActive (true);
        botaoSair.SetActive (true);
        botaoMenu.SetActive (true);
        botaoPause.SetActive (false);

        // Armazena a maior pontuação obtida
        int maiorPontuacao = PlayerPrefs.GetInt ("Maior pontuação", 0);

        // Verifica se a pontuação atual superou a maior pontuação
        if (pontuacao > maiorPontuacao)
        {
            // Atualiza a variável da maior pontuação
            maiorPontuacao = pontuacao;

            // Atualiza a maior pontuação na memória
            PlayerPrefs.SetInt ("Maior pontuação", maiorPontuacao);
        }

        // Mostra a maior pontuação na tela
        maiorPontuacaoTexto.text = "Maior pontuação: " + maiorPontuacao;

        // Congela o jogo
        Time.timeScale = 0;
    }

    // Método chamado ao clicar no botão 'Sair'
    public void Sair ()
    {
        // Fecha o jogo
        Application.Quit ();
    }
}

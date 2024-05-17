using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GerenciadorJogo : MonoBehaviour
{
    // Variável que mantém a pontuação atual
    private int pontuacao;

    // Vetor que contém as skins
    public GameObject[] skins = new GameObject[2];

    // Variável que armazena o objeto do pássaro
    private GameObject passaro;

    // Variáveis que mantém os textos da pontuação atual e da maior pontuação
    public TextMeshPro pontuacaoTexto;
    public TextMeshPro maiorPontuacaoTexto;

    // Variáveis que mantém os elementos de interface do jogo
    public GameObject titulo;
    public GameObject perdeu;
    public GameObject botaoJogar;
    public GameObject botaoSkins;
    public GameObject botaoSair;
    public GameObject botaoPause;
    public GameObject botaoMenu;
    public GameObject botaoVoltar;
    public GameObject botaoVolume;
    public GameObject botaoCreditos;
    public GameObject controladorVolume;
    public GameObject botaoVoltarMenuInicial;
    public GameObject seletorSkins;

    // Variáveis que mantém os áudios do jogo
    public AudioSource somVoo;
    public AudioSource somPontos;
    public AudioSource somColisao;
    public AudioSource soundtrack;

    private void Awake ()
    {
        // Limita o jogo para rodar a 60 frames por segundo
        Application.targetFrameRate = 60;

        // Atualiza a skin no jogo
        passaro = skins[0];

        // Chama a função 'Pausar'
        Pausar ();
    }

    // Método chamado ao clicar no botão 'Jogar'
    private void Jogar ()
    {
        // Desativa o objeto do pássaro
        passaro.SetActive (false);
        
        // Inicializa a pontuação
        pontuacao = 0;

        // Atualiza o placar na tela
        pontuacaoTexto.text = pontuacao.ToString ();

        // Determina os elementos de interface visíveis e não visíveis durante o estado de jogo
        botaoPause.SetActive (true);
        botaoVolume.SetActive (false);
        botaoCreditos.SetActive (false);
        botaoJogar.SetActive (false);
        botaoSkins.SetActive (false);
        botaoSair.SetActive (false);
        botaoMenu.SetActive (false);
        titulo.SetActive (false);
        perdeu.SetActive (false);
        controladorVolume.SetActive (false);

        // Remove o texto de maior pontuação da tela
        maiorPontuacaoTexto.text = "";

        // Cria um vetor de elementos para armazenar os troncos existentes no jogo
        TroncoScript[] troncos = FindObjectsOfType<TroncoScript> ();

        // Destrói os troncos presentes no jogo para reiniciar
        for (int i = 0; i < troncos.Length; i++)
            Destroy (troncos[i].gameObject);

        // Descongela o tempo
        Time.timeScale = 1;

        // Ativa o objeto pássaro
        passaro.SetActive (true);

        // Inicializa a música de fundo
        soundtrack.Play ();
    }

    // Método chamado ao clicar no botão 'Skins'
    private void Skins ()
    {
        // Determina os elementos de interface visíveis e não visíveis no menu de skins
        botaoJogar.SetActive (false);
        botaoSair.SetActive (false);
        botaoCreditos.SetActive (false);
        botaoVolume.SetActive (false);
        botaoSkins.SetActive (false);
        controladorVolume.SetActive (false);
        titulo.SetActive (false);
        botaoVoltarMenuInicial.SetActive (true);
        seletorSkins.SetActive (true);
    }

    // Método que lida com o seletor de skins
    public void SeletorSkins (int numero)
    {
        // Coloca a skin selecionada como pássaro atual
        passaro = skins[numero];
    }

    // Método chamado ao clicar no botão 'Volume'
    private void Volume ()
    {
        // Ativa/Desativa o controlador de volume
        if (controladorVolume.activeSelf)
            controladorVolume.SetActive (false);
        else
            controladorVolume.SetActive (true);
    }

    // Método chamado ao clicar no botão 'Créditos'
    private void Creditos ()
    {
        // Determina os elementos de interface visíveis e não visíveis no menu de créditos
        botaoJogar.SetActive (false);
        botaoSkins.SetActive (false);
        botaoSair.SetActive (false);
        botaoCreditos.SetActive (false);
        botaoVolume.SetActive (false);
        controladorVolume.SetActive (false);
        titulo.SetActive (false);
        botaoVoltarMenuInicial.SetActive (true);
    }

    // Método que lida com o controlador de volume
    private void ControladorVolume (float volume)
    {
        // Atualiza o volume dos sons no jogo
        somColisao.volume = volume;
        somPontos.volume = volume;
        somVoo.volume = volume;
        soundtrack.volume = volume;
    }

    // Método chamado ao clicar no botão 'Pause'
    private void menuPause ()
    {
        // Congela o tempo
        Time.timeScale = 0;

        // Pausa a música
        soundtrack.Pause ();

        // Determina os elementos de interface visíveis e não visíveis no menu de pausa
        botaoPause.SetActive (false);
        botaoSair.SetActive (true);
        botaoVoltar.SetActive (true);
        botaoMenu.SetActive (true);
        botaoVolume.SetActive (true);
    }

    // Método chamado ao clicar no botão 'Voltar'
    private void Voltar ()
    {
        // Determina os elementos de interface visíveis e não visíveis ao voltar para o jogo
        botaoSair.SetActive (false);
        botaoMenu.SetActive (false);
        botaoVoltar.SetActive (false);
        botaoVolume.SetActive (false);
        controladorVolume.SetActive (false);

        // Obtém o elemento do corpo do pássaro
        Rigidbody2D corpo = passaro.GetComponent<Rigidbody2D> ();

        // Reinicia a valocidade do pássaro
        corpo.velocity = Vector2.zero;

        // Chama um método para despausar após 2 segundos
        StartCoroutine (Despausar ());

        // Informa o jogador que o jogo voltará em 2 segundos
        maiorPontuacaoTexto.text = "Despausando em 2...";
    }

    // Método para despausar o jogo
    private IEnumerator Despausar ()
    {
        // Inicia um timer de 1 segundo para realizar a próxima ação
        yield return new WaitForSecondsRealtime (1);

        // Informa o jogador que o jogo voltará em 1 segundo
        maiorPontuacaoTexto.text = "Despausando em 1...";

        // Inicia um timer de 1 segundo para realizar a próxima ação
        yield return new WaitForSecondsRealtime (1);

        // Apaga o texto da tela
        maiorPontuacaoTexto.text = "";

        // Descongela o jogo
        Time.timeScale = 1;

        // Retorna a visibilidade do botão de pause
        botaoPause.SetActive (true);

        // Despausa a música
        soundtrack.UnPause ();
    }

    // Método chamado ao clicar no botão 'Menu'
    private void Menu ()
    {
        // Determina os elementos de interface visíveis e não visíveis no menu
        botaoVoltar.SetActive (false);
        botaoMenu.SetActive (false);
        perdeu.SetActive (false);
        controladorVolume.SetActive (false);
        botaoVolume.SetActive (true);
        botaoCreditos.SetActive (true);
        botaoJogar.SetActive (true);
        botaoSkins.SetActive (true);
        titulo.SetActive (true);

        // Remove os textos de pontuação e maior pontuação da tela
        pontuacaoTexto.text = "";
        maiorPontuacaoTexto.text = "";

        // Cria um vetor de elementos para armazenar os troncos existentes no jogo
        TroncoScript[] troncos = FindObjectsOfType<TroncoScript> ();

        // Destrói os troncos presentes no jogo para reiniciar
        for (int i = 0; i < troncos.Length; i++)
            Destroy (troncos[i].gameObject);

        // Chama a função 'Pausar'
        Pausar ();
    }

    // Método chamado quando o botão 'Voltar' é clicado nos menus de skins e créditos
    private void VoltarMenuInicial ()
    {
        // Determina os elementos de interface visíveis e não visíveis na tela inicial do jogo
        botaoJogar.SetActive (true);
        botaoSair.SetActive (true);
        botaoSkins.SetActive (true);
        botaoCreditos.SetActive (true);
        botaoVolume.SetActive (true);
        titulo.SetActive (true);
        botaoVoltarMenuInicial.SetActive (false);
        seletorSkins.SetActive (false);
    }

    // Método para congelar o tempo e desativar o objeto do pássaro
    private void Pausar ()
    {
        // Congela o tempo
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

        // Toca o som de pontos
        somPontos.Play ();
    }

    // Método chamado quando o jogador perde
    public void Perdeu ()
    {
        // Toca o som de colisão
        somColisao.Play ();

        // Para a música de fundo
        soundtrack.Stop ();

        // Determina os elementos de interface visíveis e não visíveis na tela de derrota
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

        // Congela o tempo
        Time.timeScale = 0;
    }

    // Método para tocar o som de vôo
    public void PlaySomVoo ()
    {
        // Toca o som de vôo
        somVoo.Play ();
    }

    // Método chamado ao clicar no botão 'Sair'
    private void Sair ()
    {
        // Fecha o jogo
        Application.Quit ();
    }
}
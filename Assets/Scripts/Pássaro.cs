using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pássaro : MonoBehaviour
{
    // Variável que determina a velocidade vertical do pássaro
    private float velocidadeVertical = 6f;

    // Variável de tempo para limitar o som de ser tocado infinitamente
    private float tempo = 0.5f;

    // Variável para guardar o corpo do pássaro
    public Rigidbody2D passaro;

    // Variável para armazenar o gerenciador do jogo
    public GerenciadorJogo gerenciador;

    public void Awake ()
    {
        // Pega o componente do corpo do pássaro
        passaro = GetComponent<Rigidbody2D> ();

        // Pega o gerenciador do jogo
        gerenciador = FindObjectOfType<GerenciadorJogo>();
    }

    public void Update () {
        // Atualiza o contador de tempo
        tempo += Time.deltaTime;

        // Detecta se o botão foi pressionado
        if (Input.GetMouseButtonDown (0)) {
            // Faz o pássaro ir para cima
            passaro.velocity = Vector2.up * velocidadeVertical;

            // Analisa se o jogo não está congelado
            if (Time.timeScale != 0)
            {
                // Analisa se já se passou um tempo desde a última vez que o áudio foi tocado
                if (tempo >= 0.5f)
                {
                    // Toca o som de vôo
                    gerenciador.PlaySomVoo ();

                    // Reinicia o contador de tempo
                    tempo = 0;
                }
            }
        }

        // Detecta se há toque na tela
        if (Input.touchCount > 0)
        {
            // Armazena o primeiro toque na tela
            Touch toque = Input.GetTouch (0);

            // Detecta a fase do toque (no caso, apenas encostar na tela é condição suficiente)
            if (toque.phase == TouchPhase.Began)
            {
                // Faz o pássaro ir para cima
                passaro.velocity = Vector2.up * velocidadeVertical;

                // Analisa se o jogo não está congelado
                if (Time.timeScale != 0)
                {
                    // Analisa se já se passou um tempo desde a última vez que o áudio foi tocado
                    if (tempo >= 0.5f)
                    {
                        // Toca o som de vôo
                        gerenciador.PlaySomVoo ();

                        // Reinicia o contador de tempo
                        tempo = 0;
                    }
                }
            }
        }

        // Aplica gravidade
        passaro.velocity += Vector2.down * 10f * Time.deltaTime;

        // Limita velocidade vertical
        passaro.velocity = new Vector2 (0, Mathf.Clamp (passaro.velocity.y, -velocidadeVertical, velocidadeVertical));

        // Rotação do pássaro
        float rotacao = passaro.velocity.y * 10f;

        // Suaviza e limita a rotação do pássaro
        transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, Mathf.Clamp (rotacao, -50f, 30f)), 4f * Time.deltaTime);
    }

    public void OnEnable ()
    {
        // Reinicia a posição do pássaro
        transform.position = new Vector2 (transform.position.x, 0);

        // Reinicia a velocidade do pássaro
        passaro.velocity = Vector2.zero;

        // Reinicia a rotação do pássaro
        transform.rotation = Quaternion.Euler (0, 0, 0);
    }

    public void OnCollisionEnter2D (Collision2D colisao) {
        // Acessa a função que gerencia a tela de perder no jogo
        gerenciador.Perdeu ();
    }

    public void OnTriggerEnter2D (Collider2D colisor)
    {
        // Acessa a função que gerencia a pontuação
        gerenciador.IncrementarPontuacao ();
    }
}

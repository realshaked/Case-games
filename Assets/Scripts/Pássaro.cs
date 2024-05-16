using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pássaro : MonoBehaviour
{
    // Variável que determina a velocidade vertical do pássaro
    private float velocidadeVertical = 6f;

    // Variável para guardar o corpo do pássaro
    public Rigidbody2D passaro;

    public void Update () {
        // Detecta se o botão foi pressionado
        if (Input.GetMouseButtonDown (0)) {
            // Faz o pássaro ir para cima
            passaro.velocity = Vector2.up * velocidadeVertical;
        }

        // Detecta se há toque na tela
        if (Input.touchCount > 0)
        {
            // Armazena o primeiro toque na tela
            Touch toque = Input.GetTouch (0);

            // Detecta a fase do toque (no caso, apenas encostar na tela é condição suficiente)
            if (toque.phase == TouchPhase.Began)
                // Faz o pássaro ir para cima
                passaro.velocity = Vector2.up * velocidadeVertical;
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
        // Obtém o componente do corpo do pássaro
        passaro = GetComponent<Rigidbody2D> ();

        // Reinicia a posição do pássaro
        transform.position = new Vector2 (transform.position.x, 0);

        // Reinicia a velocidade do pássaro
        passaro.velocity = Vector2.zero;

        // Reinicia a rotação do pássaro
        transform.rotation = Quaternion.Euler (0, 0, 0);
    }

    public void OnCollisionEnter2D (Collision2D colisao) {
        // Obtém o objeto gerenciador do jogo
        GerenciadorJogo gerenciador = FindObjectOfType<GerenciadorJogo>();

        // Acessa a função que gerencia a tela de perder no jogo
        gerenciador.Perdeu ();
    }

    public void OnTriggerEnter2D (Collider2D colisor)
    {
        // Obtém o objeto gerenciador do jogo
        GerenciadorJogo gerenciador = FindObjectOfType<GerenciadorJogo>();

        // Acessa a função que gerencia a pontuação
        gerenciador.IncrementarPontuacao ();
    }
}

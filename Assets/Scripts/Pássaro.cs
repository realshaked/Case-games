using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pássaro : MonoBehaviour
{
    // Variável que determina a velocidade vertical do pássaro
    private float velocidadeVertical = 6f;

    // Variável para guardar o componente do pássaro
    public Rigidbody2D passaro;

    void Start () {
        // Obtém o componente do pássaro
        passaro = GetComponent<Rigidbody2D> ();
    }

    void Update () {
        // Detecta se o botão foi pressionado (temporário para testes, vai virar touch depois -> mobile)
        if (Input.GetMouseButtonDown (0)) {
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
        transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, Mathf.Clamp (rotacao, -30f, 30f)), 4f * Time.deltaTime);
    }

    void OnCollisionEnter2D (Collision2D colisao) {
        // Parar o jogo quando o pássaro colidir com algo
        Time.timeScale = 0f;

        // Atualiza a maior pontuação se necessário
        Pontuação.AtualizaMaiorPontuacao ();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncoSpawner : MonoBehaviour
{
    // Variável do tipo GameObject para armazenar o tronco a ser gerado
    public GameObject tronco;

    // Variável que determina a variação máxima de altura dos obstáculos
    private float variaçãoAltura = 4f;

    // Variável que determina o intervalo entre o spawn dos troncos
    private float tempoSpawn = 1.5f;

    // Variável que mantém controle de um contador de tempo
    private float tempo;

    // Variável que mantém a altura de um obstáculo, que será utilizada para embasar a altura do próximo obstáculo gerado
    private float altura;

    private void Start ()
    {
        // Chama a função para spawnar obstáculos
        troncoSpawner ();
    }

    private void Update ()
    {
        // Atualiza o contador de tempo
        tempo += Time.deltaTime;
        
        // Analisa se já passaram-se 'tempoSpawn' segundos desde o último spawn
        if (tempo >= tempoSpawn)
        {
            // Chama a função para spawnar obstáculos
            troncoSpawner ();

            // Reseta o contador
            tempo = 0;            
        }

    }

    // Método para gerar clones do tronco original
    private void troncoSpawner ()
    {
        // Gera uma instância de tronco (clone do tronco original)
        GameObject troncoClone = Instantiate (tronco);

        // Realiza um cálculo aleatório na altura de spawn, limitando-a para que não impossibilite o jogador de passar o obstáculo
        if (altura > -2f)
            altura = Random.Range (-variaçãoAltura, variaçãoAltura);
        else
            altura = Random.Range (-variaçãoAltura, variaçãoAltura - 3f);

        // Atualiza a altura do obstáculo
        troncoClone.transform.position = transform.position + new Vector3 (0, altura);

        // Realiza a destruição do objeto após ele sair da tela, para que não ocupe espaço desnecessário em memória
        Destroy (troncoClone, 4.5f);
    }
}

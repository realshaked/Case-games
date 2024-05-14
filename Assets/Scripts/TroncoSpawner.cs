using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncoSpawner : MonoBehaviour
{
    // Variáveis do tipo GameObject armazenam um objeto do jogo, no caso, irão armazenar o tronco base e os seus clones
    public GameObject tronco;
    public GameObject troncoClone;

    // Variável que determina a variação máxima de altura dos canos
    private float variaçãoAltura = 4f;

    // Variável que determina o intervalo entre o spawn dos troncos
    private float tempoSpawn = 1.5f;

    // Variável que determina o tempo até os troncos serem despawnados
    private float tempoDespawn = 4.5f;

    // Variável que mantém controle de um contador de tempo
    private float tempo = 0;

    // Variavel que mantém a altura de um obstáculo, que será utilizada para embasar a altura do próximo obstáculo gerado
    private float altura = 0;

    // Variável que mantém o controle de variância para casos extremos, a fim de que não existam padrões impossíveis de serem superados
    private float variancia = -2.5f;

    void Start ()
    {
        // Chama a função para spawnar os obstáculos
        troncoSpawner ();
    }

    void Update ()
    {
        // Atualiza o contador de tempo
        tempo += Time.deltaTime;
        
        // Analisa se já se passou mais de 'tempoSpawn' segundos desde o último spawn
        if(tempo >= tempoSpawn)
        {
            // Chama a função para spawnar obstáculos
            troncoSpawner ();

            // Reseta o contador
            tempo = 0;            
        }

    }

    // Método para gerar clones do tronco original
    void troncoSpawner()
    {
        // Gera uma instância de tronco (clone do tronco original)
        troncoClone = Instantiate (tronco);

        // Realiza um cálculo aleatório na altura de spawn, limitando-a para que não impossibilite o jogador de passar o obstáculo
        if (altura > variancia)
            altura = Random.Range (-variaçãoAltura, variaçãoAltura);
        else
            altura = Random.Range (-variaçãoAltura, variaçãoAltura + variancia);

        // Atualiza a altura do obstáculo
        troncoClone.transform.position = transform.position + new Vector3 (0, altura, 0);

        // Realiza a destruição do objeto após 'tempoDespawn' segundos, para que não ocupe espaço desnecessário em memória
        Destroy (troncoClone, tempoDespawn);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class troncoSpaw : MonoBehaviour
{
    public float tempoMaximo;
    private float tempo;
    public GameObject tronco;
    GameObject troncoClone;
    public float distancia;

    // Start is called before the first frame update
    void Start()
    {
        troncoSpawner();

    }

    // Update is called once per frame
    void Update()
    {
        //apos um certo tempo maximo, outro tronco pela chamada do metodo troncoSpawner()
        //apos esse limite de tempo = 0.5 segundos, os obstaculos sao destruidos
        //dessa forma, da tempo deles passarem pela tela completamente sem afetar a jogabilidade
        //e a memoria do computador
        
        if(tempo > (tempoMaximo+0.5f))
        {
            Destroy(troncoClone);
            troncoSpawner();
            tempo = 0;            
        }

        tempo += Time.deltaTime;

    }

    //método que gera clones do tronco original
    
    void troncoSpawner()
    {
        //gerando uma instância (clones do tronco original)
        troncoClone = Instantiate(tronco);

        //muda a altura das instancias de forma aleatória
        //o metodo new Vector3(x,y,z) recebe tres coordenadas
        //como ja temos um script pra movimentar o obstaculo, x=0 e z=0
        troncoClone.transform.position = transform.position + new Vector3(0, Random.Range(distancia, -distancia), 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //variável troncoVelocidade (através dela podemos determinar a velocidade dos obstáculos)
    public float troncoVelocidade;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //chamada do método moverTronco()
    void Update()
    {
        moverTronco();
    }
    
    //Métoddo para movimentar o tronco para esquerada

    void moverTronco()
    {
        transform.position += Vector3.left * troncoVelocidade * Time.deltaTime;
    }
}

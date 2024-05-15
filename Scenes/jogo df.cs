using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class jogodf : MonoBehaviour
{
    public GameObject painelOpcao; // Referencia ao painel que queremos abrir
    public GameObject painelMenuInicial;
    // Funçao para ser chamada quando o botao Jogar for clicado
    public void Jogar()
    {
        // Coloque aqui o codigo para abrir o jogo
        Debug.Log("Abrindo o jogo...");
    }
    
    public void AbrirPainelOpcao()
    {
        // Ativar o painel quando o botao eh clicado
        painelOpcao.SetActive(true);
        painelMenuInicial.SetActive(false);
    }
    public void FecharOpcoes()
    {
     painelOpcao.SetActive(false);// Desativar o painel quando o jogo comeca
        painelMenuInicial.SetActive(true);
        
    }
     public void Sair()
    {
        // Fechar o aplicativo
        Application.Quit();
    }
}
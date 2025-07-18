using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuManager : MonoBehaviour
{

    // tela 0 - Bem-vindo
    public void Avancar0()
    {
        SceneManager.LoadScene(1);
    }

    public void Pular0()
    {
        SceneManager.LoadScene(2);
    }


    // tela 1 - Como usar
    public void Avancar1()
    {
        SceneManager.LoadScene(2);
    }
    public void Voltar1()
    {
        SceneManager.LoadScene(0);
    }


    // tela 2 - Termos1
    public void Quadrado1()
    {
        SceneManager.LoadScene(3);
    }
    public void Voltar2()
    {
        SceneManager.LoadScene(1);
    }


    // Tela 3 - Termos2 
    public void Avancar3()
    {
        SceneManager.LoadScene(4);
    }
    public void Voltar3()
    {
        SceneManager.LoadScene(2);
    }
    public void Quadrado2()
    {
        SceneManager.LoadScene(2);
    }


    //Tela 4 - Tela inicial
    public void Avancar4()
    {
        SceneManager.LoadScene(5);
    }


    //Tela 5 - Menu 
    public void Comecar5()
    {
        SceneManager.LoadScene(7);
    }

    public void ComoUsar()
    {
        SceneManager.LoadScene(6);
    }

    // Botao que direciona a pagina da matemateca 
    public void OpenURL()
    {
        Application.OpenURL("https://matemateca.ime.usp.br");
    }


    // Botao que direciona a pagina da PUB 2024
    public void OpenURL2()
    {
        Application.OpenURL("https://www.ime.usp.br/pub2024/https://docs.google.com/document/d/1OuxJp8augSKuZ6rLnI4MrBjUvQvX9GsL_PDsuVp_O3o/edit?tab=t.0");
    }

    public void Sair()
    {
        SceneManager.LoadScene(4);
    }


    //Tela 6 
    public void Entendi()
    {
        SceneManager.LoadScene(5);
    }

    //Tela 7 - Jogo 

    public void Sair2()
    {
        SceneManager.LoadScene(5);
    }
}
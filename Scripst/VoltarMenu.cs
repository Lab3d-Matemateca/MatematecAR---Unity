using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoltarMenu : MonoBehaviour
{
    [SerializeField] private string menuInicial;
    public void Menu()
    {
        SceneManager.LoadScene(menuInicial);
    }

}
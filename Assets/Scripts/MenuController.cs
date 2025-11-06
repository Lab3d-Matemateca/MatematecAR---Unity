using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button equidecomponibilidadeButton;
    public Button jogoDaVelhaButton;
    public string equidecomponibilidadeSceneName = "Equidecomponibilidade";
    public string jogoDaVelhaScene = "JogoDaVelha";

    void Start()
    {
        equidecomponibilidadeButton.onClick.AddListener(() => SceneManager.LoadScene(equidecomponibilidadeSceneName));
        jogoDaVelhaButton.onClick.AddListener(() => SceneManager.LoadScene(jogoDaVelhaScene));
    }
}

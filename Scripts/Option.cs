using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    public string gameStartScene; // Nome da cena que inicia o jogo

    void Start()
    {
        // Este método é chamado quando o script é inicializado
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        // Este método é chamado a cada frame
    }

    public void StartGame()
    {
        // Este método carrega a cena que inicia o jogo
        SceneManager.LoadScene(gameStartScene);
    }

    public void QuitGame()
    {
        // Este método fecha a aplicação
        Application.Quit();
    }
}
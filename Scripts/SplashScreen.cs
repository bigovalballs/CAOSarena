using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importando a biblioteca SceneManager para lidar com cenas

public class SplashScreen : MonoBehaviour
{
    public string sceneToLoad; // Nome da cena que será carregada após a tela de apresentação

    // Start é chamado antes da primeira atualização de frame
    void Start()
    {
        // Este método é chamado quando o script é inicializado
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        // Se qualquer tecla for pressionada
        if (Input.anyKeyDown)
        {
            // Carrega a cena especificada em sceneToLoad
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
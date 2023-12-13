using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; // Importa o namespace do Photon
using UnityEngine.SceneManagement; // Importa o namespace para manipulação de cenas

public class aaa : MonoBehaviourPunCallbacks // A classe herda de MonoBehaviourPunCallbacks para usar os callbacks do Photon
{
    // Start é chamado antes da atualização do primeiro frame
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // Conecta ao servidor do Photon usando as configurações definidas no Unity   
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        
    }

    // Método chamado quando o cliente se conecta ao servidor mestre
    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("Menu"); // Carrega a cena do menu
    }
}

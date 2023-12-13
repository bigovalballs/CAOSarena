using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class MainMenu : MonoBehaviourPunCallbacks
{
    public TMP_InputField CreateInput; // Campo de entrada para criar uma sala
    public TMP_InputField JoinInput; // Campo de entrada para entrar em uma sala

    // Método para criar uma sala
    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions(); // Cria uma nova instância de RoomOptions
        roomOptions.MaxPlayers = 2; // Define o número máximo de jogadores na sala para 2
        PhotonNetwork.CreateRoom(CreateInput.text, roomOptions); // Cria uma sala com o nome inserido no campo de entrada e as opções de sala definidas
    }

    // Método para entrar em uma sala
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(JoinInput.text); // Entra em uma sala com o nome inserido no campo de entrada
    }

    // Método chamado quando o jogador entra em uma sala
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Char Select"); // Carrega a cena de seleção de personagem quando o jogador entra na sala
    }
}

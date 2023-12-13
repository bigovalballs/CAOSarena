using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelectUI : MonoBehaviour
{
    public GameObject JoinText; // Objeto de texto para exibir a mensagem "Join"

    // Start é chamado antes da atualização do primeiro frame
    void Start()
    {
        
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        // Se o número de jogadores ativos for maior ou igual ao número máximo de jogadores
        if (GameManager.instance.activePlayers.Count >= GameManager.instance.maxPlayers)
        {
            // Desativa o texto "Join"
            JoinText.SetActive(false);
        }
        else
        {
            // Ativa o texto "Join"
            JoinText.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject player1ToLoad; // Objeto do jogador 1 para carregar
    public GameObject player2ToLoad; // Objeto do jogador 2 para carregar
    public GameObject player3ToLoad; // Objeto do jogador 3 para carregar

    private bool hasLoadedPlayer1; // Se o jogador 1 foi carregado
    private bool hasLoadedPlayer2; // Se o jogador 2 foi carregado
    private bool hasLoadedPlayer3; // Se o jogador 3 foi carregado

    // Start é chamado antes da atualização do primeiro frame
    void Start()
    {
        
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        // Se o jogador 1 não foi carregado e alguma das teclas W, A, S ou D foi pressionada
        if (!hasLoadedPlayer1 && (Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.sKey.wasPressedThisFrame || Keyboard.current.dKey.wasPressedThisFrame))
        {
            // Instancia o jogador 1 na posição e rotação do objeto
            Instantiate(player1ToLoad, transform.position, transform.rotation);
            hasLoadedPlayer1 = true; // Define que o jogador 1 foi carregado
        }
        // Se o jogador 2 não foi carregado e alguma das teclas I, L, K ou J foi pressionada
        else if (!hasLoadedPlayer2 && (Keyboard.current.iKey.wasPressedThisFrame || Keyboard.current.lKey.wasPressedThisFrame || Keyboard.current.kKey.wasPressedThisFrame || Keyboard.current.jKey.wasPressedThisFrame))
        {
            // Instancia o jogador 2 na posição e rotação do objeto
            Instantiate(player2ToLoad, transform.position, transform.rotation);
            hasLoadedPlayer2 = true; // Define que o jogador 2 foi carregado
        }
        // Se o jogador 3 não foi carregado e alguma das teclas de seta foi pressionada
        else if (!hasLoadedPlayer3 && (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.leftArrowKey.isPressed || Keyboard.current.upArrowKey.isPressed || Keyboard.current.downArrowKey.isPressed)) 
        {
            // Instancia o jogador 3 na posição e rotação do objeto
            Instantiate(player3ToLoad, transform.position, transform.rotation);
            hasLoadedPlayer3 = true; // Define que o jogador 3 foi carregado
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{
    // Start é chamado antes da primeira atualização de frame
    void Start()
    {
        // Este método é chamado quando o script é inicializado
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        // Este método é chamado a cada frame
    }

    // Este método é chamado quando um objeto entra no trigger dos espinhos
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Se o objeto que entrou no trigger tem a tag "Player"
        if(other.tag == "Player")
        {
            // Obtém a referência ao script PlayerController do jogador
            PlayerController thePlayer = other.GetComponent<PlayerController>();

            // Calcular a direção do impulso. A direção é calculada subtraindo a posição dos espinhos da posição do jogador, o que resulta em um vetor apontando do espinho para o jogador. O vetor é então normalizado para ter um comprimento de 1.
            Vector2 bounceDirection = (thePlayer.transform.position - transform.position).normalized;

            // Aplicar o impulso ao jogador. A direção do impulso é multiplicada por 30 para dar ao impulso uma quantidade significativa de força.
            thePlayer.theRB.velocity = bounceDirection * 30f;
        }
    }
}

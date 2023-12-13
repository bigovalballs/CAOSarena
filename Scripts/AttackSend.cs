using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSend : MonoBehaviour
{
    public float bounceX = 30f; // Força do impulso no eixo X
    public float bounceY = 30f; // Força do impulso no eixo Y

    // Start é chamado antes da atualização do primeiro frame
    void Start()
    {
        
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        
    }

    // OnTriggerEnter2D é chamado quando outro collider entra em contato com o trigger do objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que entrou em contato é o jogador
        if(other.tag == "Player")
        {
            // Obtém o componente PlayerController do jogador
            PlayerController thePlayer = other.GetComponent<PlayerController>();

            // Calcula a direção do impulso
            Vector2 bounceDirection = new Vector2();

            // Calcula o componente x da direção do impulso
            if (thePlayer.transform.position.x > transform.position.x)
            {
                // O jogador está à direita do objeto, então impulsiona para a esquerda
                bounceDirection.x = -1;
            }
            else
            {
                // O jogador está à esquerda do objeto, então impulsiona para a direita
                bounceDirection.x = 1;
            }

            // O componente y da direção do impulso é sempre para cima
            bounceDirection.y = 1;

            // Normaliza a direção do impulso para obter um vetor de comprimento 1
            bounceDirection = bounceDirection.normalized;

            // Aplica o impulso ao jogador
            thePlayer.theRB.velocity = bounceDirection * Mathf.Sqrt(bounceX * bounceX + bounceY * bounceY);

            // Ignora as colisões entre o jogador e as plataformas
            int playerLayer = LayerMask.NameToLayer("Player");
            int platformLayer = LayerMask.NameToLayer("Platforms");
            Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);

            // Reativa as colisões após um pequeno atraso
            StartCoroutine(EnableCollisionAfterDelay(playerLayer, platformLayer, 0.5f));
        }
    }

    // Coroutine para reativar as colisões após um atraso
    private IEnumerator EnableCollisionAfterDelay(int layer1, int layer2, float delay)
    {
        // Aguarda o tempo especificado
        yield return new WaitForSeconds(delay);
        // Reativa a colisão entre as camadas especificadas
        Physics2D.IgnoreLayerCollision(layer1, layer2, false);
    }
}


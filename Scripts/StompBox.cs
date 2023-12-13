using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompBox : MonoBehaviour
{
    public int stompDamage; // Dano causado pelo StompBox
    public float bounceForce = 12f; // Força de repulsão aplicada ao jogador quando ele colide com o StompBox
    public PlayerController thePlayer; // Referência ao controlador do jogador

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

    // Este método é chamado quando um objeto entra no trigger do StompBox
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Se o objeto que entrou no trigger tem a tag "Player"
        if(other.tag == "Player"){

            // Se o jogador pode lutar
            if(GameManager.instance.canFight){
                // Aplica dano ao jogador
                other.GetComponent<PlayerHealthController>().DamagePlayer(stompDamage);
            }

            // Aplica uma força de repulsão ao jogador, fazendo-o saltar
            thePlayer.theRB.velocity = new Vector2(thePlayer.theRB.velocity.x, bounceForce); 

            // Toca o efeito sonoro de número 1
            AudioManager.instance.PlaySFX(1); 
        }
    }
}

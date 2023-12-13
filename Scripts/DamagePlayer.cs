using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damageToDeal; // Quantidade de dano a ser causado

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
       // Verifica se o objeto que entrou em contato é o jogador e se o jogador pode lutar
       if(other.tag == "Player" && GameManager.instance.canFight){
            // Obtém o componente PlayerHealthController do jogador e causa dano ao jogador
            other.GetComponent<PlayerHealthController>().DamagePlayer(damageToDeal);
        }
    }
}

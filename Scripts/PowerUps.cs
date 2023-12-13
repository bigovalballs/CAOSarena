using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerUps : MonoBehaviour
{

    public bool isHealth, isInvincible, isSpeed, isGravity; // Variáveis booleanas para determinar o tipo de power-up
    public float powerUpLength, powerUpAmount; // Duração e quantidade do power-up
    public GameObject pickupEffect; // Efeito ao pegar o power-up;


    public event Action OnDestroyed; // Evento que é acionado quando o power-up é destruído
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     // Este método é chamado quando um objeto entra no trigger do power-up
    void OnTriggerEnter2D(Collider2D other)
    {
        // Se o objeto que entrou no trigger tem a tag "Player"
        if (other.tag == "Player"){

            // Se o power-up é de saúde
            if(isHealth){
                // Preenche a saúde do jogador
                other.GetComponent<PlayerHealthController>().FillHealth();

                // Cria um efeito na posição do power-up
                Instantiate(pickupEffect, transform.position, transform.rotation);

                // Destrói o power-up
                Destroy(gameObject);   
            }

            // Se o power-up é de invencibilidade
            if(isInvincible){   
                // Torna o jogador invencível por um determinado período de tempo
                other.GetComponent<PlayerHealthController>().MakeInvincible(powerUpLength);

                // Cria um efeito na posição do power-up
                Instantiate(pickupEffect, transform.position, transform.rotation);

                // Destrói o power-up
                Destroy(gameObject);  
            }

            // Se o power-up é de velocidade
            if(isSpeed){   
                // Aumenta a velocidade do jogador e define o contador do power-up
                PlayerController thePlayer = other.GetComponent<PlayerController>(); 
                thePlayer.moveSpeed = powerUpAmount;
                thePlayer.powerUpCounter = powerUpLength;

                // Destrói o power-up
                Destroy(gameObject);  
            }

            // Se o power-up é de gravidade
            if(isGravity)
            {
                // Altera a escala de gravidade do jogador e define o contador do power-up
                PlayerController thePlayer = other.GetComponent<PlayerController>();
                thePlayer.powerUpCounter = powerUpLength;
                thePlayer.theRB.gravityScale = powerUpAmount;

                // Destrói o power-up
                Destroy(gameObject);  
            }
        }
    }

    // Este método é chamado quando o power-up é destruído
    private void OnDestroy()
    {
        // Aciona o evento OnDestroyed
        OnDestroyed?.Invoke();
    }
}


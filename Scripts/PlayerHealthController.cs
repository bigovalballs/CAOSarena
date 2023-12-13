using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerHealthController : MonoBehaviour
{
    public int maxHealth = 3; // A saúde máxima do jogador
    private int currentHealth; // A saúde atual do jogador

    public SpriteRenderer[] heartDisplay; // O display do coração
    public Sprite heartFull, heartEmpty; // Os sprites para o coração cheio e vazio

    public Transform heartHolder; // O detentor do coração

    public float invicibilityTime, healthFlashTime = .2f; // O tempo de invencibilidade e o tempo de flash de saúde
    private float invicibilityCounter, flashCounter; // O contador de invencibilidade e o contador de flash

    // Start é chamado antes da primeira atualização de frame
    void Start()
    {
        currentHealth = maxHealth; // Define a saúde atual como a saúde máxima
    }

    // Update is called once per frame
    void Update()
    {
        // Se o contador de invencibilidade for maior que zero, diminui o contador de invencibilidade e o contador de flash
        // Se o contador de flash for menor que zero, reinicia o contador de flash e alterna a ativação do detentor do coração
        // Se o contador de invencibilidade for menor ou igual a zero, ativa o detentor do coração
        if(invicibilityCounter > 0){
            invicibilityCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if(flashCounter < 0){
                flashCounter = healthFlashTime;

                heartHolder.gameObject.SetActive(!heartHolder.gameObject.activeInHierarchy);
            }

            if(invicibilityCounter <= 0){
                heartHolder.gameObject.SetActive(true);
            }
        }
        
    }

    private void LateUpdate(){
        // Define a escala do detentor do coração como a escala do transform
        heartHolder.localScale = transform.localScale;
    }

    public void UpdateHealthDisplay()
    {
         // Atualiza o display do coração com base na saúde atual
        switch(currentHealth){
            case 3:
                heartDisplay[0].sprite = heartFull;
                heartDisplay[1].sprite = heartFull;
                heartDisplay[2].sprite = heartFull;
                break;
            case 2:
                heartDisplay[0].sprite = heartFull;
                heartDisplay[1].sprite = heartFull;
                heartDisplay[2].sprite = heartEmpty;
                break;
            case 1:
                heartDisplay[0].sprite = heartFull;
                heartDisplay[1].sprite = heartEmpty;
                heartDisplay[2].sprite = heartEmpty;
                break;
            case 0:
                heartDisplay[0].sprite = heartEmpty;
                heartDisplay[1].sprite = heartEmpty;
                heartDisplay[2].sprite = heartEmpty;
                break;


        }
    }

    public void DamagePlayer(int damageToTake){
        // Se o contador de invencibilidade for menor ou igual a zero, danifica o jogador
        // Se a saúde atual for menor ou igual a zero, define a saúde atual como zero
        // Atualiza o display do coração
        // Se a saúde atual for igual a zero, desativa o objeto do jogador e toca o efeito sonoro
        // Define o contador de invencibilidade como o tempo de invencibilidade
        if(invicibilityCounter <= 0){
            AudioManager.instance.PlaySFX(6);
            currentHealth -= damageToTake;
            if(currentHealth <= 0){
                currentHealth = 0;

            }
            UpdateHealthDisplay();

            if (currentHealth == 0){
                gameObject.SetActive(false);
                 AudioManager.instance.PlaySFX(4);
            } 

            invicibilityCounter = invicibilityTime; 
    }

    }

    public void FillHealth(){
        // Preenche a saúde do jogador, atualiza o display do coração, reinicia o contador de flash e o contador de invencibilidade, e ativa o detentor do coração
        currentHealth = maxHealth;
        UpdateHealthDisplay();

        flashCounter = 0;
        invicibilityCounter = 0;
        heartHolder.gameObject.SetActive(true);
    }

    public void MakeInvincible(float invincLenght){
        // Torna o jogador invencível por um determinado período de tempo
        invicibilityCounter = invincLenght;

    }
}

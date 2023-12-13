using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartGameChecker : MonoBehaviour
{
    public string levelToLoad; // Nome do nível para carregar

    private int playersInZone; // Número de jogadores na zona de início
    
    public TMP_Text startcountText; // Referência ao texto que mostra a contagem regressiva para iniciar o jogo

    public float timeToStart = 3f; // Tempo para iniciar o jogo
    private float startCounter; // Contador para iniciar o jogo

    // Start é chamado antes da primeira atualização de frame
    void Start()
    {
        // Este método é chamado quando o script é inicializado
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        // Se houver mais de um jogador na zona de início e o número de jogadores na zona for igual ao número de jogadores ativos
        if(playersInZone > 1 && playersInZone == GameManager.instance.activePlayers.Count){

            // Se o texto da contagem regressiva estiver ativo, toca um efeito sonoro
            if(startcountText.gameObject.activeInHierarchy){
                 AudioManager.instance.PlaySFX(3);
            }

            // Ativa o texto da contagem regressiva
            startcountText.gameObject.SetActive(true);
            
            // Diminui o contador de início pelo tempo decorrido desde o último frame
            startCounter -= Time.deltaTime;

            // Atualiza o texto da contagem regressiva para mostrar o valor arredondado para cima do contador de início
            startcountText.text = Mathf.CeilToInt(startCounter).ToString();

            // Se o contador de início chegar a zero
            if(startCounter <= 0){
                // Inicia a primeira rodada do jogo
                GameManager.instance.StartFirstRound();
            }
        }else
        {
            // Desativa o texto da contagem regressiva e reinicia o contador de início
            startcountText.gameObject.SetActive(false);
            startCounter = timeToStart;
        }
    }

    // Este método é chamado quando um objeto entra no trigger
    private void OnTriggerEnter2D(Collider2D other){

        // Se o objeto que entrou no trigger tem a tag "Player", incrementa o número de jogadores na zona
        if(other.tag == "Player"){
            playersInZone++;
        }
    }

    // Este método é chamado quando um objeto sai do trigger
    private void OnTriggerExit2D(Collider2D other){

        // Se o objeto que saiu do trigger tem a tag "Player", decrementa o número de jogadores na zona
        if(other.tag == "Player"){
            playersInZone--;
        }
    }
}

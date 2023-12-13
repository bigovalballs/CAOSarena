using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArenaManager : MonoBehaviour
{
    // Lista de pontos de spawn
    public List<Transform> spawnPoints = new List<Transform>();
    private List<Transform> occupiedSpawnPoints = new List<Transform>();
    // Variável para verificar se a rodada terminou
    private bool roundOver;
    // Texto que mostra o jogador vencedor
    public TMP_Text playerWinText;
    // Barra de vitória e texto de rodada completa
    public GameObject winBar, roundCompleteText;
    // Array de power-ups
    public GameObject[] powerUps;
    // Tempo entre os power-ups
    public float timeBetweenPowerUps;
    // Contador de power-ups
    private float powerUpCounter;


    // Start é chamado antes da primeira atualização de frame
    void Start()
    {
        
        // Para cada jogador na lista de jogadores ativos do GameManager
        foreach(PlayerController player in GameManager.instance.activePlayers){
            // Escolhe um ponto de spawn aleatório
            int randomPoint = Random.Range(0, spawnPoints.Count);
            // Posiciona o jogador no ponto de spawn
            player.transform.position = spawnPoints[randomPoint].position;
            // Remove o ponto de spawn usado
            spawnPoints.RemoveAt(randomPoint);
        }
        
        // Permite que os jogadores lutem
        GameManager.instance.canFight = true;
        // Ativa os jogadores
        GameManager.instance.ActivatePlayers();
        // Define o contador de power-ups para um valor aleatório entre 75% e 125% do tempo entre power-ups
        powerUpCounter = timeBetweenPowerUps * Random.Range(.75f, 1.25f);
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        // Se houver apenas um jogador ativo e a rodada não estiver terminada
        if(GameManager.instance.CheckActivePlayers() == 1 && !roundOver)
        {
        // Define que a rodada terminou
        roundOver = true;
        // Inicia a coroutine para terminar a rodada
        StartCoroutine(EndRoundCo());
        }
        
        
        if(powerUpCounter <= 0){
        // Check if all spawn points are occupied
        if (occupiedSpawnPoints.Count < spawnPoints.Count)
        {
            // Escolhe um ponto de spawn aleatório que não está ocupado
            Transform spawnPoint;
            do
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            } while (occupiedSpawnPoints.Contains(spawnPoint));

            if (powerUps.Length > 0)
            {
                // Instancia um power-up aleatório no ponto de spawn
                GameObject powerUp = Instantiate(powerUps[Random.Range(0, powerUps.Length)], spawnPoint.position, spawnPoint.rotation);
                Transform currentSpawnPoint = spawnPoint;
                occupiedSpawnPoints.Add(currentSpawnPoint);

                // Adiciona um listener ao evento OnDestroyed do power-up para remover o ponto de spawn da lista quando o power-up for destruído
                powerUp.GetComponent<PowerUps>().OnDestroyed += () => occupiedSpawnPoints.Remove(currentSpawnPoint);
            }
        }

        powerUpCounter = timeBetweenPowerUps * Random.Range(.75f, 1.25f);
    } else {
        // Diminui o contador de power-ups pelo tempo decorrido desde o último frame
        powerUpCounter -= Time.deltaTime;
    }
                


    }
    // Coroutine para terminar a rodada
    IEnumerator EndRoundCo(){
        // Ativa a barra de vitória, o texto de rodada completa e o texto do jogador vencedor
        winBar.SetActive(true);
        roundCompleteText.SetActive(true);
        playerWinText.gameObject.SetActive(true);
        // Define o texto do jogador vencedor
        playerWinText.text = "Player " + (GameManager.instance.lastPlayerNumber + 1 ) + " Wins!";
         // Adiciona uma vitória de rodada ao GameManager
        GameManager.instance.AddRoundWin();
        // Aguarda 3 segundos
        yield return new WaitForSeconds(3f);
        // Vai para a próxima arena
        GameManager.instance.GoToNextArena();
    }
}

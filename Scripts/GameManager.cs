using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int maxPlayers;
    public List<PlayerController> activePlayers = new List<PlayerController>();
    public GameObject PlayerSpawnEffect;
    
[HideInInspector]
public int lastPlayerNumber; // Último número de jogador

public bool canFight; // Se os jogadores podem lutar

public string[] allLevels; // Todos os níveis
private List<string> levelOrder = new List<string>(); // Ordem dos níveis

public int pointsToWin; // Pontos para ganhar
private List<int> roundWins = new List<int>(); // Vitórias por rodada

private bool gameWon; // Se o jogo foi ganho

public string winLevel; // Nível de vitória

private void Awake()
{
    if(instance == null)
    {
    DontDestroyOnLoad(gameObject); // Não destrói o objeto ao carregar uma nova cena
    instance = this; // Define esta instância como a instância principal
    }else
    {
        Destroy(gameObject); // Destroi o objeto se já existir uma instância
    }
}

// Start é chamado antes da atualização do primeiro frame
void Start()
{
    
}

// Update é chamado uma vez por frame
void Update()
{
    
}

// Adiciona um jogador à lista de jogadores ativos
public void AddPlayer(PlayerController newPlayer)
{
    if(activePlayers.Count < maxPlayers) // Se o número de jogadores ativos for menor que o número máximo de jogadores
    {
        activePlayers.Add(newPlayer); // Adiciona o novo jogador à lista de jogadores ativos
        Instantiate(PlayerSpawnEffect, newPlayer.transform.position, newPlayer.transform.rotation); // Instancia o efeito de spawn do jogador
    }else
    {
        Destroy(newPlayer.gameObject); // Destroi o objeto do novo jogador se o número máximo de jogadores já foi atingido
    }
}

// Ativa todos os jogadores e preenche a saúde deles
public void ActivatePlayers()
{
    foreach(PlayerController player in activePlayers)
    {
        player.gameObject.SetActive(true); // Ativa o jogador
        player.GetComponent<PlayerHealthController>().FillHealth(); // Preenche a saúde do jogador
    }
}

// Verifica o número de jogadores ativos
public int CheckActivePlayers()
{
    int playerAliveCount = 0; // Contador de jogadores vivos

    for(int i = 0; i < activePlayers.Count; i++)
    {
        if(activePlayers[i].gameObject.activeInHierarchy) // Se o jogador está ativo na hierarquia
        {
            playerAliveCount++; // Incrementa o contador de jogadores vivos
            lastPlayerNumber = i; // Define o último número de jogador
        }
    }

    return playerAliveCount; // Retorna o número de jogadores vivos
}

// Vai para a próxima arena
public void GoToNextArena(){ 
    //SceneManager.LoadScene(allLevels[Random.Range(0, allLevels.Length)]);
    if(!gameWon){ // Se o jogo não foi ganho

    if(levelOrder.Count == 0){ // Se a ordem dos níveis está vazia
        List<string> allLevelList = new List<string>();
        allLevelList.AddRange(allLevels); // Adiciona todos os níveis à lista de todos os níveis

        for(int i = 0; i < allLevels.Length; i++)
        {
            int selected = Random.Range(0, allLevelList.Count); // Seleciona um nível aleatório
            levelOrder.Add(allLevelList[selected]); // Adiciona o nível selecionado à ordem dos níveis
            allLevelList.RemoveAt(selected); // Remove o nível selecionado da lista de todos os níveis
        }
    }

    string levelToLoad = levelOrder[0]; // Define o nível a ser carregado
    levelOrder.RemoveAt(0); // Remove o nível a ser carregado da ordem dos níveis

    foreach(PlayerController player in activePlayers)
    {
        player.gameObject.SetActive(true); // Ativa o jogador
        player.GetComponent<PlayerHealthController>().FillHealth(); // Preenche a saúde do jogador
    }

    SceneManager.LoadScene(levelToLoad); // Carrega o nível
    }else
    {
        foreach(PlayerController player in activePlayers)
        {
        player.gameObject.SetActive(false); // Desativa o jogador
        player.GetComponent<PlayerHealthController>().FillHealth(); // Preenche a saúde do jogador
        }
        SceneManager.LoadScene(winLevel); // Carrega o nível de vitória
    }
}
    
    // Inicia a primeira rodada
    public void StartFirstRound()
    {
        roundWins.Clear(); // Limpa a lista de vitórias por rodada
        foreach(PlayerController player in activePlayers) // Para cada jogador ativo
        {
            roundWins.Add(0); // Adiciona 0 à lista de vitórias por rodada
        }
        gameWon = false; // Define que o jogo não foi ganho

        GoToNextArena(); // Vai para a próxima arena
    }

    // Adiciona uma vitória de rodada
    public void AddRoundWin()
    {
        if (CheckActivePlayers() == 1) // Se há apenas um jogador ativo
        {
            roundWins[lastPlayerNumber]++; // Incrementa o número de vitórias da rodada do último jogador

            if(roundWins[lastPlayerNumber] >= pointsToWin) // Se o número de vitórias da rodada do último jogador é maior ou igual aos pontos para ganhar
            {
                gameWon = true; // Define que o jogo foi ganho
            }
        }
    }
    
}

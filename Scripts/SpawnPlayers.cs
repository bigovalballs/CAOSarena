using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; // Importando a biblioteca Photon.Pun para lidar com a rede

public class SpawnPlayers : MonoBehaviour
{
    public GameObject Player; // Referência ao objeto do jogador que será instanciado
    public float minX, minY, maxX, maxY; // Valores para definir a área de spawn do jogador

    private void Start()
    {
        // Gera uma posição aleatória dentro dos limites definidos por minX, minY, maxX e maxY
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        // Instancia o jogador na posição aleatória gerada acima
        // PhotonNetwork.Instantiate é usado em vez de GameObject.Instantiate para que o jogador seja instanciado em todas as instâncias do jogo na rede
        PhotonNetwork.Instantiate(Player.name, randomPosition, Quaternion.identity);
    }
}

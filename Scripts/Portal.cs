using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform exitPoint; // Ponto de saída do portal
    public GameObject warpEffect; // Efeito de distorção ao usar o portal

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

    // Este método é chamado quando um objeto entra no trigger do portal
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Se o objeto que entrou no trigger tem a tag "Player"
        if(other.tag == "Player") {
            // Move o jogador para a posição do ponto de saída do portal
            other.transform.position = exitPoint.position;

            // Cria um efeito de distorção na posição do portal e na posição do ponto de saída
            Instantiate(warpEffect, transform.position, transform.rotation);
            Instantiate(warpEffect, exitPoint.position, exitPoint.rotation);

            // Toca o efeito sonoro de número 5
            AudioManager.instance.PlaySFX(5);
        }     
    }
}

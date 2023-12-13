using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    // Enumeração para definir os limites de FPS
    public enum limits{
        noLimit = 0, // Sem limite de FPS
        limit30 = 30, // Limite de 30 FPS
        limit60 = 60, // Limite de 60 FPS
        limit120 = 120, // Limite de 120 FPS
        limit240 = 240, // Limite de 240 FPS
    }

    public limits limit; // Variável para armazenar o limite de FPS selecionado

    // Awake é chamado quando o script é inicializado
    void Awake()
    {
        // Define a taxa de quadros alvo da aplicação para o limite de FPS selecionado
        Application.targetFrameRate = (int)limit;
    }
}

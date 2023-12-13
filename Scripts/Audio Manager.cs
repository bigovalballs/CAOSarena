using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Instância estática para permitir o acesso fácil de outros scripts
    public AudioSource[] soundEffects; // Array de AudioSource para armazenar os efeitos sonoros

    // Awake é chamado quando o script é inicializado
    void Awake()
    {
        // Verifica se a instância está vazia
        if (instance == null)
        {
            // Se estiver, define esta instância como a instância principal
            instance = this;
        }
        else
        {
            // Se já existir uma instância, destrói este objeto para evitar duplicatas
            Destroy(gameObject);
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

    // Método para tocar um efeito sonoro
    public void PlaySFX(int sfxToPlay)
    {
        // Para o efeito sonoro especificado
        soundEffects[sfxToPlay].Stop();
        // Toca o efeito sonoro especificado
        soundEffects[sfxToPlay].Play();
    }
}

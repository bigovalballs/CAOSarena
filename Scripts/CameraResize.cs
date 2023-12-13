using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ScreenSettings : MonoBehaviour
{
    public float targetAspect = 16f / 9f; // Proporção alvo (por exemplo, 16:9)
    private Camera cam;

    void Start()
    {
        Screen.fullScreen = false; // Define para o modo janela
        Screen.SetResolution(1920, 1080, false); // Define a largura para 1920 e a altura para 1080

        cam = GetComponent<Camera>(); // Obtém o componente da câmera
    }

    void Update()
    {
        float windowAspect = (float)Screen.width / (float)Screen.height; // Calcula a proporção da janela
        float scaleHeight = windowAspect / targetAspect; // Calcula a altura da escala
        cam.orthographicSize = scaleHeight; // Define o tamanho ortográfico da câmera para a altura da escala
    }
}
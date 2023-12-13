using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelectButton : MonoBehaviour
{
    // Referência ao SpriteRenderer do objeto
    public SpriteRenderer theSR;
     // Sprites para os estados "up" e "down" do botão
    public Sprite  buttonUP, buttonDown;
    // Variável para verificar se o botão está pressionado
    public bool isPressed;
    // Contador para controlar o tempo que o botão permanece pressionado
    private float popCounter;
    // Tempo que o botão permanece pressionado
    public float  waitToPopUP;
    
    // Controlador de animação para o personagem 
    public AnimatorOverrideController theController;
    // Start é chamado antes da primeira atualização de frame
    void Start()
    {
        
    }

    // Update é chamado uma vez por frame
    void Update()
    {
    // Se o botão estiver pressionado
      if(isPressed){
        // Diminui o contador pelo tempo decorrido desde o último frame
        popCounter -= Time.deltaTime;
        // Se o contador for menor ou igual a zero
        if (popCounter <= 0){
            // Define que o botão não está mais pressionado
            isPressed = false;
            // Muda o sprite para o sprite "up"
            theSR.sprite = buttonUP;
        }
      }  
    }
    // Quando algo entra no trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
       // Se o objeto que entrou no trigger tem a tag "Player" e o botão não está pressionado
       if(other.tag == "Player" && !isPressed){
            // Obtém o componente PlayerController do jogador
            PlayerController thePlayer = other.GetComponent<PlayerController>();
            // Se a velocidade do jogador no eixo y é menor que -0.1f
            if(thePlayer.theRB.velocity.y < -.1f){
                // Muda o controlador de animação do jogador para o controlador definido
                thePlayer.anim.runtimeAnimatorController = theController;
                // Define que o botão está pressionado
                isPressed = true;
                // Muda o sprite para o sprite "down"
                theSR.sprite = buttonDown;
                // Define o contador para o tempo que o botão permanece pressionado
                popCounter = waitToPopUP;
                // Define a velocidade do jogador para fazê-lo saltar
                thePlayer.theRB.velocity = new Vector2(thePlayer.theRB.velocity.x, 10f);
                
                 AudioManager.instance.PlaySFX(0);
            }

       }
    }
    // Quando algo permanece no trigger
    private void OnTriggerStay2D(Collider2D other)
    {
        // Se o objeto que está no trigger tem a tag "Player" e o botão não está pressionado
        if(other.tag == "Player" && !isPressed){
            // Define que o botão não está pressionado
            isPressed = false;
            // Muda o sprite para o sprite "up"
            theSR.sprite = buttonUP;

        }
    }
}


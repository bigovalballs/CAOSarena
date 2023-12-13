using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    // Referência ao SpriteRenderer do objeto
    public SpriteRenderer theSR;
    // Sprites para os estados "down" e "up" do objeto
    public Sprite downSprite, upSprite;
    // Tempo que o objeto permanece no estado "up"
    // Força do impulso que o objeto dá ao jogador
    public float stayUpTime, bouncePower;
    // Contador para controlar o tempo que o objeto permanece no estado "up"
    private float upCounter;

    // Start é chamado antes da primeira atualização de frame
    void Start()
    {
        
    }

     // Update é chamado uma vez por frame
    void Update()
    {
        // Se o contador for maior que zero
       if(upCounter > 0){
            // Diminui o contador pelo tempo decorrido desde o último frame
           upCounter -= Time.deltaTime;
            // Se o contador for menor ou igual a zero
           if(upCounter <= 0){
                // Muda o sprite para o sprite "down"
               theSR.sprite = downSprite;
           }
       }
    }
    // Quando algo entra no trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Se o objeto que entrou no trigger tem a tag "Player"
        if(other.tag == "Player")
        {
            // Define o contador para o tempo de permanência "up"
            upCounter = stayUpTime;
            // Muda o sprite para o sprite "up"
            theSR.sprite = upSprite;
            // Obtém o componente Rigidbody2D do jogador
            Rigidbody2D theRB = other.GetComponent<Rigidbody2D>();
            // Define a velocidade do jogador para fazê-lo saltar
            theRB.velocity = new Vector2(theRB.velocity.x, bouncePower);
            
            AudioManager.instance.PlaySFX(0);
        }

    }
}

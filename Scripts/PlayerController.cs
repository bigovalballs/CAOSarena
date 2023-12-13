using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB; // O Rigidbody2D do jogador
    public float moveSpeed, jumpForce; // A velocidade de movimento e a força do pulo do jogador
    private float velocity; // A velocidade atual do jogador
    private bool isGrounded; // Se o jogador está no chão
    public Transform groundCheckPoint; // O ponto para verificar se o jogador está no chão
    public LayerMask whatIsGround; // A LayerMask para determinar o que é considerado chão
    public Animator anim; // O Animator do jogador

    public bool isKeyboard1, isKeyboard2, isKeyboard3; // Se o jogador está usando o teclado 1, 2 ou 3
    public float timeBetweenAttacks = .25f; // O tempo entre os ataques
    private float attackCounter; // O contador para o próximo ataque
    [HideInInspector]
    public float powerUpCounter; // O contador para o próximo power-up
    private float speedStore, gravStore; // A velocidade e a gravidade armazenadas
    public float attackCooldown = 1.0f; // O cooldown do ataque
    private float lastAttackTime; // A última vez que o jogador atacou


    void Start()
    {
        DontDestroyOnLoad(gameObject); // Não destrua o objeto ao carregar uma nova cena

        GameManager.instance.AddPlayer(this); // Adicione este jogador ao GameManager

        speedStore = moveSpeed; // Armazene a velocidade de movimento

        gravStore = theRB.gravityScale; // Armazene a escala de gravidade
    }

    // Update é chamado uma vez por frame
    void Update()
    {     
        // Aqui, o código verifica qual teclado o jogador está usando (1, 2 ou 3) e processa a entrada do jogador de acordo.
        // Isso inclui mover o jogador para a esquerda ou direita, fazer o jogador pular e fazer o jogador atacar.
        // O código também verifica se o jogador está no chão antes de permitir que o jogador pule.
        // Além disso, o código verifica se o cooldown do ataque acabou antes de permitir que o jogador ataque novamente.
        if (isKeyboard2){

                velocity = 0f;
                if (Keyboard.current.lKey.isPressed)
                {
                    velocity = 1f;
                }
                if (Keyboard.current.jKey.isPressed)
                {
                    velocity = -1f;
                }
                if (Keyboard.current.iKey.isPressed && isGrounded)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                }
                if (!isGrounded && Keyboard.current.iKey.wasReleasedThisFrame && theRB.velocity.y > 0)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, theRB.velocity.y * 0.25f);
                }
                if (Keyboard.current.enterKey.wasPressedThisFrame && Time.time - lastAttackTime > attackCooldown)
                {
                    anim.SetTrigger("Attack");
                    lastAttackTime = Time.time;
                    attackCounter = timeBetweenAttacks;
                    AudioManager.instance.PlaySFX(2);
                }
            }
        if (isKeyboard1){

                velocity = 0f;
                if (Keyboard.current.dKey.isPressed)
                {
                    velocity = 1f;
                }
                if (Keyboard.current.aKey.isPressed)
                {
                    velocity = -1f;
                }
                if (Keyboard.current.wKey.isPressed && isGrounded)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                }
                if (!isGrounded && Keyboard.current.wKey.wasReleasedThisFrame && theRB.velocity.y > 0)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, theRB.velocity.y * 0.25f);
                }
                if (Keyboard.current.leftShiftKey.wasPressedThisFrame && Time.time - lastAttackTime > attackCooldown)
                {
                    anim.SetTrigger("Attack");
                    lastAttackTime = Time.time;
                    attackCounter = timeBetweenAttacks;
                    AudioManager.instance.PlaySFX(2);
                }
            }

        if (isKeyboard3){

                velocity = 0f;
                if (Keyboard.current[Key.RightArrow].isPressed)
                {
                    velocity = 1f;
                }
                if (Keyboard.current[Key.LeftArrow].isPressed)
                {
                    velocity = -1f;
                }
                if (Keyboard.current[Key.UpArrow].isPressed && isGrounded)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                }
                if (!isGrounded && Keyboard.current[Key.UpArrow].wasReleasedThisFrame && theRB.velocity.y > 0)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, theRB.velocity.y * 0.25f);
                }
                if (Keyboard.current[Key.Numpad0].wasPressedThisFrame && Time.time - lastAttackTime > attackCooldown)
                {
                    anim.SetTrigger("Attack");
                    lastAttackTime = Time.time;
                    attackCounter = timeBetweenAttacks;
                    AudioManager.instance.PlaySFX(2);
                }
            }

        // Verifica se o jogador está no chão
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, whatIsGround);
        // Define a velocidade do rigidbody do jogador com base na entrada horizontal do usuário e a velocidade de movimento configurada 
        theRB.velocity = new Vector2(velocity * moveSpeed, theRB.velocity.y);
        // Atualiza as variáveis do Animator com base no estado atual do jogador
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("ySpeed", theRB.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        // Inverte o jogador dependendo da direção em que ele está se movendo
        if(theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } else if(theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        // Se o jogador está atacando, impede que ele se mova
        if(attackCounter > 0)
        {
            attackCounter = attackCounter - Time.deltaTime;

            theRB.velocity = new Vector2(0f, theRB.velocity.y);
        }
        // Se o jogador tem um power-up, diminui o contador do power-up e, se o contador chegar a zero, retorna a velocidade e a gravidade do jogador ao normal
        if(powerUpCounter > 0)
        {
            powerUpCounter -= Time.deltaTime;

            if(powerUpCounter <= 0)
            {
                moveSpeed = speedStore;
                theRB.gravityScale = gravStore;
            }
        }


    }
}

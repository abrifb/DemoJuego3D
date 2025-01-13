using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;
    private Vector3 playerInput;
    public CharacterController player;
    public float playerSpeed;
    private Vector3 movePlayer;
    public float gravity = 9.8f; //crea gravedad
    //configuracion de vistas de la camara
    public float fallVelocity;
    public float jumpForce;// nueva variable para saltar
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight; 


    void Start (){
        player = GetComponent <CharacterController>();

    }
    void Update (){

        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3 (horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude (playerInput, 1);

        //se llama funcion camara
        camDirection();
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        movePlayer = movePlayer * playerSpeed;

        player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity(); // llama funcion gravedad

        PlayerSkills(); // llama la funcion acciones de player

        player.Move(movePlayer * Time.deltaTime);
        
    }
    //se crea funcion camara
    void camDirection(){
        camForward  = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized; 

    }
    //funcion para habilidades jugador
    void PlayerSkills(){
        if (player.isGrounded && Input.GetButtonDown("Jump")){

            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;

        }
    }

    void SetGravity(){ // define funcion gravedad
        

        if (player.isGrounded){

            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else{
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }   
    }

    
}

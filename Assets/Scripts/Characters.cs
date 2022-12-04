using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Characters : MonoBehaviour {

    [Header("Moviendose")]
    private Rigidbody2D PlayerMouseRB;
    private Rigidbody2D PlayerKeyRB;
    private float velocidadDeMovimiento = 80;
    private float suavizado = 0.1f;

    private Vector3 velocidadPlayerKey = Vector3.zero;
    private Vector3 velocidadPlayerMouse = Vector3.zero;
    private Vector3 velocidadCadena = Vector3.zero;

    private float movXPKey = 0f;
    private float movYPKey = 0f;

    private float movXPMouse = 0f;
    private float movYPMouse = 0f;

    private Rigidbody2D InicioCadena;
    private Rigidbody2D FinCadena;

    private Vector3 worldPos;

    private double distancia_max;

    private double distancia_actual;

    private Animator playerKBAnimator;
    private Animator playerMAnimator;

    
    private void Start() {
        PlayerKeyRB = GameObject.Find("Player_KeyBoard").GetComponent<Rigidbody2D>();
        PlayerMouseRB = GameObject.Find("Player_Mouse").GetComponent<Rigidbody2D>();
        playerKBAnimator = GameObject.Find("Player_KeyBoard").GetComponent<Animator>();
        playerMAnimator = GameObject.Find("Player_Mouse").GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        double dis1 = Math.Pow(PlayerKeyRB.position.x - PlayerMouseRB.position.x,2);
        double dis2 = Math.Pow(PlayerKeyRB.position.y - PlayerMouseRB.position.y,2);
        distancia_max = Math.Sqrt(dis1+dis2);
        playerMAnimator.SetFloat("LastVertical",-1);
        playerMAnimator.SetFloat("LastHor",0);

        playerKBAnimator.SetFloat("LastVertical",-1);
        playerKBAnimator.SetFloat("LastHor",0);
    }

    private void Update() {
        movXPMouse = Input.GetAxisRaw("Mouse X") * velocidadDeMovimiento;
        movYPMouse = Input.GetAxisRaw("Mouse Y") * velocidadDeMovimiento;

        movXPKey = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;
        movYPKey = Input.GetAxisRaw("Vertical") * velocidadDeMovimiento;

        playerKBAnimator.SetFloat("Horizontal",Input.GetAxisRaw("Horizontal"));
        playerKBAnimator.SetFloat("Vertical",Input.GetAxisRaw("Vertical"));

        if (Math.Abs(Input.GetAxisRaw("Horizontal")) > Math.Abs(Input.GetAxisRaw("Vertical")) && Math.Abs(Input.GetAxisRaw("Horizontal")) > 0.3f){
            playerKBAnimator.SetFloat("Vertical",0f);
            if (Input.GetAxisRaw("Horizontal")>0) {
                playerKBAnimator.SetFloat("Horizontal",1f);
                playerKBAnimator.SetFloat("LastHor",1f);
                playerKBAnimator.SetFloat("LastVertical",0f);
            } else {
                playerKBAnimator.SetFloat("Horizontal",-1f);
                playerKBAnimator.SetFloat("LastHor",-1f);
                playerKBAnimator.SetFloat("LastVertical",0f);
            }
        } else if (Math.Abs(Input.GetAxisRaw("Horizontal")) <= Math.Abs(Input.GetAxisRaw("Vertical"))&& Math.Abs(Input.GetAxisRaw("Vertical")) > 0.3f){
            playerKBAnimator.SetFloat("Horizontal",0f);
            if (Input.GetAxisRaw("Vertical") > 0) {
                playerKBAnimator.SetFloat("Vertical",1f);
                playerKBAnimator.SetFloat("LastHor",0f);
                playerKBAnimator.SetFloat("LastVertical",1f);
            } else {
                playerKBAnimator.SetFloat("Vertical",-1f);
                playerKBAnimator.SetFloat("LastHor",0f);
                playerKBAnimator.SetFloat("LastVertical",-1f);
            }
        } else {
            playerKBAnimator.SetFloat("Vertical",0f);
            playerKBAnimator.SetFloat("Horizontal",0f);
        }

        

        if (Math.Abs(Input.GetAxisRaw("Mouse X")) > Math.Abs(Input.GetAxisRaw("Mouse Y")) && Math.Abs(Input.GetAxisRaw("Mouse X")) > 0.3f){
            playerMAnimator.SetFloat("Vertical",0f);
            if (Input.GetAxisRaw("Mouse X")>0) {
                playerMAnimator.SetFloat("Horizontal",1f);
                playerMAnimator.SetFloat("LastHor",1f);
                playerMAnimator.SetFloat("LastVertical",0f);
            } else {
                playerMAnimator.SetFloat("Horizontal",-1f);
                playerMAnimator.SetFloat("LastHor",-1f);
                playerMAnimator.SetFloat("LastVertical",0f);
            }
        } else if (Math.Abs(Input.GetAxisRaw("Mouse X")) <= Math.Abs(Input.GetAxisRaw("Mouse Y"))&& Math.Abs(Input.GetAxisRaw("Mouse Y")) > 0.3f){
            playerMAnimator.SetFloat("Horizontal",0f);
            if (Input.GetAxisRaw("Mouse Y") > 0) {
                playerMAnimator.SetFloat("Vertical",1f);
                playerMAnimator.SetFloat("LastHor",0f);
                playerMAnimator.SetFloat("LastVertical",1f);
            } else {
                playerMAnimator.SetFloat("Vertical",-1f);
                playerMAnimator.SetFloat("LastHor",0f);
                playerMAnimator.SetFloat("LastVertical",-1f);
            }
        } else {
            playerMAnimator.SetFloat("Vertical",0f);
            playerMAnimator.SetFloat("Horizontal",0f);
        }




    }

    private void FixedUpdate() {
        double dis1 = Math.Pow(PlayerKeyRB.position.x - PlayerMouseRB.position.x,2);
        double dis2 = Math.Pow(PlayerKeyRB.position.y - PlayerMouseRB.position.y,2);
        float MOVY,MOVX;
        if (Math.Abs(Input.GetAxisRaw("Mouse Y")) > 0.3f) {
            MOVY = movYPMouse *Time.fixedDeltaTime;
        } else {
            MOVY = 0;
        }

        if (Math.Abs(Input.GetAxisRaw("Mouse X")) > 0.3f) {
            MOVX = movXPMouse *Time.fixedDeltaTime;
        } else {
            MOVX = 0;
        }


        MoverPKey(movXPKey * Time.fixedDeltaTime,movYPKey * Time.fixedDeltaTime);

        MoverPMouse(MOVX, MOVY);

        playerMAnimator.SetFloat("Speed",PlayerMouseRB.velocity.sqrMagnitude);

        distancia_actual = Math.Sqrt(dis1+dis2);
        
    }

    private void MoverPKey(float movX, float movY) {
        Vector3 vel = new Vector3(movX,movY,0).normalized;
        PlayerKeyRB.velocity = Vector3.SmoothDamp(PlayerKeyRB.velocity,vel, ref velocidadPlayerKey, suavizado);
        playerKBAnimator.SetFloat("Speed",vel.sqrMagnitude);
    }
    
    private void MoverPMouse(float movX, float movY) {
        Vector3 vel = new Vector3(movX,movY,0);
        PlayerMouseRB.velocity = Vector3.SmoothDamp(PlayerMouseRB.velocity,vel, ref velocidadPlayerMouse, suavizado);
    }

}
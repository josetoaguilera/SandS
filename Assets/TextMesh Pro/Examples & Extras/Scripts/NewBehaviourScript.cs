using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector3 velocidadPlayerKey = Vector3.zero;
    private Rigidbody2D PlayerKeyRB;
    private float velocidadDeMovimiento = 1f;
    //private float suavizado = 0.1f;
    private Animator playerKBAnimator;
    Vector2 vel;
    // Start is called before the first frame update
    void Start()
    {
        PlayerKeyRB = GetComponent<Rigidbody2D>();
        playerKBAnimator = GetComponent<Animator>();
    }

    void Update() {
        float movX = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");
        vel = new Vector2(movX,movY).normalized;


        playerKBAnimator.SetFloat("Horizontal",vel.x);
        playerKBAnimator.SetFloat("Vertical",vel.y);

        PlayerKeyRB.MovePosition(PlayerKeyRB.position + vel * velocidadDeMovimiento * Time.fixedDeltaTime);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        playerKBAnimator.SetFloat("Speed",vel.sqrMagnitude);

    }
}

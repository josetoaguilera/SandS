using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Skeleton : MonoBehaviour
{
    [SerializeField] public Transform jugador;
    [SerializeField] private float distancia;
    public Vector3 puntoInicial;
    private Animator animator;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        puntoInicial = transform.position;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("Distancia",distancia);
    }

    public void Movement(Vector3 objetivo) {

        if (Math.Abs(transform.position.x-objetivo.x) < Math.Abs(transform.position.y-objetivo.y)) {
            if (transform.position.y < objetivo.y) {
                animator.SetFloat("Vertical",1);
                animator.SetFloat("LastVertical",1);
            } else {
                animator.SetFloat("Vertical",-1);
                animator.SetFloat("LastVertical",-1);
            }
            animator.SetFloat("Horizontal",0);
            animator.SetFloat("LastHorizontal",0);
        } else {
            if (transform.position.x < objetivo.x) {
                animator.SetFloat("Horizontal",1);
                animator.SetFloat("LastHorizontal",1);
            } else {
                animator.SetFloat("Horizontal",-1);
                animator.SetFloat("LastHorizontal",-1);
            }
            animator.SetFloat("Vertical",0);
            animator.SetFloat("LastVertical",0);
        }
    }
}

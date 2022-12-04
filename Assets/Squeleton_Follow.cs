using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squeleton_Follow : StateMachineBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float timepoBase;
    [SerializeField] private float distancia;
    private float tiempoSeguir;
    private float timeAttack;
    private Transform jugador;
    private Skeleton Skeleton;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tiempoSeguir = timepoBase;
        timeAttack = 1.3f;
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Skeleton = animator.gameObject.GetComponent<Skeleton>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        distancia = Vector2.Distance(Skeleton.transform.position, jugador.position);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, jugador.position, velocidadMovimiento * Time.deltaTime);
        Skeleton.Movement(jugador.position);
        tiempoSeguir -= Time.deltaTime;
        timeAttack -= Time.deltaTime;
        if (distancia < 0.3f && timeAttack <=0) {
            animator.SetTrigger("Attack");
        }


        if (tiempoSeguir <=0) {
            animator.SetTrigger("Stop");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

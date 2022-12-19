using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private float tiempoEntreDano;
    private float tiempoSiguienteDano;
    private Animator animator;
    private BoxCollider2D collider2D; 
    // Start is called before the first frame update
    void Start()
    {
        animator = (this.transform.parent).transform.parent.transform.parent.gameObject.GetComponent<Animator>();
        collider2D = GetComponent<BoxCollider2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            animator.Play("Attack");
            collider2D.enabled = true;
            Invoke("DisableAttack",0.5f);
            Debug.Log("devore");
        }
    }
    private void DisableAttack(){
        collider2D.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Enemy")){
            tiempoSiguienteDano -= Time.deltaTime;
            if(tiempoSiguienteDano <= 0){
                Debug.Log("ataco");
                other.GetComponent<SkeletonSword>().TakeHit(1);
                tiempoSiguienteDano = tiempoEntreDano;
            }
        }
    }

    void onCollisionEnter(Collision other) {
        Debug.Log("aaaaaaa");
    }
    //nuevo yt
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Enemy")){
            Debug.Log("colisione");
        }
        
    }


    void OnTriggerEnter(Collider other) {
        Debug.Log("aaa");
        if (other.gameObject.GetComponent<SistemaVidas>() != null) {
            other.gameObject.GetComponent<SistemaVidas>().QuitarVida(10);
        }
    }
}

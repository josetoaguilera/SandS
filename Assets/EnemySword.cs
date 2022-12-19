using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour
{
    //[SerializeField] private float tiempoEntreDano;
    [SerializeField] private float damage;
    private float tiempoSiguienteDano;
    private Animator animator;
    private BoxCollider2D collider2D; 
    // Start is called before the first frame update
    void Start()
    {
        //animator = (this.transform.parent).transform.parent.transform.parent.gameObject.GetComponent<Animator>();
        collider2D = GetComponent<BoxCollider2D>();
    }


    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            Debug.Log("dano enemigo");
            collision.GetComponent<SistemaVidas>().QuitarVida(damage);
        }
        
    }
}

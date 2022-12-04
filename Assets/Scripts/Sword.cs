using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = (this.transform.parent).transform.parent.transform.parent.gameObject.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            animator.Play("Attack");
        }
    }

    void onCollisionEnter(Collision other) {
        Debug.Log("aaaaaaa");
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("aaa");
        if (other.gameObject.GetComponent<SistemaVidas>() != null) {
            other.gameObject.GetComponent<SistemaVidas>().QuitarVida(10);
        }
    }
}

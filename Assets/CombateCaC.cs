using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateCaC : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float damage;

    private void Update(){
        if(Input.GetButtonDown("Fire1")){
            Golpe();
        }
    }
    private void Golpe(){
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos){
            if(colisionador.CompareTag("Enemy")){
                colisionador.transform.GetComponent<SkeletonSword>().TakeHit(damage);
            }
        }
    }
    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}

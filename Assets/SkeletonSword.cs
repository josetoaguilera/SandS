using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSword : MonoBehaviour
{
    public float daño = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("aaa");
        if (other.gameObject.GetComponent<SistemaVidas>() != null) {
            other.gameObject.GetComponent<SistemaVidas>().QuitarVida(daño);
        }
    }
}

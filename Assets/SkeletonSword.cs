using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSword : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitpoints = 2;
    public HealthbarBehaviour Healthbar;

    // Start is called before the first frame update
    void Start()
    {
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
    }

    // Update is called once per frame
    void Update()
    {
        //Healthbar.SetHealth(Hitpoints, MaxHitpoints);
    }
    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);

        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("aaa");
        if (other.gameObject.GetComponent<SistemaVidas>() != null) {
            other.gameObject.GetComponent<SistemaVidas>().QuitarVida(Hitpoints);
        }
    }
}

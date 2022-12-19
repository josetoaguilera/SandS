using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaVidas : MonoBehaviour
{
    [SerializeField] private HealthbarBehaviour Healthbar;
    public float maxVida = 3;
    public float vidaActual;

    public bool inmortal = false;
    public float tiempoInmortal = 1.0f;

    private void Start() {
        vidaActual = maxVida;
        Healthbar.SetHealth(vidaActual, maxVida);
    }

    private void Update() {
        if (vidaActual > maxVida) {
            vidaActual = maxVida;
        }

        if (vidaActual <= 0) {
            Muerte();
        }
    }

    public void QuitarVida(float daño) {
        if (inmortal) {
            return;
        }
        vidaActual -= daño;
        Healthbar.SetHealth(vidaActual, maxVida);
        StartCoroutine(TiempoInmortal());
    } 

    public void CurarVida(float vida) {
        vidaActual += vida;
    }

    public void Muerte() {
        //Destroy(this.gameObject);
        GameManager.instance.deathMenuAnim.SetTrigger("Show");

    }

    IEnumerator TiempoInmortal() {
        inmortal = true;
        yield return new WaitForSeconds(tiempoInmortal);
        inmortal = false;
    }
}

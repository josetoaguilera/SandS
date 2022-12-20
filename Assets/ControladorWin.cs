using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ControladorWin : MonoBehaviour
{
    private int scape;
    private bool MWActive;

    [SerializeField] private GameObject menuWin;
    private EnemyController enemyController;
    // Start is called before the first frame update
    void Start()
    {
        scape = 0;
        menuWin.SetActive(false);
        MWActive = false;
        enemyController = GameObject.FindGameObjectWithTag("Econtroller").GetComponent<EnemyController>();
//ganajugador
        enemyController.GanaJugador += ActivarMenu;
    }

    private void ActivarMenu(object sender, EventArgs e){
        menuWin.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (MWActive) {
            Debug.Log("caca");
            if (scape == 0) {
                Time.timeScale = 0f;
                scape = 1;
                menuWin.SetActive(true);

            } else {
                Time.timeScale = 1f;
                scape = 0;
                menuWin.SetActive(false);
            }
        }
    }
    public void setMWActive(){
        MWActive = true;
    }

    public void Reanudar() {
        Time.timeScale = 1f;
        scape = 0;
        menuWin.SetActive(false);
    }

    public void Reiniciar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuInicial(string nombre){
        SceneManager.LoadScene(nombre);
    }

    public void Salir() {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}

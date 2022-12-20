using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Pausa : MonoBehaviour
{
    private int scape;

    [SerializeField] private GameObject menuPausa;
    // Start is called before the first frame update
    void Start()
    {
        scape = 0;
        menuPausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (scape == 0) {
                Time.timeScale = 0f;
                scape = 1;
                menuPausa.SetActive(true);

            } else {
                Time.timeScale = 1f;
                scape = 0;
                menuPausa.SetActive(false);
            }
        }
    }

    public void Reanudar() {
        Time.timeScale = 1f;
        scape = 0;
        menuPausa.SetActive(false);
    }

    public void Salir() {
        scape = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menú Principal");
    }
    public void Exit(){
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}

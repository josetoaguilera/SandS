using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyController : MonoBehaviour
{
    //private float minX, maxX, minY, maxY;
    [SerializeField] private Transform[] puntosSimples;
    [SerializeField] private Transform puntoBoss;
    [SerializeField] private GameObject[] enemies;
    //[SerializeField] private float EnemiesTime;

    //tiempos de las hordas
    [SerializeField] private float FisrtBurst;
    [SerializeField] private float SecondBurst;
    [SerializeField] private float ThirdBurst;

    //tiempo Boss
    [SerializeField] private float BossBurst;

    private int[] Done = {0,0,0,0};
    private float timeNextEnemy;

    // Start is called before the first frame update
    void Start()
    {
        /* maxX = puntos.Max(punto => punto.position.x);    
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        maxY = puntos.Min(punto => punto.position.y); */
        timeNextEnemy = 0;
    }

    private void CreateEnemy(int EnemyNumber, int HowMany){
        for (int i = 0; i < HowMany; i++)
        {
            if (EnemyNumber == 0){
                Vector2 pos = new Vector2(puntosSimples[Random.Range(0, puntosSimples.Length)].position.x, puntosSimples[Random.Range(0, puntosSimples.Length)].position.y);
                Instantiate(enemies[EnemyNumber], pos, Quaternion.identity);
            }
            if (EnemyNumber == 1){
                Vector2 pos = new Vector2(puntoBoss.position.x, puntoBoss.position.y);
                Instantiate(enemies[EnemyNumber], pos, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeNextEnemy += Time.deltaTime;
        if (timeNextEnemy >= BossBurst && 1 != Done[3])
        {
            CreateEnemy(1, 1);
            Done[3] = 1;
        }
        else if (timeNextEnemy >= ThirdBurst && 1 != Done[2])
        {
            CreateEnemy(0, 3);
            Done[2] =1;
        }
        else if (timeNextEnemy >= SecondBurst && 1 != Done[1])
        {
            CreateEnemy(0,7);
            Done[1] =1;
        }
        else if (timeNextEnemy >= FisrtBurst && 1 != Done[0])
        {
            //crear enemigo
            CreateEnemy(0,5);
            Done[0] =1;
        }
    }

    /* private void CreateEnemyF(){
        int EnemyNumber = Random.Range(0, enemies.Length);
        Vector2 randomPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Instantiate(enemies[EnemyNumber], randomPos, Quaternion.identity);
    } */
}
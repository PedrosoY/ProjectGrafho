using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;

    float distanciaMax = 10f;
    float minTimeCreate = 1f;
    float maxTimeCreate = 3f;
    float contTime;
    float timeCreate; 

    void Start()
    {
        contTime = 0;
        SetRandomTimeCreate(); 
    }

    void Update()
    {
        contTime += Time.deltaTime;
        if (contTime >= timeCreate)
        {
            contTime = 0;
            CriarInemy();
            SetRandomTimeCreate();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, distanciaMax);
    }

    void CriarInemy()
    {
        int indiceAleatorio = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyPrefab = enemyPrefabs[indiceAleatorio];

        Vector2 positionDirection = Random.insideUnitCircle.normalized;
        Vector2 positionEnemy = positionDirection * distanciaMax;

        Instantiate(enemyPrefab, (Vector2)transform.position + positionEnemy, Quaternion.identity);
    }

    void SetRandomTimeCreate()
    {
        timeCreate = Random.Range(minTimeCreate, maxTimeCreate);
    }
}

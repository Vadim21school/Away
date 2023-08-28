using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;

    private float elapsedTime = 0;

    private void Start()
    {
        Initialize(_prefab);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        
        if(elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject prefab))
            {
                elapsedTime = 0;
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                SetEnemy(prefab, _spawnPoints[spawnPointNumber].position);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}

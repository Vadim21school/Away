using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;

    private void Start()
    {
        Initialize(_prefab);
        StartCoroutine(RunPrefab());
    }

    private IEnumerator RunPrefab()
    {
        while (Time.timeScale > 0)
        {
            if (TryGetObject(out GameObject prefab))
            {
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                SetEnemy(prefab, _spawnPoints[spawnPointNumber].position);
                yield return new WaitForSeconds(_secondsBetweenSpawn);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}

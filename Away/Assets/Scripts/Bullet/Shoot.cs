using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : ObjectPool
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _point;

    private void Start()
    {
        Initialize(_bullet);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (TryGetObject(out GameObject prefab))
            {
                SetBullet(prefab, _point.position);
            }
        }
    }

    private void SetBullet(GameObject bullet, Vector3 spawnPoint)
    {
        bullet.SetActive(true);
        bullet.transform.position = spawnPoint;
    }
}

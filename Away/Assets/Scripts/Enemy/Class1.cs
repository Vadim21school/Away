using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerOfBullet : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private Transform _targetObject;
    [SerializeField] float _timeWaitShooting;

    private void Start()
    {
        StartCoroutine(StartPrefab());
    }

    private IEnumerator StartPrefab()
    {
        bool isWork = true;

        while (isWork == true)
        {
            Vector3 direction = (_targetObject.position - transform.position).normalized;
            Rigidbody prefab = Instantiate(_prefab, transform.position, Quaternion.identity);

            prefab.velocity = direction * _speed;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBooster : MonoBehaviour
{
    [SerializeField] private int _amount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.IncreaseHealth(_amount);
        }

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}

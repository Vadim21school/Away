using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject[] _images;

    private void Awake()
    {
        SwitchOff();
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        SwitchOff();
        _images[health].SetActive(true);
    }

    private void SwitchOff()
    {
        for (int i = 0; i < _images.Length; i++)
        {
            _images[i].SetActive(false);
        }
    }
}

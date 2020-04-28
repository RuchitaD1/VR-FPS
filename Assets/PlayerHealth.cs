using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider HealthBar = null;
    public float Health = 100;

    private float _currentHealth = 0.0f;

    void Start ()
    {
        _currentHealth = Health;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        HealthBar.value = _currentHealth;
    }

    public bool PlayerDead()
    {
        return _currentHealth == 0;
    }
}

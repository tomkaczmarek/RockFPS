using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
            Die();
    }

    public float GetHealth()
    {
        return health;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}

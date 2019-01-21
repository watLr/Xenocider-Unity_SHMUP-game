using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {

    public float startingHealth = 100f;
    public float currentHealth;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    void Update()
    {
        if (currentHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }

    public void remove(float amount)
    {
        currentHealth -= amount;
    }
}

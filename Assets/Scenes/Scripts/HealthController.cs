using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public bool IsDead = true;

    public Renderer bladrenderer;
    

    

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        
        currentHealth -= damage;
        bladrenderer.enabled = true;
        



        if (currentHealth <= 0f)
        {
            IsDead = false;
            Destroy(gameObject);
        }

    }

    void Update()
    {

        bladrenderer.enabled = false;


    }




}

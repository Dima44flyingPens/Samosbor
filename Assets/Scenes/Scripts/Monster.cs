using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    //Здоровье
    public int Health = 100;
    public int MaxHealth = 100;

    //Переменные движения
    public float speed = 10;
    float translation;

    LicvidatorScript licvidatorScript;

    //Таймер
    public float attackDelay = 2f;
    private float attackTimer = 0f;

    void Start()
    {
        licvidatorScript = GameObject.FindObjectOfType<LicvidatorScript>();
    }

    // Update is called once per frame
    void Update()
    {

        // Уменьшаем таймер атаки
        attackTimer -= Time.deltaTime;

        // Если таймер достиг нуля, то атакуем
        if (attackTimer <= 0f)
        {
            //Атака
            if (licvidatorScript != null)
            {

                if (Vector2.Distance(transform.position, licvidatorScript.transform.position) < 1.7f)
                {
                    Health -= 40;

                }
            }
            // Сбрасываем таймер атаки
            attackTimer = attackDelay;
        }
  

        

        //Смерть
        if (Health <= 0)
        {
            Destroy(gameObject);

        }


        //Движение
        translation = -speed * Time.deltaTime;
        gameObject.transform.Translate(translation, 0, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    //��������
    public int Health = 100;
    public int MaxHealth = 100;

    //���������� ��������
    public float speed = 10;
    float translation;

    LicvidatorScript licvidatorScript;

    //������
    public float attackDelay = 2f;
    private float attackTimer = 0f;

    void Start()
    {
        licvidatorScript = GameObject.FindObjectOfType<LicvidatorScript>();
    }

    // Update is called once per frame
    void Update()
    {

        // ��������� ������ �����
        attackTimer -= Time.deltaTime;

        // ���� ������ ������ ����, �� �������
        if (attackTimer <= 0f)
        {
            //�����
            if (licvidatorScript != null)
            {

                if (Vector2.Distance(transform.position, licvidatorScript.transform.position) < 1.7f)
                {
                    Health -= 40;

                }
            }
            // ���������� ������ �����
            attackTimer = attackDelay;
        }
  

        

        //������
        if (Health <= 0)
        {
            Destroy(gameObject);

        }


        //��������
        translation = -speed * Time.deltaTime;
        gameObject.transform.Translate(translation, 0, 0);
    }
}

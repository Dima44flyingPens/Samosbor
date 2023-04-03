using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2D : MonoBehaviour
{
    public float damage = 10f;
    public float attackRange = 1f;
    public LayerMask allyLayer;
    public bool facingRight = false;
    private bool isAttacking = false;

    public float minY = 0.3f;
    public float maxY = -0.2f;


    //�����
 
    
    
    

    void Start()
    {   
        
        
        // ������ ��������� ������� �����
        transform.position = new Vector3(transform.position.x, Random.Range(minY, maxY)+1, transform.position.z);
    }

    private void Update()
    {
        

        if (!isAttacking)
        {
            float moveDirection = facingRight ? 1 : -1;
            transform.Translate(moveDirection * Vector2.right * Time.deltaTime);
        }
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRange, allyLayer);
        foreach (Collider2D hitCollider in hitColliders)
        {
            // ������� ���� ��������
            HealthController healthController = hitCollider.GetComponent<HealthController>();
            if (healthController != null)
            {
                
                healthController.TakeDamage(damage * Time.deltaTime);
            }
        }
        if (hitColliders.Length > 0)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
         
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

   
}


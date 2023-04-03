using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyController2D : MonoBehaviour
{
    public float damage = 10f;
    public float attackRange = 1f;
    public LayerMask enemyLayer;
    public bool facingRight = false;
    private bool isAttacking = false;



    //Плавный переход по y
    public float speed = 0.1f;
    public float smoothTime = 0.1f;

    private Vector2 targetPosition;
    private Vector2 velocity = Vector2.zero;

    //Граници спавна
   
    public float minY = -1;
    public float maxY = -3;

   
    //эффект огня
    public Renderer fayerenderer;

 
  

   // private void OnTriggerEnter2D(Collider2D other)
    //{
       // if (other.tag == "Likvidator" || other.transform.position.y > transform.position.y)
        //{
           // transform.position -= new Vector3(0, 0, 2);
           
        //}
    //}

   // private void OnTriggerExit2D(Collider2D other)
   // {
    //if (other.tag == "Likvidator" || other.transform.position.y < transform.position.y)
   // {
         // transform.position += new Vector3(0, 0, 2);
         
      // }
    //}



    private void Start()
    {   // Задаем начальную позицию 
        transform.position = new Vector3(transform.position.x, Random.Range(minY, maxY)+0.2f, transform.position.z);
        targetPosition = transform.position;
    }

    private Vector2 GetNearestEnemyPosition()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Monster");
        Vector2 nearestPosition = Vector2.zero;
        float nearestDistance = float.MaxValue;

        foreach (GameObject enemy in enemies)
        {
            float distance = Mathf.Abs(enemy.transform.position.x - transform.position.x);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestPosition = enemy.transform.position;
            }
        }

        return nearestPosition;
    }



    private void Update()
    {





       // if (!facingRight)
       // {
            //transform.Rotate(0f, 180f, 0f);
       // }
       



        if (!isAttacking)
        {
            float moveDirection = facingRight ? 1 : -1;
            transform.Translate(moveDirection * Vector2.right * Time.deltaTime);
            



        }

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y+1f);

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);
        foreach (Collider2D hitCollider in hitColliders)
        {
            // Наносим урон врагу
            HealthController healthController = hitCollider.GetComponent<HealthController>();
            if (healthController != null)
            {
                print("Мы ёбнули монстра");
                

                healthController.TakeDamage(damage * Time.deltaTime);

                if (true)
                {
                    
                    targetPosition.y = GetNearestEnemyPosition().y;
                    


                    // Перемещаемся к цели с плавным переходом
                    transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, speed);
                   

                }
               
                targetPosition.x = transform.position.x;
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y+1f);

            }

          


        }


        if (hitColliders.Length > 0)
        {
            
            isAttacking = true;
            fayerenderer.enabled = true;
        }
        else
        {
           
            fayerenderer.enabled = false;
            isAttacking = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Vector3 MinStart = new Vector3(-20f, minY, 0f);
        Vector3 MinEnd = new Vector3(20f, minY, 0f);

        Vector3 MaxStart = new Vector3(-20f, maxY, 0f);
        Vector3 MaxEnd = new Vector3(20f, maxY, 0f);


        Debug.DrawLine(MinStart, MinEnd, Color.red);
        Debug.DrawLine(MaxStart, MaxEnd, Color.red);
    }

}

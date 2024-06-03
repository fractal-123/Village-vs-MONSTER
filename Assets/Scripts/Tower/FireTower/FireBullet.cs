using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Rigidbody2D rb;
    

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int bulletDamage = 2;
   

    private Transform target;



    
    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    
    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Vector2 direction = (target.position - transform.position).normalized;
            float angelDirection = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.AngleAxis(angelDirection, Vector3.forward);

            rb.velocity = direction * bulletSpeed * 10;

        }
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);

        Destroy(gameObject);

    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Bullet : MonoBehaviour
{
    

    [Header("Reference")]
    [SerializeField] private Rigidbody2D rb;
    

    [Header("Attributes")]
    [SerializeField] public GameObject hitEffect;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int bulletDamage = 1;

    private Transform target;


    public void SetTarget(Transform _target)
    {
        target = _target;
    }


    
    private void FixedUpdate()
    {
        if (!target)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 direction = (target.position - transform.position).normalized;
        float angelDirection = Mathf.Atan2(direction.y, direction.x)* Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angelDirection, Vector3.forward);


        rb.velocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
        Instantiate(hitEffect,rb.transform.position ,Quaternion.identity);
        
        Destroy(gameObject);
        
    }
}

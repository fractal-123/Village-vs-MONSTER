using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FireTower : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    
    [SerializeField] private Animator rbGUN;


    [Header("Attribute")]
    [SerializeField] private float targetingRange = 3f;
    [SerializeField] private float bps = 1f; //Bullets Per Second


    private Transform target;
    private float timeUntilFire;
    private Vector2 pos;

    private void Start()
    {
           
     

    }
    private void Update()
    {
       
        if (target == null)
        {
            FindTarget();
            rbGUN.GetComponent<Animator>().SetBool("ISAttack", false);
            return;
        }

        if (!CheckTargetIsInRange())
        {
            target = null;
            rbGUN.GetComponent<Animator>().SetBool("ISAttack", false);

        }

        else
        {
            timeUntilFire += Time.deltaTime;
            if (timeUntilFire >= 1f / bps)
            {
                RotateTowardsTower();
                Shoot();
                rbGUN.GetComponent<Animator>().SetBool("ISAttack", true);
                timeUntilFire = 0f;
            }
        }



    }

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        FireBullet bulletScript = bulletObj.GetComponent<FireBullet>();
        bulletScript.SetTarget(target);
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)
            transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    public void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }


    private void RotateTowardsTower()
    {
        float angel = Mathf.Atan2(target.position.y - transform.position.y, target.position.x -  
            transform.position.x)  * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angel));
        transform.rotation = targetRotation;
    }

   
}

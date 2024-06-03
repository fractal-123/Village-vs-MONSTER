using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using static UnityEditor.PlayerSettings;



public class Tower : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject strelkaUP;
 
    [Header("Attribute")]
    [SerializeField] private float targetingRange = 3f;
    [SerializeField] private float bps = 1f; //Bullets Per Second


    private Transform target;   
    private float timeUntilFire;
    private Vector2 pos;

     private void Start()
    {
       
        strelkaUP.SetActive(false);
        
    }
    private void Update()
    {
        Upgrade_STRELKA();
        if (target == null)
        {
            FindTarget();
            return;
        }

        if(!CheckTargetIsInRange())
        {
            target = null;
        }

        else
        {
            timeUntilFire += Time.deltaTime;
            if(timeUntilFire >= 1f/ bps) 
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
        
        

    }

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target); 
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)
            transform.position,0f,enemyMask);

        if(hits.Length > 0 )
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

    private void Upgrade_STRELKA()
    {
        DesTower tower = TowerBuild.main.GetSelectedTower();
        

        if (Manager.main.currency >= tower.upgradeCost)
        {
            strelkaUP.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
            strelkaUP.transform.position = new Vector2(strelkaUP.transform.position.x+70f, strelkaUP.transform.position.y-70f);

            strelkaUP.SetActive(true);
        }
        else strelkaUP.SetActive(false);
    }
       
    
    
}

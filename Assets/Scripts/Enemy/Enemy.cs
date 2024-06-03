using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private int damage;

    private Transform target;
    private int pathIndex = 0;

    private void Start()
    {
        target = Manager.main.path[pathIndex];

    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, target.position) <= 0.1f)
        { 
        pathIndex++;

            if(pathIndex == Manager.main.path.Length)
            {
                Manager.main.Healh(damage);
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);

                return;
            }
            else
            {
                target = Manager.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {

        Vector2 direction = (target.position - transform.position);
        float distanceToTarget = direction.magnitude;

        if (distanceToTarget < 0.1f)
        {
            transform.position = target.position;   
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = direction.normalized * moveSpeed;
        }
        
    }


}

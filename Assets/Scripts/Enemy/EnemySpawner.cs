using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;


public class EnemySpawner : MonoBehaviour
{

    public static EnemySpawner main;
    [Header("Reference")]
    [SerializeField] private GameObject[] enemyPrefabs;
   

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;
    [SerializeField] private int waveCount;

    [Header("Attributes")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    public int currentWave = 0;
    private float timeSinceLastSpawn;
    public int enemiesAlive;
    public int enemiesLeftToSpawn;
    private bool isSpawnig = false;
    public GameObject circleWave;
    public Vector3 scaleCircle;
    private int rnd;
  

    public List<int> resultLEVEL;

    private void Awake()
    {
        main = this;
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
       
        
        scaleCircle = circleWave.GetComponent<RectTransform>().localScale;
        circleWave.SetActive(true);
        
    }

    public void Update()
    {
        

        if (!isSpawnig) return;
        timeSinceLastSpawn += Time.deltaTime;
        
            if (enemiesLeftToSpawn == 0 && currentWave < waveCount)
            {
                circleWave.transform.localScale = scaleCircle;
                circleWave.SetActive(true);
                circleWave.GetComponent<Animator>().SetBool("IsClick", false);
                
            }
            else if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
            {
                
                SpawnEnemy();
                circleWave.SetActive(false);
                enemiesLeftToSpawn--;
                enemiesAlive++;
                timeSinceLastSpawn = 0f;
                


            }
            
            
        
        
    }
    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }
    private void StartWave()
    {
        currentWave++;
        isSpawnig = true;
        enemiesLeftToSpawn = EnemiesPerWave();

    }

    private void SpawnEnemy()
    {
        rnd = Random.Range(0, 2);
        if(currentWave >= 2)
        { 
            if (rnd == 0)
            {
                GameObject prefabToSpawn = enemyPrefabs[0];
                Instantiate(prefabToSpawn, Manager.main.startPoin.position, Quaternion.identity);
            }
            else
            {
                GameObject prefabToSpawn = enemyPrefabs[1];
                prefabToSpawn.transform.position = Manager.main.startPoin.position + new Vector3(0f, 0f, -0.1f);
                prefabToSpawn.transform.localScale = new Vector3(2.5f, 2.5f, 0f);
                Instantiate(prefabToSpawn, prefabToSpawn.transform.position, Quaternion.identity);;
                
            }
        }
        else
        {
            GameObject prefabToSpawn = enemyPrefabs[0];
            Instantiate(prefabToSpawn, Manager.main.startPoin.position, Quaternion.identity);
        }
    }

    private int EnemiesPerWave() 
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }

    public void CircleWave()
    {
           
            circleWave.GetComponent<Animator>().SetBool("IsClick", true);
            enemiesPerSecond = enemiesPerSecond - 0.1f;
            StartWave();
            Manager.main.WaveCount(currentWave);
    }


}

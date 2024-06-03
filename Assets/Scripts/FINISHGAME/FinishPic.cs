using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPic : MonoBehaviour
{

    [SerializeField] private int waveCount;
    [SerializeField] private int allEnemyIsDEAD = 0;
    [SerializeField] private Animator animator;
    private int _result_;
    [SerializeField] public int _lvl_;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }
    // Update is called once per frame
    private void Update()
    {
        
        if ((EnemySpawner.main.currentWave == waveCount) && (EnemySpawner.main.enemiesLeftToSpawn == allEnemyIsDEAD) && (EnemySpawner.main.enemiesAlive == 0))
        {
            Invoke("Picter", 1f);
            Debug.Log(EnemySpawner.main.currentWave);
            if (Manager.main.healh == 5) { _result_ = 3; }
            else if (Manager.main.healh >= 2) { _result_ = 1; }
            else if (Manager.main.healh == 0) {_result_ = 0;}
            else {_result_ = 2;}
        }

    }

    private void Picter()
    {
        animator.enabled = true;
    }

    public void NextButton()
    {
        SendResult(_result_,_lvl_);
        SceneManager.LoadScene("Menu");
    }
    public void SendResult(int result, int lvl)
    {
        LevelResult.intanse.Result(result, lvl);
    }


}

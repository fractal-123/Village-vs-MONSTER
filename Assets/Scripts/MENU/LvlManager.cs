using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlManager : MonoBehaviour
{
    public static LvlManager main;

    [SerializeField] public Lvl[] lvlNumber;
    private int selectedLvl = 0;
    [SerializeField] public GameObject lvl_1;
    [SerializeField] public GameObject lvl_2;


    private void Awake()
    {
        main = this;
    }
    public void Update()
    {
        
        //Debug.Log(LevelResult.res[1]);
        //Debug.Log(LevelResult.res[2]);
        if (LevelResult.res[1] == 0)
        {
            lvl_1.SetActive(true);
            lvl_2.SetActive(false);
        }
        else if (LevelResult.res[1] > 1 )
        {
            Debug.Log("[ewq" + LevelResult.res[1]);
            lvl_2.SetActive(true);
        }
    }

    public void SetSelectedLvl(int _selectedLvl)
    {
        
        selectedLvl = _selectedLvl + 1;

        switch (selectedLvl)
            {
                case 1:
                SceneManager.LoadScene("LVL_1");
                break;

                case 2:
                SceneManager.LoadScene("LVL_2");
                break;

        }

    }

}

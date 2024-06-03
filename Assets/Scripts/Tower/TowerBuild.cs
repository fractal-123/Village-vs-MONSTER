using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuild : MonoBehaviour
{
    public static TowerBuild main;

    [SerializeField] public  DesTower[] towers;
    private int selectedTower = 0;
    private void Awake()
    {
        main = this;
    }
    public DesTower GetSelectedTower()
    {
        return towers[selectedTower];
    }
    public void SetSelectedTower(int _selectedTower)
    {
        selectedTower = _selectedTower;
        
       
    }
}

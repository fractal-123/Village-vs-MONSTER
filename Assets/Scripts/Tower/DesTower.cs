using System;
using UnityEngine;


[Serializable]
public class DesTower
{
    public string name;
    public int cost;
    public GameObject prefab;
    public int upgradeCost;
    public GameObject upgradePrefabLVL_1;


    public DesTower(string _name, int _cost, GameObject _prefab, int _upgradeCost, GameObject _upgradePrefabLVL_1) 
    {
        name = _name;
        cost = _cost;
        prefab = _prefab;
        upgradeCost = _upgradeCost;
        upgradePrefabLVL_1 = _upgradePrefabLVL_1;
    }   
}

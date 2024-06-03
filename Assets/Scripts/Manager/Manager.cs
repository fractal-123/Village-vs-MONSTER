using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    public static Manager main;

    public Transform startPoin;
    public Transform[] path;
    [SerializeField] public int currency;
    public int healh;
    public int wave;
    public List<int> res = new List<int>();

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        
        healh = 5;
        wave = 0;

    }


    public void LvlRes(int count)
    {
        res.Add(count);
        Debug.Log(res[0]);

    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }
    public void Healh(int helka)
    {
        healh -= helka;
        if(healh == 0)  
        {
            Time.timeScale = 0;
        }

    }
    public void WaveCount(int wavecount)
    {
        wave = wavecount;
    }

    public bool SpendCurrency(int amount)
    {
        if(amount <= currency) 
        {
            currency -= amount;
            return true;
        }
        else   
        {
            
            return false;
         
        }
    }





}

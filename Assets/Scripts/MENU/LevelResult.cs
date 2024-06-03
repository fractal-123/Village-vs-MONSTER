using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelResult : MonoBehaviour
{
    public static LevelResult intanse;
    public static int[] res = new int[5];
    public bool negotovo = false;
    

    private void Awake()
    { 
        if (intanse == null)
        {
            intanse = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Start()
    {
        res[0] = 0;
    }
   
    
    public void Result(int _res1, int _lvl)
    {
       res[_lvl] = _res1;
       negotovo = true;
       Debug.Log(res[0]);
    }
}

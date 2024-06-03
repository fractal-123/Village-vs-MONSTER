using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StarResult : MonoBehaviour
{
    [SerializeField] GameObject star_1;
    [SerializeField] GameObject star_2;
    [SerializeField] GameObject star_3;
    [SerializeField] GameObject star_0;
    [SerializeField] int level;



    void Update()
    {
        if (LevelResult.intanse.negotovo == true )
        {
               
            if (LevelResult.res[level] == 3)
            {
                star_0.SetActive(false);
                star_3.SetActive(true);

            }
            else if (LevelResult.res[level] == 2)
            {
                star_0.SetActive(false);
                star_2.SetActive(true);
            }
            else if (LevelResult.res[level] == 1)
            {
                star_0.SetActive(false);
                star_1.SetActive(true);
            }
            
        }
       
    }
}

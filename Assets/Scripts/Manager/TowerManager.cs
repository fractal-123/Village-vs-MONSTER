using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TowerManager : MonoBehaviour
{
   
    public GameObject buildButton;
    public GameObject upgradeButton;
    private GameObject selectedPoint;
    public GameObject selectedTower;
    private Tower tower;
    
    private GameObject towerObj;
  

    private void Start()
    {
        
        buildButton.SetActive(false);
        upgradeButton.SetActive(false);
  

    }
     public void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Создаем луч из точки клика
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            if (!EventSystem.current.IsPointerOverGameObject())
            {
                

                if (hit != false)
                {
                    if(selectedPoint != null && selectedPoint.tag == "BuildPoint") 
                    {
                        selectedPoint.GetComponent<Animator>().SetBool("PointIsSelected", false);
                    }




                    /*Debug.Log(selectedPoint.tag);*/
                    selectedPoint = hit.transform.gameObject;
                    if (selectedPoint.tag == "BuildPoint")
                    {
                        Debug.Log(selectedPoint.tag);

                        selectedPoint.GetComponent<Animator>().SetBool("PointIsSelected", true);

                        buildButton.SetActive(false);
                        buildButton.SetActive(true);
                        upgradeButton.SetActive(false);

                        buildButton.GetComponent<Animator>().SetBool("BuildButtomIsSelected", true);
                        upgradeButton.GetComponent<Animator>().SetBool("UpgradeSelected", false);

                        buildButton.transform.position = Camera.main.WorldToScreenPoint(selectedPoint.transform.position);

                    }

                    selectedTower = hit.transform.gameObject;

                    if (selectedTower.tag == "BowTower")
                    {
                        Debug.Log(selectedTower.tag);

                        upgradeButton.SetActive(false);
                        upgradeButton.SetActive(true);
                        buildButton.SetActive(false);


                        upgradeButton.GetComponent<Animator>().SetBool("UpgradeSelected", true);
                        buildButton.GetComponent<Animator>().SetBool("BuildButtomIsSelected", false);

                        upgradeButton.transform.position = Camera.main.WorldToScreenPoint(selectedTower.transform.position);
                        
                    }
                
                }
                else if (buildButton.activeInHierarchy == true || upgradeButton.activeInHierarchy == true)
                {

                    if (selectedPoint != null && selectedPoint.tag == "BuildPoint")
                    {

                        buildButton.GetComponent<Animator>().SetBool("BuildButtomIsSelected", false);
                        buildButton.SetActive(false);

                    }
                    if (selectedTower != null && selectedTower.tag == "BowTower")
                    {
                        upgradeButton.GetComponent<Animator>().SetBool("UpgradeSelected", false);
                        upgradeButton.SetActive(false);
                    }

                }


            }

        }


    }
        public void BuildTower()
        {


            DesTower towerToBuild = TowerBuild.main.GetSelectedTower();
            


            if (towerToBuild.cost > Manager.main.currency)
            {
                Debug.Log("НЕТ ДЕНЕГ");
                Debug.Log(towerToBuild.cost);
                return;
            }

            Manager.main.SpendCurrency(towerToBuild.cost);
            towerObj = Instantiate(towerToBuild.prefab, selectedPoint.transform.position, Quaternion.identity);
            tower = towerObj.GetComponent<Tower>();

            buildButton.SetActive(false);
            Destroy(selectedPoint);

        }
        public void UpdateTower()
        {
            DesTower towerToBuild = TowerBuild.main.GetSelectedTower();
            if (towerToBuild.upgradeCost > Manager.main.currency)
            {
                Debug.Log("НЕТ ДЕНЕГ");
                Debug.Log(towerToBuild.upgradeCost);
                return;
            }

            Manager.main.SpendCurrency(towerToBuild.upgradeCost);


            Destroy(selectedTower);
            towerObj = Instantiate(towerToBuild.upgradePrefabLVL_1, selectedTower.transform.position, Quaternion.identity);
            tower = towerObj.GetComponent<Tower>();

            upgradeButton.SetActive(false);
            



        }


        







}


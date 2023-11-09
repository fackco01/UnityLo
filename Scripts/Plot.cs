using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    
    private GameObject towerObj;
    public Turret turret;
    private Color startColor;

    private void Start()
    {
        startColor = sr.color;
    }

    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        Debug.Log("Build Tower Here: " + name);

        if (towerObj != null)
        {
            //if (Turret.main.level <= 2)
            //{
            //    turret.OpenUpgradeUI();
            //}
            Debug.Log("UPDATE");
            turret.OpenUpgradeUI(); //test
            return;
        }

        Tower towerToBuild = BuildManager.main.GetSelectedTower();

        //Check cost tower
        if (towerToBuild.cost > LevelManager.main.currency ) {

            Debug.Log("Can't afford this tower");
            return;
        }

        LevelManager.main.SpendCurrency(towerToBuild.cost);

        towerObj = Instantiate(towerToBuild.prefab, transform.position + new Vector3(0f, 0f, -1f), Quaternion.identity);
        turret = towerObj.GetComponent<Turret>();
    }
}

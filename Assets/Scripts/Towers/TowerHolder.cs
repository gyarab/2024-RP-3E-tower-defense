using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHolder : MonoBehaviour
{
    private GameObject towerInstance;
    private PlayerStatsManager playerStats;
    private SpriteRenderer sprite;

    void Awake()
    {
        playerStats = GameObject.Find("PlayerStats").GetComponent<PlayerStatsManager>();
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.black;
    }
    void BuildTower(GameObject tower){
        if(playerStats.SubtractGold(100) && towerInstance == null){
            towerInstance = Instantiate(tower,transform.position,Quaternion.identity,transform);
            sprite.enabled = false;
        }else if(!playerStats.SubtractGold(100)){
            Debug.Log("nedeostatek peněz");
        }
    }
    void SellTower(){
        if(towerInstance!=null){
            
            Destroy(towerInstance);
            towerInstance = null;
            playerStats.AddGold(100);
            sprite.enabled = true;
        }
    }
    void UpgradeTower(){

    }
    private void OnMouseEnter()
    {
        sprite.color = Color.cyan;
    }

    private void OnMouseExit()
    {
        sprite.color = Color.black;
    }
    private void OnMouseDown(){
        if(towerInstance == null){
            BuildTower(TowerTypes.bombPrefab);
        }
        else SellTower();
    }
}
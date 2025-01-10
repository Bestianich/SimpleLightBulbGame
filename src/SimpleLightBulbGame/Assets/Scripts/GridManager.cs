using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _size = 5;
    
    [SerializeField] private GameObject[,] grid;
    
    public GameObject LightBulbPrefab;
    

    public void Awake(){
        grid = new GameObject[_size , _size];
        //Grid initializer
        for(int x = 0; x < _size; x++){
            for(int z = 0; z < _size; z++){
                GameObject obj = Instantiate(LightBulbPrefab , new Vector3(x, 0, z) , Quaternion.identity , this.transform);
                obj.name = $"{LightBulbPrefab.name} {x} x {z}"; 
                grid[z , x] = obj;
            }
        }
    }

    public void ToggleTShape(int x , int z){
        
        grid[z , x].GetComponent<LightBulbManager>().Toggle();
        //Checks to avoid Index out of bound Exception
        if(z < _size-1)
            grid[z+1 , x].GetComponent<LightBulbManager>().Toggle();
        if(z != 0)
            grid[z-1 , x].GetComponent<LightBulbManager>().Toggle();      
        if(x < _size-1)   
            grid[z , x+1].GetComponent<LightBulbManager>().Toggle();
        if(x != 0)
            grid[z , x-1].GetComponent<LightBulbManager>().Toggle();
        CheckWin();
    }

    public void CheckWin(){
        for(int x = 0; x < _size; x++){
            for(int z = 0; z < _size; z++){
                if(!grid[z , x].GetComponent<LightBulbManager>().getIsOn()) //Check if the light bulb is on if not it stops checking
                    return;
            } 
        }
        Debug.Log("You won");
   }

    //Turn off all the light bulbs
   public void Reset(){
        for(int x = 0; x < _size; x++){
            for(int z = 0; z < _size; z++){
                grid[z , x].GetComponent<LightBulbManager>().TurnOff();
            }
        }
   }
   public void Update(){
        if(Input.GetKeyDown("r"))
            Reset();
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] static private int _size = 5;
    
    [SerializeField] private GameObject[,] grid = new GameObject[_size , _size];
    public GameObject LightBulbPrefab;
    // Start is called before the first frame update

    public void Awake(){
        for(int i = 0; i < _size; i++){
            for(int j = 0; j < _size; j++){
                GameObject obj = Instantiate(LightBulbPrefab , new Vector3(j, 0, i) , Quaternion.identity , this.transform);
                obj.name = $"{LightBulbPrefab.name} {i} x {j}"; 
                grid[i , j] = obj;
            }
        }
    }
}

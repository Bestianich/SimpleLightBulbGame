using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulbManager : MonoBehaviour
{
    public Material BulbOnMaterial;
    public Material BulbOffMaterial;
    [SerializeField] MeshRenderer BulbMeshRenderer;
    [SerializeField] private bool isOn = false;
    public GridManager gridManager;
    public void TurnOn(){
        BulbMeshRenderer.material = BulbOnMaterial; 
        isOn = true;
    }

    public void TurnOff(){
        BulbMeshRenderer.material = BulbOffMaterial;
        isOn = false;
    }

    public void Toggle(){
        if(isOn){
            TurnOff();
        } else {
            TurnOn();
        }
    }

    public bool getIsOn(){
        return isOn;
    }
    public void OnMouseDown(){
        gridManager.ToggleTShape((int)transform.position.x , (int)transform.position.z);
        //Toggle();
    }

    public void Awake(){
        BulbMeshRenderer = this.GetComponent<MeshRenderer>();
        gridManager = this.transform.parent.GetComponent<GridManager>();
    }
}

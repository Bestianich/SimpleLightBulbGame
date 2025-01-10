using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulbManager : MonoBehaviour
{
    public Material BulbOnMaterial;
    public Material BulbOffMaterial;
    [SerializeField] MeshRenderer BulbMeshRenderer;
    [SerializeField] private bool isOn = false;
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

    public void OnMouseDown(){
        Toggle();
    }

    public void Awake(){
        BulbMeshRenderer = this.GetComponent<MeshRenderer>();
    }
}

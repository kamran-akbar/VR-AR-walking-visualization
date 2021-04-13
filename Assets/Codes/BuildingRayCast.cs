using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingRayCast : MonoBehaviour
{
    public Transform camera;

    Transform prevBuilding = null;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, camera.forward, out hit, Mathf.Infinity))
        {
            Transform currentBuilding = hit.collider.gameObject.transform;
            if (hit.collider.gameObject.transform.tag == "Interactable")
            {
                if (prevBuilding == null)
                {
                    Debug.Log(currentBuilding.gameObject.name);
                    currentBuilding.GetChild(0).GetChild(0).gameObject.active = true;
                    prevBuilding = currentBuilding;
                }
                else if (prevBuilding != currentBuilding)
                {
                    prevBuilding.GetChild(0).GetChild(0).gameObject.active = false;
                    currentBuilding.GetChild(0).GetChild(0).gameObject.active = true;
                    prevBuilding = currentBuilding;
                }
                Debug.Log(hit.collider.gameObject.transform.name);
            }
        }
                
    }
}

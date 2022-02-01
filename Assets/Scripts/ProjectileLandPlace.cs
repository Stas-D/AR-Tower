using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLandPlace : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public GameObject landingPlace;
    public bool isFiring;
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetKey(KeyCode.Mouse0) && !isFiring)
            {
                MakeLandMark();
                isFiring = true;
            }
        }
    }
    private void MakeLandMark()
    {
        GameObject obj = ObjectPooler.SharedInstance.GetPooledObject("target");
        if (obj != null)
        {
            obj.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            obj.transform.rotation = Quaternion.identity;
            obj.SetActive(true);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCreator : MonoBehaviour
{
    public void CreateBuild(GameObject gameObject)
    {
        Instantiate(gameObject,transform.position,Quaternion.identity);
    }
}

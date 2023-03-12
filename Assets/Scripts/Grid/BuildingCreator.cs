using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCreator : MonoBehaviour
{
    public void CreateBuild(GameObject gameObject)
    {
        print(Resurses.Money);
        print(gameObject.transform.GetComponent<Building>().Cost);

        if (0 > Resurses.Money - gameObject.transform.GetComponent<Building>().Cost)
            return;

        Instantiate(gameObject,transform.position,Quaternion.identity);
    }
}

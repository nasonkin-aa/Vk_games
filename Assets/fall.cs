using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position = new Vector3(0, 0, 0);

    }
   
}

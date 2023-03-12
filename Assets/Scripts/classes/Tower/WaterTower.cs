using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTower : Tower
{
    public override void ColliderOn()
    {
        transform.GetComponent<CapsuleCollider2D>().enabled = true;
    }
}

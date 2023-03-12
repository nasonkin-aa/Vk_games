using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject TilePrefab;
    public GameObject Building;
    public bool IsTileBlocked;

    public Tile(GameObject gameObject,bool isTileBlocked)
    {
        TilePrefab = gameObject;
        TilePrefab.GetComponent<Tile>().IsTileBlocked = isTileBlocked;
        IsTileBlocked = isTileBlocked;
    }
    public Tile(GameObject gameObject)
    {
        TilePrefab = gameObject;
    }

    public void Update()
    {

    }
    public void UnBlock()
    {
        IsTileBlocked=false;
    }
}

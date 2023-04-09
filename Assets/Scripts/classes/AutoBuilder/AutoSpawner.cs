using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpawner : Grid
{
    public GameObject[] Build;
    public Tile[,] matrix;
    public Grid grid;
    public float TimeToSpawn = 2;
    public float SpawnRate = 2;

    public new void Start()
    {
        StartCoroutine(Fade());
    }
    IEnumerator Fade()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < grid.LengsVertical; i++)
        {
            {
                var tow = Instantiate(Build[0], grid.Matrix[7, i].transform.position,Quaternion.identity);
                tow.GetComponent<Building>().IsDropedBuilding = true;
                tow.GetComponent<BoxCollider2D>().isTrigger = false;
                tow.GetComponent<CapsuleCollider2D>().enabled = true;
                tow.GetComponent<SpriteRenderer>().flipX = true;
                grid.Matrix[7, i].GetComponent<Tile>().Building = tow;
            }
        }
    }
    private void FixedUpdate()
    {
        TimeToSpawn -= Time.deltaTime;
        if (TimeToSpawn <= 0)
        {
            RandomSpawn();
            TimeToSpawn = SpawnRate;
        }
    }
    public void RandomSpawn()
    {
        var randomM = grid.Matrix[Random.Range(8, grid.LengsHorizontal), Random.Range(0, grid.LengsVertical)];
        {
            if(randomM.GetComponent<Tile>().Building == null)
            {
                var tow = Instantiate(Build[Random.Range(0,Build.Length)],randomM.transform.position, Quaternion.identity);
                if(tow.GetComponent<WaterTower>())
                {
                    tow.GetComponent<CapsuleCollider2D>().enabled = true;
                    Base(tow, randomM);
                }
                if (tow.GetComponent<Barak>())
                {
                    
                    tow.GetComponent<Barak>().solder.GetComponent<Solder>().GetComponent<SpriteRenderer>().flipX = false;
                    Base(tow, randomM);
                }
                else
                {
                    Base(tow, randomM);
                }
            }
            else
            {
                TimeToSpawn = 0;
            }
        }
    }
    public void Base(GameObject tow,Tile randomM)
    {
        tow.GetComponent<BoxCollider2D>().isTrigger = false;
        tow.GetComponent<Building>().IsDropedBuilding = true;
        tow.GetComponent<SpriteRenderer>().flipX = true;
        randomM.GetComponent<Tile>().Building = tow;
    }
}

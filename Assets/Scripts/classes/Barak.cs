// Класс здания-генератора солда
using UnityEngine;
public class Barak : Building
{
    protected float spawnRate = 2;
    public float spawnTimer = 2;

    protected int countSoldersPerTime;
    public GameObject solder;

    public void SpawnSolders()
    {
        Instantiate(solder,transform.position,Quaternion.identity,transform);
    }

    public new void Update() 
    {   
        base.Update();
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            SpawnSolders();
            spawnTimer = spawnRate;
        }

        
    }
}
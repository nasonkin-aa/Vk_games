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
        var spawnPosMult = player.isReversed ? 1.1f : 0.9f;
        Instantiate(solder,transform.position * spawnPosMult,Quaternion.identity);
    }

    public void FixedUpdate()
    {
        if (!IsDropedBuilding)
            return;
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            SpawnSolders();
            spawnTimer = spawnRate;
        }
        
    }
}
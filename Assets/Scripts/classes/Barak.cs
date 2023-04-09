// Класс здания-генератора солда
using UnityEngine;
public class Barak : Building
{
    protected float spawnRate = 6;
    public float spawnTimer = 6;

    protected int countSoldersPerTime;
    public GameObject solder;

    public void SpawnSolders()
    {
        solder.GetComponent<Entity>().IsPlayer = gameObject.GetComponent<Entity>().IsPlayer;
        Instantiate(solder,transform.position,Quaternion.identity);
    }

    public void FixedUpdate()
    {
        if (!IsDropedBuilding)
            return;
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            SpawnSolders();
            spawnTimer = Random.Range(spawnRate - 2, spawnRate + 2);
        }
        
    }
}
// Класс здания-генератора солда
using UnityEngine;
public class Barak : Building
{
    // Скорость спавна солдат
    protected int spawnRate;
    
    // Кол-во солдат за один спавн
    protected int countSoldersPerTime;
    public GameObject solder;
    public void SpawnSolders()
    {
        //Instantiate(solder,transform.);

    }
}
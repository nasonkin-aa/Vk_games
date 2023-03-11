// Класс здания-генератора солдат
public class Barak : Building
{
    // Скорость спавна солдат
    public int SpawnRate { get; set; }
    
    // Кол-во солдат за один спавн
    public int CountSoldersPerTime { get; set; }
}
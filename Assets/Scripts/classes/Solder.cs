// Базовый класс солдата
using UnityEngine;
public class Solder: MonoBehaviour, IDamageEntity
{
    public int Damage { get; set; }
    
    public int AttackDistance { get; set; }
    
    public int AttackRate { get; set; }
    
    // Скорость солдата
    public int Speed { get; set; }
    
    // Тип солдата
    public TypeOfSolder Type { get; set; }
}
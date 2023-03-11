// Базовый класс атакующего здания
public class Tower: Building, IDamageEntity
{
    public int Damage { get; set; }
    
    public int AttackDistance { get; set; }
    
    public int AttackRate { get; set; }
}
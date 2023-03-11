// Базовый класс атакующего здания
public class DamageBuilding: DamageEntity, IBuilding
{
    public int Size { get; set; }

    public DamageBuilding()
    {
        Hp = 10;
    }
}
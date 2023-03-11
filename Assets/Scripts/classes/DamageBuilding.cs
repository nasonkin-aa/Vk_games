// Базовый класс атакующего здания
public class DamageBuilding: Building
{
    protected DamageEntity damageEntity;

    public DamageBuilding()
    {
        hp = 10;
        damageEntity = new DamageEntity();
    }
}
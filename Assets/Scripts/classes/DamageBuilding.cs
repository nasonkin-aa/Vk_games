// Базовый класс атакующего здания
public class DamageBuilding: Building
{
    protected DamageEntity damageEntity;

    public DamageBuilding()
    {
        damageEntity = new DamageEntity();
    }
}
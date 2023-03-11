// Базовый класс боевой сущности
public interface IDamageEntity: IEntity
{
    // Кол-во урона
    public int Damage {get; set;}

    // Дистанция для атаки
    public int AttackDistance {get; set;}

    // Скорость атаки
    public int AttackRate {get; set;}

    public void Attack(IEntity entity);
}

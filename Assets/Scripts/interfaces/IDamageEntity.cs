// Базовый класс боевой сущности
public interface IDamageEntity
{
    // Кол-во урона
    public int Damage {get; set;}

    // Дистанция для атаки
    public int AttackDistance {get; set;}

    // Скорость атаки
    public int AttackRate {get; set;}
}

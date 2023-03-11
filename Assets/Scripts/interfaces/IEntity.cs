// Базовый класс сущности (здания, солдата)
public interface IEntity
{
    // Здоровье
    public int Hp {get; set;}

    // Имя сущности
    public string Name {get; set;}

    public void Kill();
}

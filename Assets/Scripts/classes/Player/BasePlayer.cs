public class BasePlayer
{
    public PlayerPosition position = PlayerPosition.Left;

    public int balance = 1000;

    public static BasePlayer currPlayer = new BasePlayer();

    public static BasePlayer enemyPlayer = new BasePlayer(PlayerPosition.Right);
    
    public bool isReversed => position == PlayerPosition.Right;

    public BasePlayer() {}

    public BasePlayer(PlayerPosition position)
    {
        this.position = position;
    }

    public BasePlayer(PlayerPosition position, int balance)
    {
        this.position = position;
        this.balance = balance;
    }
}
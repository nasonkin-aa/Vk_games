using UnityEngine;

public class SwitchUser: MonoBehaviour
{
    public void Switch()
    {
        // var curr = new BasePlayer(BasePlayer.currPlayer.position, BasePlayer.currPlayer.balance);

        // BasePlayer.currPlayer.position = BasePlayer.enemyPlayer.position;
        // BasePlayer.currPlayer.balance = BasePlayer.enemyPlayer.balance;

        // BasePlayer.enemyPlayer.position = curr.position;
        // BasePlayer.enemyPlayer.balance = curr.balance;
        
        (BasePlayer.currPlayer, BasePlayer.enemyPlayer) = (BasePlayer.enemyPlayer, BasePlayer.currPlayer);

        Resurses.Money = BasePlayer.currPlayer.balance;
        
        print(BasePlayer.currPlayer.position);
    }
}
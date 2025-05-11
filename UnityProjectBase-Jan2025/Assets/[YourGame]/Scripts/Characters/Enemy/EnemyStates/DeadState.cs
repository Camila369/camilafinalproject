using UnityEngine;
using UnityEngine.UIElements;

public class DeadState : State
{
    public override void Enter()
    {
        base.Enter();
        //stop movement
        enemy.Movement.Stop();
        enemy.Movement.CanMove = false;
        enemy.Movement.CanTurn = false;
        //play death animation
        // destroy object

    }

}

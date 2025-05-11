using UnityEngine;
using UnityEngine.UIElements;

public class IdleState : State
{
    public override void Enter()
    {
        base.Enter();
        // STOP MOVEMENT
        enemy.Movement.Stop();
    }

    public override void Update()
    {
        base.Update();

        if (_timer > 2f)
        {
            _stateMachine.ChangeState(patrolState);
        }

        if (enemy.IsTargetVisible())
        {
            _stateMachine.ChangeState(chaseState);
        }
    }
}

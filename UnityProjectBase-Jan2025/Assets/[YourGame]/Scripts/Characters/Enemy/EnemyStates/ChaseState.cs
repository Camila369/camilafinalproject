using CharacterMovement;
using UnityEngine;
using UnityEngine.UIElements;

public class ChaseState : State
{

    public override void Update()
    {
        base.Update();

        Weapon weapon = enemy.Weapons[0];

        PlayerController target = player;

        if (target != null)
        {
            //ditance to player, chase it too far
            float distance = Vector3.Distance(enemy.transform.position, target.transform.position);

            if (distance > weapon.EffectiveRange)
            {
                enemy.Movement.MoveTo(target.transform.position);
            }
            else
            {
                //otherwise enter attack state
                _stateMachine.ChangeState(attackState);
            }
        }
        else
        {
            _stateMachine.ChangeState(patrolState);
        }

    }
}

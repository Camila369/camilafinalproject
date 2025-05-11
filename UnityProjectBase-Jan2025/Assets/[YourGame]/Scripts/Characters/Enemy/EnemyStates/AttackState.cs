using System.Collections;
using System.Xml;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackState : State
{

    public override void Enter()
    {
        base.Enter();
        // do attack
        Attack();
    }

    public void Attack()
    {
        Weapon weapon = enemy.Weapons[0];
        weapon.TryAttack(player.transform.position, enemy.gameObject, 1, false);
        _timer = 0f;
    }
    

    public override void Update()
    {
        base.Update();

        Weapon weapon = enemy.Weapons[0];
        float range = weapon.Range;
        float cooldown = 1f / weapon.FireRate;

        if (enemy.IsTargetVisible())
        {
            if (enemy.IsTargetInRange(range) && _timer > cooldown) // player in range and enemy can attack
            {
                Attack();
            }
            else if (enemy.IsTargetInRange(range) && _timer < cooldown) // player in range and weapon is in cooldown
            {
                // STOP MOVEMENT and look at player
                enemy.Movement.Stop();
                enemy.Movement.SetLookPosition(player.transform.position);
            }
            else if (!enemy.IsTargetInRange(range)) // player is not in range
            {
                _stateMachine.ChangeState(chaseState);
            }
        }
        else if (!enemy.IsTargetVisible())
        {
            _stateMachine.ChangeState(patrolState); // ALERT! create alert state? where the enemy checks where the player went (but stops after a certain range?)
                                                    // create check for sound?
        }

    }
}

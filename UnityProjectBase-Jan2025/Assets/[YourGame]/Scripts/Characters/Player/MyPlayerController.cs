using CharacterMovement;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyPlayerController : PlayerController
{
    [Header("Aim")]
    [SerializeField] private LayerMask _groundMask;
    private Vector3 _aimPosition;

    Health Health;
    Weapon[] Weapons;

    public bool spotted = false;
    public bool canSneakAttack = false;

    public override void OnFire(bool canSneakAttack)
    {
        base.OnFire(canSneakAttack);

        if (!Health.IsAlive) return;

        if (!spotted)  // if you are NOT spotted by the enemy
        {
            if (Input.GetMouseButtonDown(1)) // try attack
            {
                // sneak attack
                canSneakAttack = true;

                // assume shooting weapon 1, fists
                Weapons[0].TryAttack(_aimPosition, gameObject, 0, canSneakAttack);

                // quick time event
            }
        }
        else if (spotted) // if you are spotted by the enemy
        {
            if (Input.GetMouseButtonDown(1)) // try attack
            {
                //normal attack
                canSneakAttack = false;

                // assume shooting weapon 0, fists
                Weapons[0].TryAttack(_aimPosition, gameObject, 0, canSneakAttack);

                // quick time event
            }
        }

    }


    //protected override void Update()
    //{
    //    base.Update();

    //    // stop moving/turning if dead
    //    if (!Health.IsAlive)
    //    {
    //        //Movement.CanMove = false;
    //        //Movement.CanTurn = false;
    //        return;
    //    }
    //}
}

using CharacterMovement;
using UnityEngine;

public class SpriteFlip : CharacterMovement3D
{

    protected override void Update()
    {
        base.Update();

        // rotates character towards movement direction
        if (ControlRotation && HasTurnInput && (IsGrounded || AirTurning))
        {
            Quaternion rotation = Rigidbody.rotation;
            if (!Fix3DSpriteRotation)
            {
                Quaternion targetRotation = Quaternion.LookRotation(LookDirection);
                rotation = Quaternion.Slerp(transform.rotation, targetRotation, TurnSpeed * TurnSpeedMultiplier * Time.deltaTime);
            }   // rotate sprite character properly
            else if (Fix3DSpriteRotation && Mathf.Abs(MoveInput.x) > 0.2f)
            {
                //float spriteAngle = LookDirection.x > 0 ? 0f : 180f;
                //float spriteAngle = Camera.main.transform.position.x > 0 ? 0f : 180f;

                rotation = Camera.main.transform.rotation;
                //rotation = Quaternion.Euler(0f, spriteAngle, 0f);
            }
            Rigidbody.MoveRotation(rotation);
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {

            // Flip the sprite if the direction is changing
            if (Input.GetAxisRaw("Horizontal") < 0 && !spriteRenderer.flipX)
            {

                spriteRenderer.flipX = true;
                Debug.Log("Sprite flipped true");
            }
            else if (Input.GetAxisRaw("Horizontal") > 0 && spriteRenderer.flipX)
            {
                spriteRenderer.flipX = false;
                Debug.Log("Sprite flipped false");
            }
        }
    }
}

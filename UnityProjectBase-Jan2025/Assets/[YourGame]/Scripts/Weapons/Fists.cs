using UnityEngine;

public class Fists : MonoBehaviour
{
    [field: Header("Melee")]
    [field: SerializeField] public float AttackHalfAngle { get; private set; } = 45f;
    [field: SerializeField] public LayerMask HitMask { get; private set; }

    public override void Attack(Vector3 aimPosition, GameObject instigator, int team)
    {
        base.Attack(aimPosition, instigator, team);

        Vector3 origin = instigator.transform.position;
        Vector3 aimDirection = (aimPosition - origin).normalized;

        // WE'RE USING AN OVERLAPSPHERE - NOT A SPHERECAST - THEY ARE VERY DIFFERENT
        // OVERLAPSPHERE IS STATIONARY, SPHERECAST MOVES
        Collider[] hits = Physics.OverlapSphere(origin, Range, HitMask);

        // iterate through each collider hit
        foreach (Collider hit in hits)
        {
            // don't punch self in face
            if (hit.gameObject == instigator) continue;     // continue skips to next iteration

            // filter hits by angle
            Vector3 targetDir = (hit.transform.position - origin).normalized;
            float angleToHit = Vector3.Angle(targetDir, aimDirection);
            if (angleToHit > AttackHalfAngle) continue;

            // damage the target
            if (hit.TryGetComponent(out IDamageble targetHealth))
            {
                DamageInfo damageInfo = new DamageInfo(Damage, gameObject, instigator, Type);
                targetHealth.Damage(damageInfo);
            }
        }
    }
}

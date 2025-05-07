using FMODUnity;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [field: Header("Weapon")]
    [field: SerializeField] public float Damage { get; private set; } = 5f;
    [field: SerializeField] public float FireRate { get; private set; } = 1f;
    [field: SerializeField] public float Duration { get; private set; } = 1f;
    [field: SerializeField] public float Range { get; private set; } = 5f;
    [field: SerializeField] public float EffectiveRange { get; private set; } = 4f;


    [field: Header("Feedback")]
    [field: SerializeField] public EventReference SFX { get; private set; }
    [field: SerializeField] public string AnimationTriggerName { get; private set; }
    protected Animator Animator { get; private set; }

    public float Cooldown => 1f / FireRate;
    private float _lastActivationTime = -Mathf.Infinity;

    private void Awake()
    {
        Animator = GetComponentInParent<Animator>();
    }

    public virtual bool TryAttack(Vector3 aimPosition, GameObject instigator, int team)
    {
        // check cooldown
        if (Time.time < _lastActivationTime + Cooldown) return false;
        _lastActivationTime = Time.time;

        Attack(aimPosition, instigator, team);
        return true;
    }

    public virtual void Attack(Vector3 aimPosition, GameObject instigator, int team)
    {
        // do attack
        // play oneshot FMOD event
        //if (!SFX.IsNull) RuntimeManager.PlayOneShot(SFX, transform.position);
        if (!string.IsNullOrEmpty(AnimationTriggerName)) Animator.SetTrigger(AnimationTriggerName);
    }
}

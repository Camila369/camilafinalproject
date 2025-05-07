using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Tuning")]
    private float _currentHP;
    [SerializeField] private float _maxHP = 100f;
    [Header("Debug")]
    [ShowInInspector] public float Percentage => _currentHP / _maxHP;
    [ShowInInspector] public bool IsAlive => _currentHP >= 1f;

    private void Start()
    {
        _currentHP = _maxHP;
    }

    public UnityEvent<DamageInfo> OnDamageReceived;
    public UnityEvent<DamageInfo> OnDeath;

    public void DamageReceived(DamageInfo damageinfo)
    {
        if (!IsAlive) return; // if dead, don't do damage

        if (damageinfo.Amount < 1f) return; // no negative damage

        _currentHP -= damageinfo.Amount; // current HP equals current HP -  damage

        OnDamageReceived.Invoke(damageinfo);
        Debug.Log($"{name} takes {damageinfo.Amount} damage");

        // handle death
        if (!IsAlive)
        {
            OnDeath.Invoke(damageinfo);
            Death();
        }
    }

    private void Death()
    {
        Debug.Log($"{name} has died.");
    }
}

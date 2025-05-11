using CharacterMovement;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public Health Health { get; private set; }
    public CharacterMovement25D Movement { get; private set; }

    public Weapon[] Weapons { get; private set; }

    protected virtual void Awake()
    {
        Movement = gameObject.GetComponent<CharacterMovement25D>();
        Health = gameObject.GetComponent<Health>();
    }

    private void FindWeapons()
    {
        Weapons = GetComponentsInChildren<Weapon>();
    }
}

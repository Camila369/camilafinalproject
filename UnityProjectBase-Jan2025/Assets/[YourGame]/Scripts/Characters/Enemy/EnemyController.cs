using CharacterMovement;
using Sirenix.OdinInspector;
using System.Collections;
using System.Runtime.Remoting.Lifetime;
using System.Xml;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class EnemyController : Controller
{
    [Header("Enemy Stats")]
    [SerializeField] private float _viewDistance = 5f;
    private bool canSeePlayer = false;
    // ternary conditional operator
    // [if] ? [true] : [false]
    // this reads: if _currentState is not null, return the current state name, else return empty string

    [Header("State Machine")]
    [ShowInInspector] private string CurrentStateName => _currentState != null ? _currentState.ToString() : "";
    private IEnumerator _currentState;
    private StateMachine _stateMachine;

    [Header("States")]
    IdleState idleState = new IdleState();
    PatrolState patrolState = new PatrolState();
    ChaseState chaseState = new ChaseState();
    AttackState attackState = new AttackState();
    DeadState deadState = new DeadState();

    [Header("Components")]
    private MyPlayerController Player;

    [Header("Waypoints")]
    [SerializeField] public Waypoint Waypoint0;
    [SerializeField] public Waypoint Waypoint1;
    [SerializeField] public Waypoint Waypoint2;

    [Header("Weapon")]
    [ShowInInspector] public Weapon weapon;


    private void Start()
    {

        if (TryGetComponent(out Health health))
        {
            health.OnDeath.AddListener(Death);
            health.OnDamageReceived.AddListener(Damaged);
        }

        //create new state machine
        _stateMachine = new StateMachine();
        _stateMachine.InitializeStateMachine(patrolState);
    }

    //private void FixedUpdate()
    //{
    //    _stateMachine.FixedUpdate(Time.fixedDeltaTime);
    //}

    //private void Update()
    //{
    //    _stateMachine.Update(Time.deltaTime);
    //}

    public bool IsTargetInRange(float range)
    {
        if (Player != null && Vector2.Distance(Player.transform.position, transform.position) < range) return true;
        return false;
    }

    public bool IsTargetVisible()
    {
        return IsTargetInRange(_viewDistance);
    }


    public void Death(DamageInfo damageInfo)
    {
        _stateMachine.ChangeState(deadState);
    }

    public void Damaged(DamageInfo damageInfo)
    {
        if (damageInfo.Instigator == Player.gameObject)
        {
            _stateMachine.ChangeState(chaseState);
        }
    }

}

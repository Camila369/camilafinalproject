using CharacterMovement;
using UnityEngine;
using System;
using Sirenix.OdinInspector;

public abstract class State : MonoBehaviour
{
    [field: Header("State Machine")]
    //[SerializeField] public States _currentState = States.Idle;
    protected StateMachine _stateMachine;

    //[field: Header("Animation")]
    //protected Animator animationController;
    //protected string animationName;
    //protected bool isAnimationFinished;

    [field: Header("Control")]
    protected bool isExitingState;
    protected float startTime;
    protected EnemyController enemy;
    protected PlayerController player;
    protected float _timer = 0f;

    [Header("States")]
    protected IdleState idleState;
    protected PatrolState patrolState;
    protected ChaseState chaseState;
    protected AttackState attackState;
    protected DeadState deadState;

    //public enum States
    //{
    //    Idle,
    //    Patrol,
    //    Chase,
    //    Attack
    //}

    //private void Update()
    //{
    //    switch (_currentState)
    //    {
    //        case States.Idle:
    //            //look for target
    //        break;
    //        case States.Patrol:
    //            // walk patrol path
    //        break;
    //        case States.Chase:
    //            //calculate movement
    //        break;
    //        case States.Attack:
    //            //attack
    //        break;
    //    }
    //}

    public virtual void FixedUpdate() { }

    public virtual void Update() 
    {
        _timer += Time.deltaTime;
    }

    public virtual void Enter()
    {

        isExitingState = false;
        startTime = Time.time;

        //animation
        //isAnimationFinished = false;
        //animationController.SetBool(animationName, true);
    }
    public virtual void Exit()
    {
        isExitingState = true;

        //animation
        //if (!isAnimationFinished) isAnimationFinished = true;
        //animationController.SetBool(animationName, false);
    }
}

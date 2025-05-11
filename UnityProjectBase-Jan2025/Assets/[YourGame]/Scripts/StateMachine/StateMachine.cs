using System;
using UnityEngine;
using UnityEngine.Playables;

public abstract class StateMachine
{
    //public State<T> CurrentState { get; private set; }
    public State CurrentState;

    public void ChangeState(State newState)
    {
        if (CurrentState != null) CurrentState.Exit();
        CurrentState = newState;
        newState.Enter();
    }

    public void InitializeStateMachine(State initialState)
    {
        CurrentState = initialState;
        CurrentState.Enter();
    }




}

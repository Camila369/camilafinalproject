using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class PatrolState : State
{
    private Waypoint _waypoints;
    private Waypoint _waypoint0;
    private Waypoint _waypoint1;
    private Waypoint _waypoint2;
    private float _reachedDistance = 1f;
    private string lastWaypoint = "";
    private string currentWaypoint = "";

    bool isPatroling; //check if the enemy is in patrol route

    public override void Enter()
    {
        base.Enter();
        _waypoints = enemy.Waypoints[Random.Range(0, enemy.Waypoints.Length)]; // waypoint that is closer to the enemy
        _waypoint0 = enemy.Waypoints[0];
        _waypoint1 = enemy.Waypoints[1];
        _waypoint2 = enemy.Waypoints[2];

        float distance0 = Vector3.Distance(enemy.transform.position, _waypoint0.Position);
        float distance1 = Vector3.Distance(enemy.transform.position, _waypoint1.Position);
        float distance2 = Vector3.Distance(enemy.transform.position, _waypoint2.Position);

        //check if it is at waypoint or not
        if (distance0 < _reachedDistance)
        {
            
            currentWaypoint = "0";
            isPatroling = true; //return if is patrolling or not

        }
        else if (distance1 < _reachedDistance)
        {

            currentWaypoint = "1";
            isPatroling = true; //return if is patrolling or not
        }
        else if (distance2 < _reachedDistance)
        {

            currentWaypoint = "2";
            isPatroling = true; //return if is patrolling or not
        }
        else
        {
            isPatroling = false; //return if is patrolling or not
        }
    }

    public override void Update()
    {
        base.Update();

        float distance0 = Vector3.Distance(enemy.transform.position, _waypoint0.Position);
        float distance1 = Vector3.Distance(enemy.transform.position, _waypoint1.Position);
        float distance2 = Vector3.Distance(enemy.transform.position, _waypoint2.Position);

        if (!isPatroling) //if is not in the patrol route yet
        {
            // move to nearest waypoint

            // if waypoint0 is closer
            if (distance0 < distance1 && distance0 < distance2) // if waypoint0 is closer
            {
                if (distance0 > _reachedDistance) // if has not reached waypoint 0
                {
                    //move to waypoint 0
                    enemy.Movement.MoveTo(_waypoint0.Position);
                }
                else if (distance0 < _reachedDistance) // if is at waypoint 0
                {
                    // is at waypoint 0
                    currentWaypoint = "0";
                    //is patrolling
                    isPatroling = true;
                    _stateMachine.ChangeState(idleState);
                }

            }
            // if waypoint1 is closer
            else if (distance1 < distance0 && distance1 < distance2) // if waypoint1 is closer
            {

                if (distance1 > _reachedDistance) // if has not reached waypoint 1
                {
                    //move to waypoint 1
                    enemy.Movement.MoveTo(_waypoint1.Position);
                }
                else if (distance1 < _reachedDistance)  // if is at waypoint 1
                {
                    // is at waypoint 0
                    currentWaypoint = "1";
                    //is patrolling
                    isPatroling = true;
                    _stateMachine.ChangeState(idleState);
                }
            }
            // if waypoint2 is closer
            else if (distance2 < distance0 && distance2 < distance1) // if waypoint2 is closer
            {

                if (distance0 > _reachedDistance) // if has not reached waypoint 2
                {
                    //move to waypoint 2
                    enemy.Movement.MoveTo(_waypoint2.Position);
                }
                else if (distance2 < _reachedDistance) // if is at waypoint 2
                {
                    // is at waypoint 2
                    currentWaypoint = "2";
                    //is patrolling
                    isPatroling = true;
                    _stateMachine.ChangeState(idleState);
                }
            }
        }
        else if (isPatroling) // if is following the patrol route
        {
            //patrol
            if (currentWaypoint == "0")
            {
                //move to waypoint 1

                if (distance1 > _reachedDistance)
                {
                    // too far, move to waypoint 1
                    enemy.Movement.MoveTo(_waypoint1.Position);

                }
                else
                {
                    // too close, switch to idle
                    _stateMachine.ChangeState(idleState);
                }
            }
            else if (currentWaypoint == "1" && lastWaypoint == "0")
            {
                //move to waypoint 2

                if (distance2 > _reachedDistance)
                {
                    // too far, move to waypoint 2
                    enemy.Movement.MoveTo(_waypoint2.Position);

                }
                else
                {
                    // too close, switch to idle
                    _stateMachine.ChangeState(idleState);
                }
            }
            else if ((currentWaypoint == "1" && lastWaypoint == "2") || (currentWaypoint == "1" && lastWaypoint == ""))
            {
                // move to waypoint 0

                if (distance0 > _reachedDistance)
                {
                    // too far, move to waypoint 0
                    enemy.Movement.MoveTo(_waypoint0.Position);

                }
                else
                {
                    // too close, switch to idle
                    _stateMachine.ChangeState(idleState);
                }
            }
            else if(currentWaypoint == "2")
            {
                // move to waypoint 1

                if (distance1 > _reachedDistance)
                {
                    // too far, move to waypoint 1
                    enemy.Movement.MoveTo(_waypoint1.Position);

                }
                else
                {
                    // too close, switch to idle
                    _stateMachine.ChangeState(idleState);
                }
            }

        }


        if (enemy.IsTargetVisible())
        {
            _stateMachine.ChangeState(chaseState);
        }
    }
}

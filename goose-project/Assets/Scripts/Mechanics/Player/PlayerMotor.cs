using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    private Transform _target;      // Target to follow
    private NavMeshAgent _agent;    // Player agent
    private float _rotationSpeed = 5f;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Could be tramuted into Coroutine to increase performances
        if(_target != null)
        {
            _agent.SetDestination(_target.position);
            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        _agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        _agent.stoppingDistance = newTarget.radius * .8f;
        _agent.updateRotation = false;
        _target = newTarget.transform;
    }

    public void StopFollowingTarget()
    {
        _agent.stoppingDistance = 0;
        _agent.updateRotation = true;
        _target = null;
    }

    private void FaceTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _rotationSpeed);
    }
}

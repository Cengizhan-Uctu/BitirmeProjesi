using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMesh;
    [SerializeField] AnimatorManager anim;
    public void Move(GameObject enemy)
    {
        if (enemy != null)
        {
            navMesh.SetDestination(enemy.transform.position);
            anim.PlayerWalkAnimation();
        }
    }
    public void Stop()
    {
            anim.PlayerStopAnimation();
            navMesh.isStopped = true;
    }

}

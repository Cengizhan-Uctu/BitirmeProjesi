using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMesh;
    [SerializeField] AnimatorManager anim;
    [SerializeField] Rigidbody rigidbody;
    public static bool isMove;
    private void Start()
    {
        isMove = true;
    }

    private void Update()
    {
        if (isMove == false)
        {
            Stop();
        }
    }
    public void Move(GameObject enemy)
    {
        
        if (enemy != null)
        {
            navMesh.isStopped = false;
            isMove = true;
            navMesh.SetDestination(enemy.transform.position);
            anim.PlayerWalkAnimation();
            
        }
    }
    public void Stop()
    {
        navMesh.isStopped = true;
        anim.PlayerStopAnimation();
    }

}

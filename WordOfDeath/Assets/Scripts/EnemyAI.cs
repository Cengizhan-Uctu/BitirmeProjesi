using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    [SerializeField] NavMeshAgent nawMeshEnemy;
    PlayerMove playerMove;
    [SerializeField] private Animator anim;// değiştir daha iyi bir kodlama bul
    GameObject playerTransform;
    private bool dontmowe=false;
    private void Start()
    {
      
        playerTransform = GameObject.FindGameObjectWithTag("Player");
        playerMove = playerTransform.GetComponent<PlayerMove>();
        playerMove = new PlayerMove();
    }
    private void FixedUpdate()
    {
        if (dontmowe==false)
        {
            nawMeshEnemy.SetDestination(playerTransform.transform.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
            anim.Play("Death");
            nawMeshEnemy.enabled = false;
            dontmowe = true;
            Destroy(gameObject, 4);
            //StartCoroutine(PlayerStop());
        }
    }
    IEnumerator PlayerStop()
    {
        yield return new WaitForSeconds(3);
        playerMove.Stop();
    }

}

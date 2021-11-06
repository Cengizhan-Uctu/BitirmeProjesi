using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] float speed;
    private GameObject enemy;
    private bool isFire = false;
    public void ShottEnemy(string enemyName)
    {
        enemy = GameObject.Find(enemyName);
        isFire = true;
    }
    private void Update()
    {
        if (isFire)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime);
        }

    }
  
   
}

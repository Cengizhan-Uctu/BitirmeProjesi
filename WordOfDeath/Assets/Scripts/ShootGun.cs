using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] AnimatorManager anim;
    [SerializeField] GameObject gun;
    [SerializeField] PlayerMove playerMove;
    public void MarkingEnemy(string enemyName)
    {

        StartCoroutine(FireDeley(enemyName));
        // yüzünü düşmana dönmesi için
        GameObject enemy = GameObject.Find(enemyName);//hedefi aradıgı için 
        transform.LookAt(enemy.transform.position);  // StartCoroutine(LookAtEnemy(enemy));
        playerMove.Move(enemy);// enemy e dogru hareket etmesi için

        

    }
    IEnumerator FireDeley(string EnemyName)
    {
        yield return new WaitForSeconds(0.15f);
        GameObject newbullet = Instantiate(bullet, gun.transform.position, Quaternion.identity);
        newbullet.GetComponent<BulletMove>().ShottEnemy(EnemyName);
        anim.ShoothAnimation();
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] Transform[] spawnTransforms;
    public void SpawnEnemy(string enemyName)
    {
        int randomTransform = Random.Range(0, spawnTransforms.Length);
       GameObject enemy= Instantiate(Enemy,spawnTransforms[randomTransform].position,Quaternion.identity);
       enemy.name = enemyName;
    }
  
}

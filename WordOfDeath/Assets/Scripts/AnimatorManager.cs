using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField] Animator Playeranimations;
  //  [SerializeField] Animator EnemyAnimator;
    public void ShoothAnimation()
    {
        
        Playeranimations.Play("Shoot");
    }
    public void PlayerWalkAnimation()
    {
        Playeranimations.SetInteger("WalkParam", 1);
    }
    public void PlayerStopAnimation()
    {
        Playeranimations.SetInteger("WalkParam", 0);
    }
    public void ZombiDeadAnim()
    {
       
       // EnemyAnimator.Play("Deat");
    }
   
    
}

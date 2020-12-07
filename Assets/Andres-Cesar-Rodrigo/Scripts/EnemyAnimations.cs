using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    public Animator animator;
    public AnimationClip death;
    public AnimationClip walking;
    public AnimationClip tookDamage;
    public AnimationClip attacking;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = true;
    }

    public void AttackFalse()
    {
        StartCoroutine(AnimLength(attacking));
        animator.SetBool("isAttacking", false);
    }

    IEnumerator AnimLength(AnimationClip time)
    {
        yield return new WaitForSeconds(time.length);
    }
}

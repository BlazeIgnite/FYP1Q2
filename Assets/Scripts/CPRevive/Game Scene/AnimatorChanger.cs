using UnityEngine;

public class AnimatorChanger : MonoBehaviour
{

    public Animator animator;
    public RuntimeAnimatorController[] Controllers;

    void Start()
    { }

    void Update()
    { }


    public void ChangeAnimator(int type)
    {
        // 0 = IDLE
        // 1 = BAD/MISS
        // 2 = PERFECT
        animator.runtimeAnimatorController = Controllers[type];
    }
}

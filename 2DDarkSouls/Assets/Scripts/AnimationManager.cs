using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    Animator animator;
    private string currentState = null;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    internal void ChangeAnimState(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }
}

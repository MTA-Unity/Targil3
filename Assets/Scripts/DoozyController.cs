using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoozyController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private static readonly int ChangeDance = Animator.StringToHash(ChangeDanceTrigger);

    private const string ChangeDanceTrigger = "ChangeDance";
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger(ChangeDance);   
        }
    }
}

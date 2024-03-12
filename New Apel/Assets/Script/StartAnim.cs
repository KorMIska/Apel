using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartAnim : MonoBehaviour
{
    public GameObject obj;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = obj.GetComponent<Animator>();  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (animator != null) 
        {
            animator.SetBool("ISActive", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (animator != null)
        {
            animator.SetBool("ISActive", false);
        }
    }
}
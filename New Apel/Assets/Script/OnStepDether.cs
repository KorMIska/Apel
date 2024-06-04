using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStepDether : MonoBehaviour
{
    [SerializeField] float maxTime;

    private float timer;

    private void Awake()
    {
        timer = maxTime;
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (timer <= 0)
            {
                timer = maxTime;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

}

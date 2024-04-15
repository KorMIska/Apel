using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStepDether : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        print("triger");
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().Damage(25);
        }
    }

}

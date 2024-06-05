using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStepDether : MonoBehaviour
{
    public int longTimer;
    public int damage;
    private int timer = 0;

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (timer == 0)
            {
                other.gameObject.GetComponent<Player>().Damage(damage);
                timer = longTimer;
            }
            print(timer);
            timer--;

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int HP;
    public int MaxHP = 100;

    public string Name;

    public void Damage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Dether();
        }
    }

    public void Dether()
    {
        print("Ты мёртв");
        HP = MaxHP;
        transform.position = GameObject.FindWithTag("SpawnPoin").transform.position;
    }

}

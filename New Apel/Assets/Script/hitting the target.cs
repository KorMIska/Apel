using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Target_ : MonoBehaviour
{
    public GameObject[] gameObjects;

    void OnCollisionEnter(Collision collision)
    {
        UnityEngine.Color color = new UnityEngine.Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        GetComponent<MeshRenderer>().material.color = color;

        foreach (var item in gameObjects)
        {
            item.GetComponent<ChangeWallText>().AddScore();
        }


    }
}
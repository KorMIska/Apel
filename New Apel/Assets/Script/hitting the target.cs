using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Target_ : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        UnityEngine.Color color = new UnityEngine.Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        GetComponent<MeshRenderer>().material.color = color;

        GameObject obj = GameObject.FindWithTag("Text");
        if (obj != null)
        {
            obj.GetComponent<ChangeWallText>().Ochki++;
        }
    }
}
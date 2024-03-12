using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dether_Efect : MonoBehaviour
{
    public int  _timer;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.FindWithTag("Player");
        if (obj != null) { _timer = obj.GetComponent<Atak>().timer; }
    }

private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().Damage(25);

           
        }
       
         //Destroy(this.gameObject);
   
    }

}

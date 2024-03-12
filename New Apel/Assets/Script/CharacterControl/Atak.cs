using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Atak : MonoBehaviourPunCallbacks
{
    public GameObject object_toSpawn;
    private Animator animator;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public float force = 9000;
    public int timer = 200;
    public int Number—harges = 6;
    public int CurentCharges = 0;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurentCharges <= 0)
        {
            animator.SetTrigger("Recharge");
        }
        else
        if (Input.GetButtonDown("Fire1") && CurentCharges > 0)
        {
            animator.SetTrigger("Atak");
            CurentCharges--;

        }

        
    }

    void Recharge()
    {
        CurentCharges = Number—harges;
    }

    void InitOb()
    {
        if (animator != null && CurentCharges > 0 && object_toSpawn != null && spawnPoint1 != null && spawnPoint2 != null)
        {
            int i = animator.GetInteger("NomerAtak");
            i = i == 0 ? 1 : 0;
            animator.SetInteger("NomerAtak", i);

            GameObject obg;
            if (i == 0)
                obg = PhotonNetwork.Instantiate(object_toSpawn.name, spawnPoint1.position, spawnPoint1.rotation);
            else
                obg = PhotonNetwork.Instantiate(object_toSpawn.name, spawnPoint2.position, spawnPoint2.rotation);

            if (obg != null)
            {
                var rb = obg.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce(transform.forward * force);
                    print(transform.forward * force);
                }
            }
        }
    }

}

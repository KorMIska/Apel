using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Atak : MonoBehaviour
{
    public GameObject object_toSpawn;
    private Animator animator;
    public Transform spawnPoint;
    public float force = 100;
    public int timer = 200;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Atak");
        }
    }

    void InitOb()
    {
        var i = Instantiate(object_toSpawn, spawnPoint.position, spawnPoint.rotation);
        var rb = i.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force);
    }

}

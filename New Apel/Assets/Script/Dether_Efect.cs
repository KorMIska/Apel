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

    // Update is called once per frame
    void Update()
    {
        _timer--;
        if (_timer == 0) 
        {
            Destroy(this.gameObject);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Updat : MonoBehaviour
{
    Atak atak;
    public GameObject obj;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        atak = obj.GetComponent<Atak>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = atak.CurentCharges.ToString();
    }
}

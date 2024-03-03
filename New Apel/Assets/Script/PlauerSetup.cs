using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlauerSetup : MonoBehaviour
{
    // public NewBehaviourScript component;

    public MonoBehaviour[] componens;
    public GameObject cam;

    public void  IsLocalPlayer()
    {
        // component.enabled = true;
        foreach (var item in componens)
        {
            item.enabled = true;
        }
        cam.SetActive(true);
    }
}

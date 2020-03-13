using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This makes sure that the object isn't unloaded while also preventing multiple copies.
//


public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
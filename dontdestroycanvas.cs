using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class dontdestroycanvas : MonoBehaviour
{

    public int say = 0;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("canvas");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
  


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alevtopu : MonoBehaviour
{

    public float _min = 5f;
    public float _max = 15f;
    // Use this for initialization
    void Start()
    {

        _min = transform.position.y;
        _max = transform.position.y + 7;

    }

    // Update is called once per frame
    void Update()
    {


        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * 4, _max - _min) + _min, transform.position.z);
    }

    

}
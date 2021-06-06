using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareketY : MonoBehaviour
{

    public float _min = 2f;
    public float _max = 3f;
    // Use this for initialization
    void Start()
    {

        _min = transform.position.y;
        _max = transform.position.y + 3;

    }

    // Update is called once per frame
    void Update()
    {


        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * 2, _max - _min) + _min, transform.position.z);
    }
}
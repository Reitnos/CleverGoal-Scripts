using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HareketX : MonoBehaviour
{   

    public float _min = 5f;
    public float _max = 5f;
    // Use this for initialization
    void Start()
    {

        _min = transform.position.x;
        _max = transform.position.x + 3;

    }

    // Update is called once per frame
    void Update()
    {


        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, _max - _min) + _min, transform.position.y, transform.position.z);
    }

}

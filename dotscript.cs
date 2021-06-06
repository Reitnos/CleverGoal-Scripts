using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dotscript : MonoBehaviour
{

    public float xofhook;
    public float xofsprite;
    public float xofball;
    public float yofhook;
    public float yofsprite;
    public float yofball;
    private Transform sprite;

    void Update()
    {


        xofhook = GameObject.Find("hook").transform.position.x;

        xofball = GameObject.Find("ball").transform.position.x;

        xofsprite = transform.position.x;

        yofhook = GameObject.Find("hook").transform.position.y;

        yofball = GameObject.Find("ball").transform.position.y;

        yofsprite = transform.position.y;


        xofsprite = xofhook + (xofhook - xofball);
        yofsprite = yofhook + (yofhook - yofball) ;

    
        sprite = GetComponent<Transform>();
        sprite.position = new Vector2(xofsprite, yofsprite);




    }

}

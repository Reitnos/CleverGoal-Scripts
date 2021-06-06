using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMovement : MonoBehaviour
{

    private Rigidbody2D myRigidbody;
    [SerializeField]
    private float hiz;
   
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HareketBulut();
    }

    void HareketBulut()
    {
        myRigidbody.velocity = new Vector2(hiz*5,0);
    }
}

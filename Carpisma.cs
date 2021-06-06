using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carpisma : MonoBehaviour
{
    
    private CircleCollider2D topCollider;
    [SerializeField]
    private BoxCollider2D basamakCollider;
    [SerializeField]
    private BoxCollider2D basamakTrigger;
    // Start is called before the first frame update
    void Start()
    {
        topCollider = GameObject.Find("ball").GetComponent<CircleCollider2D>();
        Physics2D.IgnoreCollision(basamakCollider, basamakTrigger, true);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "ball")
        {
            Physics2D.IgnoreCollision(basamakCollider, topCollider, true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.name == "ball")
        {
            Physics2D.IgnoreCollision(basamakCollider, topCollider, false);
        }
    }
   
}

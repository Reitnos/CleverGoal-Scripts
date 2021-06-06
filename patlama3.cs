sing System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patlama3 : MonoBehaviour
{
    [SerializeField]
    private Animator myAnimator;
    [SerializeField]
    private Rigidbody2D myRigidbody;
    [SerializeField]
    private AudioSource patlamaSesi;
    private bool sestrue = true;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        

        if (other.gameObject.name == "ball")
        {
            myAnimator.SetBool("topPatla", true);

            myRigidbody.velocity = new Vector2(0, 0);
            if (sestrue)
            {
                patlamaSesi.Play();

            }
            GameObject.Find("ball").GetComponent<SpringJoint2D>().enabled = false;
            sestrue = false;
        }
        
    }

    public void sestekrar()
    {
        sestrue = true;
    }
}

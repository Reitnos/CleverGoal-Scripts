using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PATLAMA : MonoBehaviour
{
    [SerializeField]
    private Animator myAnimator;
    [SerializeField]
    private Rigidbody2D myRigidbody;
    [SerializeField]
    private AudioSource patlamaSesi;
    public bool sestrue = true;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
            
        if(other.gameObject.name == "ball")
        {
            myAnimator.SetBool("topPatla", true);
           
            myRigidbody.velocity= new Vector2(0, 0);
            if (sestrue)
            {
            patlamaSesi.Play();

            }

        }
    sestrue = false;
    }

    public void sestekrar()
    {
        sestrue = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GOL : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    
    private Animator myAnimator;
    [SerializeField]
    private Animator yourAnimator;
   
    [SerializeField]
    public AudioSource fileSes;
    [SerializeField]
    public AudioSource golBagir;

    private float bekle = 0.5f;
    [SerializeField]
    private BoxCollider2D bc;
    
  
   

    private void Start()
    {

        myAnimator = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "ball")
        {
            rb.velocity = new Vector2(0, 0);

            myAnimator.SetBool("kale", true);

            yourAnimator.SetBool("text", true);

            fileSes.Play();

            bc.isTrigger = true;
        }
       
       
            
        IEnumerator _Release()
        {
            yield return new WaitForSeconds(bekle);

            golBagir.Play();
        }
        StartCoroutine(_Release());
    
    }
    
    
}

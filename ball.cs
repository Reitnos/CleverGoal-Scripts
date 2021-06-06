using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ball : MonoBehaviour
{
    [SerializeField]
    public float donmebırak;
    public float releaseTime = .15f;
    private bool isPressed = false;
    public float maxDragDistance = 2f;
    public Rigidbody2D rb;
    [SerializeField]
    public Rigidbody2D rigid;
    public Rigidbody2D hook;
    [SerializeField]
    private Transform rotate;
    private bool donmeaktif;
    [SerializeField]
    private GameObject buton;
    private Animator an;
    private GameObject dotlar;
    public GameObject tutucu;
    public canbari can;
    [SerializeField]
    private GameObject yildiz1;
    [SerializeField]
    private GameObject yildiz2;
    [SerializeField]
    private GameObject yildiz3;
    [SerializeField]
    private GameObject bitismenu;
    


    [SerializeField]
    public AudioSource topSes;
    [SerializeField]
    public AudioSource backSes;

    [SerializeField]
    public AudioSource bounceSes;
    [SerializeField]
    public AudioSource Star1;
    [SerializeField]
    public AudioSource Star2;
    [SerializeField]
    public AudioSource Star3;

    [SerializeField]
    public GameObject Retry;





    private SpringJoint2D control;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        dotlar = GameObject.Find("Dots");
        tutucu = GameObject.Find("Tutucu");

           
        
       
    }
    void FixedUpdate()
    {
        

        if (isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
            {
                rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;

            }
            else
                rb.position = mousePos;
           
        }
        if (donmeaktif)
        {
            if(rigid.velocity.x >100)
            dondur();
        }
    }
    void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
        
    }
    void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
        tutucu.GetComponent<CircleCollider2D>().enabled = false;
       

        IEnumerator Release()
        {
            yield return new WaitForSeconds(releaseTime);
            GetComponent<SpringJoint2D>().enabled = false;
            dotlar.SetActive(false);
        }
        StartCoroutine(Release());
        topSes.Play();
        IEnumerator _Release()
        {
            yield return new WaitForSeconds(donmebırak);

            donmeaktif = true;
           
        }
        StartCoroutine(_Release());
      
     }
    

    void dondur()
    {
        rotate.transform.Rotate(0, 0, -200*Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
       if(other.gameObject.name == "goalfront" )
        {
            donmeaktif = false;
            rigid.gravityScale = 0;
            buton.SetActive(true);
            
         
            bitismenu.SetActive(true);
            Retry.SetActive(false);
            if (can.i == 1)
            {
                IEnumerator yildizibekle()
                {
                    yield return new WaitForSeconds(1.5f);
                    yildiz1.SetActive(true);
                    Star1.Play();

                }
                StartCoroutine(yildizibekle());
              

            }
            if (can.i == 2)
            {
                IEnumerator yildizibekle()
                {
                    yield return new WaitForSeconds(1.5f);
                    yildiz1.SetActive(true);
                    Star1.Play();
                }
                StartCoroutine(yildizibekle());


                IEnumerator yildizibekle2()
                {
                    yield return new WaitForSeconds(2.5f);
                    yildiz2.SetActive(true);
                    Star2.Play();
                }
                StartCoroutine(yildizibekle2());


            }
            if (can.i== 3)
            {

                IEnumerator yildizibekle()
                {
                    yield return new WaitForSeconds(1.5f);
                    yildiz1.SetActive(true);
                    Star1.Play();
                }
                StartCoroutine(yildizibekle());

                IEnumerator yildizibekle2()
                {
                    yield return new WaitForSeconds(2.5f);
                    yildiz2.SetActive(true);
                    Star2.Play();

                }
                StartCoroutine(yildizibekle2());
                IEnumerator yildizibekle3()
                {
                    yield return new WaitForSeconds(3.2f);
                    yildiz3.SetActive(true);
                    Star3.Play();
                }
                StartCoroutine(yildizibekle3());

            }




        }
       if(other.gameObject.tag == "background")
        {
            bounceSes.Play();
        }
      
    }
  
        
   

    void durdur()
    {
        if(rigid.velocity.x < 100 && rigid.velocity.y <= 10)
        {
            rigid.velocity = new Vector2(0, 0);
            rigid.freezeRotation = true;
        }
    }



}

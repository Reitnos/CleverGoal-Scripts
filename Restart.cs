using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    [SerializeField]
    public GameObject cember;
    public EdgeCollider2D cemberedge;
    [SerializeField]
    public GameObject cember2;
    public EdgeCollider2D cember2edge;
    [SerializeField]
    public GameObject cember3;
    public BoxCollider2D cember3box;
    private Transform hookposition;
   
    private Transform ballposition;
    public GameObject tutucu;
    private SpringJoint2D topaUlas;
    private SpringJoint2D baglimi;
    private Rigidbody2D rgid;
    [SerializeField]
    public canbari script;
    public Animator patlamaanim;
    public PATLAMA patlama;
    public PATLAMA patlama2;
    public PATLAMA patlama3;
    public PATLAMA patlama4;
    public Patlama2 patlama5;
    public Patlama2 patlama6;
    public GameObject dotlar;

    private Transform redtutucu;
    private Transform red;
    [SerializeField]
    private GameObject blueline;
   


  
     private SpringJoint2D tut1;
    private SpringJoint2D tut2;
    private void Start()
    {
        dotlar = GameObject.Find("Dots");
        patlamaanim = GameObject.Find("ball").GetComponent<Animator>();
        tutucu = GameObject.Find("Tutucu");
        cemberedge = cember.GetComponent<EdgeCollider2D>();
        cember2edge = cember2.GetComponent<EdgeCollider2D>();
        cember3box = cember3.GetComponent<BoxCollider2D>();
       
    }
   
   
    public void topuYerineKoy()
    {
        ballposition = GameObject.Find("ball").transform;
        hookposition = GameObject.Find("hook").transform;

        ballposition.position = new Vector2(hookposition.position.x,hookposition.position.y);
        
        
    }
    
    public void canAzalt()
    {
        baglimi = GameObject.Find("ball").GetComponent<SpringJoint2D>();
         if( baglimi.enabled != true )
        {
            script.health -= 1;

        }

        
        
    }
    public void dotlariYenile()
    {
        dotlar.SetActive(true);
    }
    public void collideriac()
    {
        tutucu.GetComponent<CircleCollider2D>().enabled = true;
        Debug.Log("error2");
    }
    public void chainbagla()
    {
        Debug.Log("error");
        tut1 = GameObject.Find("tut1").GetComponent<SpringJoint2D>();
        tut2 = GameObject.Find("tut2").GetComponent<SpringJoint2D>();
        

        redtutucu = GameObject.Find("Reditutucu").GetComponent<Transform>();
        red = GameObject.Find("Kırmızı").GetComponent<Transform>();
        tut1.enabled = true;
        tut2.enabled = true;
        red.position = new Vector2(redtutucu.position.x , redtutucu.position.y);
        blueline.SetActive(true);
   


    }
    public void kapakapa()
    {
        cemberedge.enabled = false;
        cember.SetActive(false);
        cember2edge.enabled = false;
        cember2.SetActive(false);
        cember3box.enabled = false;
        cember3.SetActive(false);
    }

    public void bagiBagla()
    {

        topaUlas = GameObject.Find("ball").GetComponent<SpringJoint2D>();
        topaUlas.enabled = true;
        rgid = GameObject.Find("ball").GetComponent<Rigidbody2D>();
        rgid.velocity = new Vector2(0, 0);
        patlamaanim.Rebind();
        patlama.sestrue = true;
        patlama2.sestrue = true;
        patlama3.sestrue = true;
        patlama4.sestrue = true;
        patlama5.sestrue = true;
        patlama6.sestrue = true;



    }

}






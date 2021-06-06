using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatered : MonoBehaviour
{
    
    [SerializeField]
    private AudioSource buttonsound;
    private SpringJoint2D tut1;
    private SpringJoint2D tut2;

    
    void Start()
    {
           tut1 = GameObject.Find("tut1").GetComponent<SpringJoint2D>();
         tut2 = GameObject.Find("tut2").GetComponent<SpringJoint2D>();
      
    }

    public void redac()
    {
        tut1.enabled = false;
        tut2.enabled = false;
        
        buttonsound.Play();
    }
}

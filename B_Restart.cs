using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class B_Restart : MonoBehaviour
{

    private Transform pc;

    private Transform ballposition;
   
   
    private Rigidbody2D rgid;
    [SerializeField]
    public canbari script;
    public Animator patlamaanim;
   
    private void Start()
    {
        
        patlamaanim = GameObject.Find("ThrownObject").GetComponent<Animator>();
        
    }

    public void topuYerineKoy()
    {
        ballposition = GameObject.Find("ThrownObject").transform;
        pc = GameObject.Find("PullCtrl").transform;

        ballposition.position = new Vector2(pc.position.x, pc.position.y);

    }
    public void bagiBagla()
    {

        
        
        rgid = GameObject.Find("ThrownObject").GetComponent<Rigidbody2D>();
        rgid.velocity = new Vector2(0, 0);
        patlamaanim.Rebind();
    }
    public void canAzalt()
    {
        script.health -= 1;
    }
    
   


}


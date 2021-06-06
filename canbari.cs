using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canbari : MonoBehaviour
{
    public Canvas canvaskapa;
    public int health = 3;
    public int numOfHearts = 3;
    public int refint;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject ball;
    public Animator myAnimator;
    public int healthcontrol;
    [SerializeField]
    public GameObject Duduk;
    private SpringJoint2D baglimi;
   
    public int i = 3;
   
    private void Start()
    
    {
        myAnimator = GameObject.Find("bitis").GetComponent<Animator>();
        ball = GameObject.Find("ball");


        
      
        
    }
        private void Update()
        {
        healthcontrol = health;
            if (healthcontrol > 0)
            {
            cangoster();
           
        }
        else
        {
            healthcontrol -= 1;
            cangoster();
            myAnimator.SetBool("oyunbitti", true);
            ball.SetActive(false);
            canvaskapa.enabled = false;
            Duduk.SetActive(true);
          
                       
            

        }
        }
        public void cangoster()
        {
            if (healthcontrol > numOfHearts)
            {
                healthcontrol = numOfHearts;

            }

            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < health)
                {
                    hearts[i].sprite = fullHeart;

                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }
                if (i < numOfHearts)
                {
                    hearts[i].enabled = true;

                }
                else
                {
                    hearts[i].enabled = false;
                }
            }


        }

    public void iartir()
    {

        baglimi = GameObject.Find("ball").GetComponent<SpringJoint2D>();
        if(baglimi.enabled != true)
        {
                i--;

        }

        
    }

}






    


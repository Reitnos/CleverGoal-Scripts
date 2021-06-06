using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mavibuton : MonoBehaviour
{
    public GameObject weight;
    public Animator button;
    
    
    
    private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.name == "ball")
            {
                button.enabled = true;
                weight.SetActive(false);
            
            }
        }
        
    
}

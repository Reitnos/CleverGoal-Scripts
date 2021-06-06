using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direkses : MonoBehaviour
{
    [SerializeField]
    private AudioSource direkSes;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "ball")
        {
            direkSes.Play();
        }
    }
}

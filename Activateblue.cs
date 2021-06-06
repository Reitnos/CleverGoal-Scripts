using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Activateblue : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject blueline;
    [SerializeField]
    private AudioSource buttonsound;

    void Start()
    {
        blueline = GameObject.Find("Blueline");   
    }

  public void blueac()
    {
        blueline.SetActive(false);
        buttonsound.Play();
    }
}

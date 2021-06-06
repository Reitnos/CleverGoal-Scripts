using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giris : MonoBehaviour
{
    [SerializeField]
    public Animator anim;
    [SerializeField]
    public GameObject ses;
    [SerializeField]
    public GameObject ses2;

    public bool izin = false;

    public void baslat()
    {
       
        anim.enabled = true;
        ses.SetActive(false);
        ses2.SetActive(true);
        IEnumerator izinver()
        {
            yield return new WaitForSeconds(1f);
            izin = true;
        }
        StartCoroutine(izinver());

    }
}

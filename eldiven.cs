using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eldiven : MonoBehaviour
{
    private bool isPressed = false;
    public Rigidbody2D hook;
    public Rigidbody2D rb;
    [SerializeField]
    public Rigidbody2D rigid;
    public float maxDragDistance = 2f;
    private bool donmeaktif;
    public GameObject tutucu;
    public float releaseTime = .15f;
    private GameObject dotlar;
    [SerializeField]
    public AudioSource topSes;
    [SerializeField]
    public float donmebırak;
    private Transform rotate;
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
            if (rigid.velocity.x > 100)
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
        rotate.transform.Rotate(0, 0, -200 * Time.deltaTime);
    }
}

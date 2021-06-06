using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragİndicator : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D top;

 
    Vector3 startPos;
    public Vector3 endPos;
    Camera camera;
    LineRenderer lr;
    Vector3 camOffset = new Vector3(0, 0, 10);
    [SerializeField] AnimationCurve ac;
    [SerializeField]
    public Rigidbody2D hook;
    public float maxDragDistance = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        top = GetComponent<Rigidbody2D>();
        hook = GameObject.Find("hook").GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

      
            if (Input.GetMouseButtonDown(0))
            {
                if (lr == null)
                {
                    lr = gameObject.AddComponent<LineRenderer>();
                }
                lr.enabled = true;
                lr.sortingOrder = 1;
                lr.material = new Material(Shader.Find("Sprites/Default"));
                lr.material.color = Color.red;
                lr.positionCount = 2;
                startPos = hook.position;
                lr.SetPosition(0, startPos);
                lr.useWorldSpace = true;
                lr.widthCurve = ac;
                lr.numCapVertices = 10;
                if (Vector3.Distance(startPos, hook.position) > 4)
                {
                    lr.enabled = false;
                }
            }
            if (Input.GetMouseButton(0))
            {


                Vector2 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Vector3.Distance(endPos, hook.position) > maxDragDistance)
                {
                endPos = hook.position + (endPos - hook.position).normalized * maxDragDistance;

            }

                lr.SetPosition(1, endPos);

            }
            if (Input.GetMouseButtonUp(0))
            {
                lr.enabled = false;



            }


        }
    


       
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ball2 : MonoBehaviour
{
    [SerializeField]
    public float donmebırak;
    public float releaseTime = .15f;
    private bool isPressed = false;
    public float maxDragDistance = 2f;
    public Rigidbody2D rb;
    [SerializeField]
    public Rigidbody2D rigid;
    public Rigidbody2D hook;
    [SerializeField]
    private Transform rotate;
    public bool donmeaktif;
    [SerializeField]
    private GameObject buton;
    private Animator an;
    private GameObject dotlar;
    public GameObject tutucu;
    public canbari can;
    [SerializeField]
    private GameObject yildiz1;
    [SerializeField]
    private GameObject yildiz2;
    [SerializeField]
    private GameObject yildiz3;
    [SerializeField]
    private GameObject bitismenu;



    [SerializeField]
    public AudioSource topSes;
    [SerializeField]
    public AudioSource backSes;

    [SerializeField]
    public AudioSource bounceSes;
    [SerializeField]
    public AudioSource Star1;
    [SerializeField]
    public AudioSource Star2;
    [SerializeField]
    public AudioSource Star3;
    [SerializeField]
    public AudioSource trambolinSes;

    [SerializeField]
    public GameObject Retry;

    public GameObject trajectoryDot;
    private GameObject[] trajectoryDots;
    public int number;

    public LineRenderer catapultLineFront;
    public LineRenderer catapultLineBack;
    
    private GameObject sapanfront;


    private SpringJoint2D control;
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 forcePlayer;
    public float forcefactor;

    private GameObject canv;
    private Text text;
    private dontdestroycanvas script;
   
  
 

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        dotlar = GameObject.Find("Dots");
        tutucu = GameObject.Find("Tutucu");
        trajectoryDots = new GameObject[number];
        sapanfront = GameObject.Find("sapanfront");

        LineRendererSetup();
      
     
     

        


    }
    void Update()
    {
       
                

            if (Input.GetMouseButton(0))
            {
                endPos = gameObject.transform.position;
                forcePlayer = endPos - startPos;
              
                    for (int i = 0; i < number; i++)
                    {
                        trajectoryDots[i].transform.position = calculatePosition(i * 0.1f);
                    }
                
            }
        
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
        if(this.gameObject.transform.position.x > sapanfront.transform.position.x)
        {
            catapultLineBack.sortingOrder = 11;
        }
        else
        {
            catapultLineBack.sortingOrder = 1;
        }
        LineRendererUpdate();
        void LineRendererUpdate()
        {
          
            Vector3 holdPoint = transform.position;
            catapultLineFront.SetPosition(1, holdPoint);
            catapultLineBack.SetPosition(1, holdPoint);
        }

    }
    void LineRendererSetup()
    {
        catapultLineFront.SetPosition(0, catapultLineFront.transform.position);
        catapultLineBack.SetPosition(0, catapultLineBack.transform.position);

       catapultLineFront.sortingLayerName = "Foreground";
       catapultLineBack.sortingLayerName = "Foreground";

        catapultLineBack.sortingOrder = 1;
        catapultLineFront.sortingOrder = 11;

       
    }
  
    private Vector2 calculatePosition(float elapsedTime)
    {
        return new Vector2(hook.position.x,hook.position.y) + new Vector2(-forcePlayer.x * forcefactor, -forcePlayer.y * forcefactor) * elapsedTime + 0.5f * Physics2D.gravity * elapsedTime * elapsedTime;
    }
    
    void OnMouseDown()
    {

        if (!(Vector3.Distance(rb.position, hook.position) > maxDragDistance)) { 
        
        
            catapultLineFront.enabled = true;
            catapultLineBack.enabled = true;
            isPressed = true;
            rb.isKinematic = true;
            startPos = hook.position;
        
            for (int i = 0; i < number; i++)
            {
                trajectoryDots[i] = Instantiate(trajectoryDot, gameObject.transform);
            }
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
        

    }
    void OnMouseUp()
    {
       
             isPressed = false;
        donmeaktif = true;
        rb.isKinematic = false;
        tutucu.GetComponent<CircleCollider2D>().enabled = false;
        rigid.constraints = RigidbodyConstraints2D.None;

       


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
        for (int i = 0; i < number; i++)
        {
            Destroy(trajectoryDots[i]);
        }

        IEnumerator line()
        {
            yield return new WaitForSeconds(0.3f);
            catapultLineFront.enabled = false;
            catapultLineBack.enabled = false;
            
        }
        StartCoroutine(line());

    }


    void dondur()
    {
        rotate.transform.Rotate(0, 0, -200 * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "goalfront")
        {
            donmeaktif = false;
            rigid.gravityScale = 0;
            buton.SetActive(true);


            bitismenu.SetActive(true);
            Retry.SetActive(false);
            if (can.i == 1)
            {
                IEnumerator yildizibekle()
                {
                    yield return new WaitForSeconds(1.5f);
                    yildiz1.SetActive(true);
                    Star1.Play();

                }
                StartCoroutine(yildizibekle());
                text = GameObject.Find("Number").GetComponent<Text>();
                canv = GameObject.Find("Say");
                script = canv.GetComponent<dontdestroycanvas>();
                script.say += 1;
                text.text = script.say.ToString();

              
                IEnumerator digerbolum()
                {
                    yield return new WaitForSeconds(3f);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                }
                StartCoroutine(digerbolum());


            }
            if (can.i == 2)
            {
                IEnumerator yildizibekle()
                {
                    yield return new WaitForSeconds(1.5f);
                    yildiz1.SetActive(true);
                    Star1.Play();
                }
                StartCoroutine(yildizibekle());


                IEnumerator yildizibekle2()
                {
                    yield return new WaitForSeconds(2.5f);
                    yildiz2.SetActive(true);
                    Star2.Play();
                }
                StartCoroutine(yildizibekle2());

                text = GameObject.Find("Number").GetComponent<Text>();
                canv = GameObject.Find("Say");
                script = canv.GetComponent<dontdestroycanvas>();
                script.say += 2;
                text.text = script.say.ToString();

                IEnumerator digerbolum()
                {
                    yield return new WaitForSeconds(4f);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                }
                StartCoroutine(digerbolum());
            }
            if (can.i == 3)
            {

                IEnumerator yildizibekle()
                {
                    yield return new WaitForSeconds(1.5f);
                    yildiz1.SetActive(true);
                    Star1.Play();
                }
                StartCoroutine(yildizibekle());

                IEnumerator yildizibekle2()
                {
                    yield return new WaitForSeconds(2.5f);
                    yildiz2.SetActive(true);
                    Star2.Play();

                }
                StartCoroutine(yildizibekle2());
                IEnumerator yildizibekle3()
                {
                    yield return new WaitForSeconds(3.2f);
                    yildiz3.SetActive(true);
                    Star3.Play();
                }
                StartCoroutine(yildizibekle3());

                text = GameObject.Find("Number").GetComponent<Text>();
                canv = GameObject.Find("Say");
                script = canv.GetComponent<dontdestroycanvas>();
                script.say += 3;
                text.text = script.say.ToString();

                IEnumerator digerbolum()
                {
                    yield return new WaitForSeconds(4.8f);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                }
                StartCoroutine(digerbolum());

            }
           




        }
        if (other.gameObject.tag == "background")
        {
            bounceSes.Play();
        }
        if (other.gameObject.tag == "trambolin")
        {
            trambolinSes.Play();
        }

    }




    void durdur()
    {
        if (rigid.velocity.x < 100 && rigid.velocity.y <= 10)
        {
            rigid.velocity = new Vector2(0, 0);
            rigid.freezeRotation = true;
        }
    }



}


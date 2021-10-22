using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    #region Player Stats
    public int health = 1;
    public float speed;
    public float jumpHeight;
    public float platDisty;
    public float platDistx;
    public float enemyDistx;
    public float knockback;
    #endregion
    #region GC and RB
    public Rigidbody2D rb;
    public GameObject GameController;
    public AudioSource audio;
    public AudioClip[] sounds = new AudioClip[9];
    #endregion
    #region Bools
    [HideInInspector] public bool jumping = false;
    [HideInInspector] public bool aPress = false;
    [HideInInspector] public bool dPress = false;
    [HideInInspector] public bool jPress = false;
    [HideInInspector] public bool Hit = false;
    [HideInInspector] public bool walking = false;
    [HideInInspector] public bool grounded = false;
    [HideInInspector] public bool dying = false;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        audio.clip = sounds[0];
        audio.loop = true;
        audio.volume = 0.5f;
    }
    
    void Update()
    {
        if (GameController == null)
        {
            GameController = GameObject.Find("Game Controller");
        }
        #region Player Input Checker
        if (Input.GetKey("a"))
        {
            aPress = true;
        }
        else { aPress = false; }
        if (Input.GetKey("d"))
        {
            dPress = true;
        }
        else { dPress = false; }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            aPress = true;
        }
        else { aPress = false; }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dPress = true;
        }
        else { dPress = false; }

        if (!jumping)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                jPress = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && !dying)
        {
            GameController.GetComponent<Game_Controller>().red = !GameController.GetComponent<Game_Controller>().red;
        }
        #endregion
    }

    void FixedUpdate()
    {
        #region Movement Code
        float hAdd = 0f;

        Vector3 jump = new Vector3(0, jumpHeight, 0);

        if (dPress || aPress && grounded && !dying)
        {
            if (!walking)
            {
                audio.Play();
                walking = true;
            }
        }
        else {
            if (!dying)
            {
                audio.Stop();
                walking = false;
            }
        }

        if (!grounded)
        {
            audio.Stop();
            walking = false;
        }

        if (dPress == true) { hAdd += speed; }
        if (aPress == true) { hAdd -= speed; }

        if (!Hit && !dying)
        {
            rb.velocity = new Vector2(hAdd, rb.velocity.y);
        }

        if (jPress && !dying) {
            rb.AddForce(jump);
            jPress = false;
            jumping = true;
            grounded = false;
        }
        #endregion
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Platform"))
        {
            if (collider.gameObject.transform.position.y - transform.position.y < platDisty && Mathf.Abs(collider.gameObject.transform.position.x - transform.position.x) < platDistx)
            {
                jumping = false;
                grounded = true;
            }
        }
        if (collider.gameObject.CompareTag("Floor"))
        {
            jumping = false;
            grounded = true;
        }

        if (collider.gameObject.CompareTag("Enemy"))
        {
            if (collider.gameObject.transform.position.y - transform.position.y < platDisty && Mathf.Abs(collider.gameObject.transform.position.x - transform.position.x) < enemyDistx)
            {
                Vector3 jump = new Vector3(0, jumpHeight * 2, 0);
                rb.AddForce(jump);
            }
            else
            {
                if (collider.gameObject.transform.position.x - transform.position.x > 0)
                {
                    StartCoroutine("KnockbackL");
                }
                if (collider.gameObject.transform.position.x - transform.position.x < 0)
                {
                    StartCoroutine("KnockbackR");
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Spike"))
        {
            StartCoroutine("Death");
        }

        if (col.gameObject.CompareTag("Checkpoint"))
        {
            GameController.GetComponent<Game_Controller>().curCheckPoint = col.gameObject;
        }
    }

    IEnumerator KnockbackL()
    {
        Hit = true;
        rb.velocity = new Vector3(-knockback, knockback/3, 0);
        yield return new WaitForSeconds(0.3f);
        Hit = false;
    }

    IEnumerator KnockbackR()
    {
        Hit = true;
        rb.velocity = new Vector3(knockback, knockback / 3, 0);
        yield return new WaitForSeconds(0.3f);
        Hit = false;
    }

    IEnumerator Death()
    {
        audio.Stop();
        dying = true;
        rb.velocity = new Vector3(0,0,0);
        audio.clip = sounds[1];
        audio.volume = 1f;
        audio.loop = false;
        audio.Play();
        yield return new WaitForSeconds(2.5f);
        Instantiate(GameController.GetComponent<Game_Controller>().PlayerPreFab, GameController.GetComponent<Game_Controller>().curCheckPoint.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
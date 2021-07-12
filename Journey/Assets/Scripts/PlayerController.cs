using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Collider2D col;
    public Rigidbody2D rb;

    public float flyspeed = 8;
    public float speed = 30;

    public bool isFlying;

    public float moveVertical;
    public float moveHorizontal;

    public float flyTimeOut;

    public bool hasTriggered;
    public float timeSinceLastWalk;

    public bool pAINHELPPAIN;

    public GameObject ruby;

    public Animator anim;

    public GameObject aManager;
    public AudioManager aman;

    // Start is called before the first frame update
    void Start()
    {
      anim = GetComponent<Animator>();
      col = GetComponent<Collider2D>();
      rb = GetComponent<Rigidbody2D>();

      aManager = GameObject.Find("AudioManager");
      aman = aManager.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
      if (moveHorizontal == 0f) {
        hasTriggered = false;
        aman.Stop("step");
      } else {
        if (hasTriggered == false) {
          hasTriggered = true;
          aman.Play("step");
        }
      }
      flyTimeOut -= Time.deltaTime;
      if (flyTimeOut < 0) {
        flyTimeOut = 0;
      }
      if(Input.GetKeyDown("q") && flyTimeOut <= 0){
          isFlying = !isFlying;
          flyTimeOut = 0.5f;

          if (isFlying) {
            anim.Play("JumpToFly");
            aman.Play("takeoff");
            aman.Play("flap1");
            aman.Play("wind");
          } else {
            //Land
            aman.Stop("flap3");
            aman.Stop("wind");
          }
      }

      moveHorizontal = Input.GetAxis ("Horizontal");
      moveVertical = Input.GetAxis ("Vertical");

      if (isFlying) {
        aman.Play("flap1");
        rb.gravityScale = 0f;
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        rb.AddForce (movement * flyspeed);
        if (moveHorizontal > 0.2) {
          Vector3 temp = transform.localScale;
          temp.x = -0.35f;
          transform.localScale = temp;
          pAINHELPPAIN = true;
        }
        if (moveHorizontal < -0.2) {
          Vector3 temp = transform.localScale;
          temp.x = 0.35f;
          transform.localScale = temp;
          pAINHELPPAIN = false;
        }
      } else {
        if (timeSinceLastWalk >= 3f) {
          anim.Play("idle2");
        } else {
          timeSinceLastWalk += Time.deltaTime;
        }
        rb.gravityScale = 1f;
        if (moveVertical > 0.35) {
          gameObject.transform.position += speed * Time.deltaTime * new Vector3(0f,0.1f,0f);
        }
        if (moveVertical < -0.35) {
          gameObject.transform.position += speed * Time.deltaTime * new Vector3(0f,-0.1f,0f);
        }
        if (moveHorizontal > 0.2) {
          timeSinceLastWalk = 0f;
          anim.Play("Walk");
          gameObject.transform.position += speed * Time.deltaTime * new Vector3(0.1f,0f,0f);
        }
        if (moveHorizontal < -0.2) {
          anim.Play("Walk");
          timeSinceLastWalk = 0f;
          gameObject.transform.position += speed * Time.deltaTime * new Vector3(-0.1f,0f,0f);
        }

        if (moveHorizontal > 0.2) {
          Vector3 temp = transform.localScale;
          temp.x = -0.35f;
          transform.localScale = temp;
          pAINHELPPAIN = true;
        }
        if (moveHorizontal < -0.2) {
          Vector3 temp = transform.localScale;
          temp.x = 0.35f;
          transform.localScale = temp;
          pAINHELPPAIN = false;
        }
      }
    }

  void OnCollisionEnter2D (Collision2D other)
  {
    if (other.collider.tag == "Ground")
    {
      isFlying = false;
      //Land
      aman.Stop("flap3");
      aman.Stop("wind");
    }
  }
}

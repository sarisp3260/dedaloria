using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPlayerOne : MonoBehaviour
{
    public static CatPlayerOne obj;

    public int lives = 3;
    public bool isGrounded = false;
    public bool isMoving = false;
    public bool isImmune = false;

    public float speed = 4f;
    public float jumpForze = 5f;
    public float movHor;

    public LayerMask groundLayer;
    public float radius = 0.3f;
    public float groundRayDist = 0.5f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spr;

    void Awake()
    {
        obj = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movHor = Input.GetAxisRaw("Horizontal");

        isMoving = (movHor != 0f);

        isGrounded = Physics2D.CircleCast(transform.position, radius, Vector3.down, groundRayDist, groundLayer);

        Debug.Log(isGrounded);

        /* if (Input.GetKeyDown(KeyCode.W))
        {
           Jump();
        } */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        /* else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        } */

        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);

        Flip(movHor);
    }


    void FixedUpdate()
    {
        rb.velocity = new Vector2(movHor * speed, rb.velocity.y);
    }

    void Jump()
    {
        if (!isGrounded) return;

        rb.velocity = Vector2.up * jumpForze;
    }

    private void Flip(float _xValue)
    {
        Vector3 theScale = transform.localScale;

        if (_xValue < 0)
        {
            theScale.x = Mathf.Abs(theScale.x) * -1;
        }
        else if (_xValue > 0)
        {
            theScale.x = Mathf.Abs(theScale.x);
        }

        transform.localScale = theScale;
    }

    void OnDestroy()
    {
        obj = null;
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Vector3 endPosition;
    [SerializeField] float duration;
    [SerializeField] float speed;

    [SerializeField] float jumpSpeed;
    [SerializeField] int blinkNum;
    [SerializeField] AudioClip sfxPremios;
    [SerializeField] AudioClip sfxEnemy;
    [SerializeField] AudioClip sfxVida;
    [SerializeField] GameController game;
    [SerializeField] GameObject explosion;

    AudioSource sfx;
    Rigidbody2D rb;
    Collider2D col;
    Animator anim;

    bool active;

    float moveX;
    bool jump;
    Vector3 posicionInicial;

    Dictionary<string, int> premios = new Dictionary<string, int>
    {
        {"Cherry", 10},
        {"Carrot", 10},
        {"Gem", 20},
        {"Star", 40}
    };

    void Start()
    {
        posicionInicial = transform.position;
        rb = GetComponent<Rigidbody2D>();
        sfx = GetComponent<AudioSource>();

        StartCoroutine("StartPlayer");

        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    //velocidad de refresco constante para actualización
    void FixedUpdate()
    {
        if (active)
        {
            Run();
            Flip();
            Jump();

        }
    }

    void Update()
    {
        //movimiento del personaje

        //saber el movimiento en el eje x
        moveX = Input.GetAxisRaw("Horizontal");
        //GetButtonDown --> solo se activa en el frame que se pulsa la tecla. Así detectamos cuando salta el personaje.
        if (!jump && Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void Run()
    {
        Vector2 vel = new Vector2(moveX * speed * Time.fixedDeltaTime, rb.velocity.y);
        rb.velocity = vel;

        anim.SetBool("isWalking", Mathf.Abs(rb.velocity.x) > Mathf.Epsilon);
    }

    //establece el sentido de la dirección de nuestro personaje
    void Flip()
    {
        float vx = rb.velocity.x;
        //chequear si tiene velocidad
        if (Mathf.Abs(vx) > Mathf.Epsilon)
            transform.localScale = new Vector2(Mathf.Sign(vx) * -1, 1); //multiplico por -1 porque mi personaje tiene orientación izqu de origen.
    }

    void Jump()
    {
        if (!jump) return;

        jump = false;

        if (!col.IsTouchingLayers(LayerMask.GetMask("Terrain", "Platforms")))
            return;

        rb.velocity += new Vector2(0, jumpSpeed);

        anim.SetTrigger("isJumping");

    }


    IEnumerator StartPlayer()
    {
        Collider2D collider = GetComponent<Collider2D>();
        collider.enabled = false;

        Vector3 initialPosition = transform.position;

        Material mat = GetComponent<SpriteRenderer>().material;
        Color color = mat.color;

        float t = 0, t2 = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            Vector3 newPosition = Vector3.Lerp(initialPosition, endPosition, t / duration);
            transform.position = newPosition;

            t2 += Time.deltaTime;
            float newAlpha = blinkNum * (t2 / duration);
            if (newAlpha > 1)
            {
                t2 = 0;
            }
            color.a = newAlpha;
            mat.color = color;

            yield return null;
        }
        color.a = 1;
        mat.color = color;


        collider.enabled = true;
        active = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;


        if (premios.ContainsKey(tag))
        {
            sfx.clip = sfxPremios;
            sfx.Play();

            game.UpdateScore(premios[tag]);

            Destroy(other.gameObject);
        }

        else if (tag == "Enemy")
        {
            sfx.clip = sfxEnemy;
            sfx.Play();

            game.UpdateScore(50);

            Destroy(other.gameObject);
        }
        else if (tag == "Eagle")
        {
            sfx.clip = sfxVida;
            sfx.Play();

            game.LoseLife();

            if (!game.isGameOver())
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                //float tiempo = 2;
                Vector3 newPosition = Vector3.Lerp(posicionInicial, endPosition, 0);
                transform.position = newPosition;
            }

            else
            {
                DestroyPlayer();
            }


        }
    }

    void DestroyPlayer()
    {
        active = false;

        Instantiate(explosion, transform.position, Quaternion.identity);

        Destroy(gameObject);

    }
    

}

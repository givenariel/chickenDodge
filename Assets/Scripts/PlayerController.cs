using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float kecepatan;
    private float gerak;
    public float lompatan;
    private Rigidbody2D rb;
    private Animator animasi;
    private bool napak;
    private bool mati;
	
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animasi = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalinput = Input.GetAxis("Horizontal");

        gerak = horizontalinput;
        rb.velocity = new Vector2(gerak * kecepatan, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && napak)
        {
            Lompat();
        }

        if (horizontalinput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalinput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        animasi.SetBool("Jalan", horizontalinput != 0);
        animasi.SetBool("Napak", napak);
    }

    private void Lompat()
    {
        rb.velocity = new Vector2(0, lompatan);
        napak = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lantai")
            napak = true;
		
		if (collision.gameObject.tag == "Obstacle")
		{
			GameObject.Destroy (this.gameObject);
            SceneManager.LoadScene("GameOver");
        }
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("Level2");
        }
        if (collision.gameObject.tag == "Win")
        {
            SceneManager.LoadScene("Win");
        }
    }
}
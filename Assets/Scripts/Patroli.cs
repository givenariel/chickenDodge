using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public GameObject titikA;
	public GameObject titikB;
	public float kecepatan;
	private Rigidbody2D rb;
	private Animator animasi;
	private Transform titikSekarang;
	
    // Start is called before the first frame update
    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
		animasi = GetComponent<Animator>();
		titikSekarang = titikB.transform;
		animasi.SetBool("Lari", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 titik = titikSekarang.position - transform.position;
		if(titikSekarang == titikB.transform)
		{
			rb.velocity = new Vector2(kecepatan, 0);
		}
		else
		{
			rb.velocity = new Vector2(-kecepatan, 0);
		}
		
		if(Vector2.Distance(transform.position, titikSekarang.position) < 0.5f && titikSekarang	== titikB.transform)
		{
			flip();
			titikSekarang = titikA.transform;
		}
		if(Vector2.Distance(transform.position, titikSekarang.position) < 0.5f && titikSekarang	== titikA.transform)
		{
			flip();
			titikSekarang = titikB.transform;
		}
    }
	private void flip()
	{
		Vector3 localScale = transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}
}

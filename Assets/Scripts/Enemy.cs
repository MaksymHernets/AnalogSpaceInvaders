using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public Spaceship spaceship;
	public BoxCollider2D boxCollider;
	public Rigidbody2D rigidb;

	public int FrequencyFire = 1000;

	private float borderBoxCollider = 0f;

	private void Start()
	{
		spaceship.spacegun.FlipGun();
		spaceship.spacegun.SetColor(Color.red);
		borderBoxCollider = boxCollider.size.y * 0.5f + 0.1f;
	}

	private void Update()
	{
		if (Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - borderBoxCollider), Vector2.down).collider.tag != "Enemy")
		{
			if (Random.Range(0, FrequencyFire) == 1)
			{
				spaceship.spacegun.Fire();
				rigidb.AddForce(new Vector2(Random.Range(-100, 100), 0));
			}
		}
	}
}

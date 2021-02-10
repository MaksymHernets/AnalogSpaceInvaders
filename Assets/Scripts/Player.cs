using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Spaceship spaceship;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			collision.gameObject.SendMessage("Damage", 1000, SendMessageOptions.DontRequireReceiver);
			spaceship.Damage(1000);
		}
	}
}

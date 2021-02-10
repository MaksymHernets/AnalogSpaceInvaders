using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public int LotOfDamage = 100;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		collision.gameObject.SendMessage("Damage", LotOfDamage, SendMessageOptions.DontRequireReceiver);

		if (collision.transform.tag == "Block")
		{
			collision.gameObject.SetActive(false);
		}

		gameObject.SetActive(false);
	}
}

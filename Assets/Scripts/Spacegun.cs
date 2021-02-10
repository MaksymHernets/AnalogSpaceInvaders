using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spacegun : ISpacegun
{
	public GameObject SpaceShip;
	public GameObject prefabBullet;

	private int MaxBullet = 10;
	private GameObject[] PoolBullets;

	private float SpeedBullet = 30f;
	private float SpawnBullet = 0.7f;

	public Spacegun(GameObject spaceship, int maxBullet, GameObject prafabbullet, Color color )
	{
		SpaceShip = spaceship;
		MaxBullet = maxBullet;
		prefabBullet = prafabbullet;

		PoolBullets = new GameObject[MaxBullet];
		for (int i = 0; i < MaxBullet; ++i)
		{
			PoolBullets[i] = GameObject.Instantiate(prefabBullet);
			PoolBullets[i].GetComponent<SpriteRenderer>().color = color;
			PoolBullets[i].SetActive(false);
		}
	}

	public void FlipGun()
	{
		SpeedBullet *= -1f;
		SpawnBullet *= -1f;
	}

	public void Fire()
	{
		for (int i = 0; i < PoolBullets.Length; ++i)
		{
			if (PoolBullets[i].activeSelf == false)
			{
				PoolBullets[i].SetActive(true);
				PoolBullets[i].transform.localPosition = SpaceShip.transform.localPosition + new Vector3(0f, SpawnBullet, 0f);
				PoolBullets[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(0, SpeedBullet), ForceMode2D.Force);
				break;
			}
		}
	}

	public void Distroy()
	{
		for (int i = 0; i < MaxBullet; ++i)
		{
			GameObject.Destroy(PoolBullets[i]);
		}
	}

	public void SetColor(Color color)
	{
		for (int i = 0; i < MaxBullet; ++i)
		{
			PoolBullets[i].GetComponent<SpriteRenderer>().color = color;
		}
	}
}

public interface ISpacegun
{
	public void SetColor(Color color);
	public void FlipGun();
	public void Fire();
	public void Distroy();
}


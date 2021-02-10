using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
	public float XP = 100f;
	public float Speed = 1f;

	public ISpacegun spacegun;

	public GameObject prefabBullet;
	public ParticleSystem particleSystem;

	public delegate void Died();
	public event Died EventDied;
	
	private void Start()
	{
		spacegun = new Spacegun(this.gameObject, 4, prefabBullet, Color.white);
	}

	public void Damage(object value)
	{
		XP -= (int)value;
		if ( XP <= 0 )
		{
			if ( EventDied != null) { EventDied(); }
			StartCoroutine(Animation_Died());
		}
	}

	IEnumerator Animation_Died()
	{
		particleSystem.gameObject.SetActive(true);
		yield return new WaitForSecondsRealtime(0.5f);
		particleSystem.gameObject.SetActive(false);
		this.gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		//spacegun.Distroy();
	}
}

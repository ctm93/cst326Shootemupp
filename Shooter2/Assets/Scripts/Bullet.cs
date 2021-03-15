using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Needed to manipulate the UI
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

	public float speed = 30;

	private Rigidbody2D rigidBody;

	// Exploded alien Image
	public Sprite explodedAlienImage;

	// Use this for initialization
	void Start()
	{

		// Get reference to the ball Rigidbody
		rigidBody = GetComponent<Rigidbody2D>();

		// When the ball is created move it up
		// (0,1) at the desired speed
		rigidBody.velocity = Vector2.up * speed;

	}

	// Called every time a ball collides with something
	// the object it hit is passed as a parameter
	void OnTriggerEnter2D(Collider2D col)
	{
		// If Bullet hits a wall destroy bullet
		if (col.tag == "Wall")
		{
			Destroy(gameObject);
		}

		// If Bullet hits Alien destroy Alien and Bullet
		if (col.gameObject.tag == "Alien")
		{
			SoundManager.Instance.PlayOneShot(SoundManager.Instance.Enemydies);

			// Increase the Score Text component
			increaseTextUIScore();

			// Change to exploded alien image
			// spriteRenderer.sprite = explodedAlienImage;
			col.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;

			Destroy(gameObject);

			// Wait .5 seconds and then destroy Alien
			DestroyObject(col.gameObject, 0.5f);

		}

		// If Alien Bullet hits Shield destroy both
		if (col.tag == "Shield")
		{
			Destroy(gameObject);
			DestroyObject(col.gameObject);
		}
	}

	// Called when the Game Object isn't visible
	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}

	// Increases the score the the text UI name passed
	void increaseTextUIScore()
	{

		// Find the Score UI component
		var textUIComp = GameObject.Find("Score").GetComponent<Text>();
		var textUIComp2 = GameObject.Find("HiScore").GetComponent<Text>();

		// Get the string stored in it and convert to an int
		int score = int.Parse(textUIComp.text);
		int hiscore = int.Parse(textUIComp2.text);

		// Increment the score
		score += 10;
		hiscore += 10;

		// Convert the score to a string and update the UI
		textUIComp.text = score.ToString("00000");
		textUIComp2.text = hiscore.ToString("00000");
	}

}
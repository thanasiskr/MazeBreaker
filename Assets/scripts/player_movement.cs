using UnityEngine;

public class player_movement : MonoBehaviour
{
	//unity objects
	public AudioSource source;
	public AudioClip jumpsound;
	public GameManager manager;
	new public Transform camera;			//hides component
	public Rigidbody rb;
	//fields
	private float force = 7.0f;
	private float jump = 8.5f;          //match with cube height 


	private void Start()
	{
		source.clip = jumpsound;
	}
	void FixedUpdate()  //moving the player according to the transform of the camera
	{
		if (Input.GetKey("w"))
		{
			transform.position += camera.forward * Time.deltaTime * force;

		}
		if (Input.GetKey("s"))
		{
			transform.position -= camera.forward * Time.deltaTime * force;

		}
		if (Input.GetKey("d"))
		{
			transform.position += camera.right * Time.deltaTime * force;

		}
		if (Input.GetKey("a"))
		{
			transform.position -= camera.right * Time.deltaTime * force;

		}
		if (Input.GetKey("space"))
		{
			source.Play();
			transform.position +=camera.up * Time.deltaTime * jump;		

		}
		if (Input.GetKey("e"))      //Ending the game
		{
			if (rb.position.y >= 5 *manager.getLevelNumber())				//level number ,5=cube height
			{
				
				FindObjectOfType<GameManager>().endGame();
			}
		}
		if(Input.GetKey("x"))		//game ff
		{
			FindObjectOfType<GameManager>().gameOver();
		}

		if (Input.GetKey("r"))      //restarting the game
		{
			FindObjectOfType<GameManager>().restartGame();

		}
	}
}


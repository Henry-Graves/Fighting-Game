using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P2Controller : MonoBehaviour
{
	private GameObject controllerCharacter;
	private GameObject enemy;
	private Animator anim;
	public static AnimatorStateInfo animState;
	private bool facingLeft = false;
	private bool alreadyDead = false;
	private bool isGrounded = true;
	private bool canFall = true;
	private bool canPlayAudio = true;

	private Rigidbody rigidBody;
	private AudioSource playerAudio;
	[SerializeField] private AudioClip punch;
	[SerializeField] private AudioClip kick;
	[SerializeField] private AudioClip special;
	[SerializeField] private AudioClip punchWhoosh;
	[SerializeField] private AudioClip kickWhoosh;
	[SerializeField] private AudioClip die;

	[SerializeField] private GameObject enemyRoundWin;
	[SerializeField] private GameObject enemyMatchWin;

	// Start is called before the first frame update
	void Start()
	{
		StatsManager.timerWinEnabled = true;
		// Get all necessary references
		controllerCharacter = GameObject.Find("Player2");
		enemy = GameObject.Find("Player1");
		rigidBody = gameObject.GetComponent<Rigidbody>();
		anim = GetComponentInChildren<Animator>();
		playerAudio = gameObject.GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{

		// Gameplay loop if not paused
		if (!PauseMenu.IsPaused && !alreadyDead)
		{
			IsPlayerDead();

			FaceEnemy();

			AnimationsAndActions();
		}
	}

	// Detect and handle events if player health <= 0
	private void IsPlayerDead()
	{
		if (StatsManager.P2Health <= 0 && !alreadyDead)
		{
			StartCoroutine(KO());
			alreadyDead = true;
		}
	}

	// Detects input, plays animations, sound effects, and handles movement.
	private void AnimationsAndActions()
	{
		isGrounded = (gameObject.transform.position.y < 0.181f);
		animState = anim.GetCurrentAnimatorStateInfo(0);

		// Player animations
		if (animState.IsTag("Moving") || animState.IsTag("Jumping"))
		{
			if (Input.GetButtonDown("PunchP2"))
			{
				anim.SetTrigger("Punch");
				if (canPlayAudio && isGrounded)
				{
					canPlayAudio = false;
					playerAudio.clip = punchWhoosh;
					playerAudio.Play();
					StartCoroutine(AudioCooldown());
				}

			}
			if (Input.GetButtonDown("KickP2"))
			{
				anim.SetTrigger("Kick");
				if (canPlayAudio && isGrounded)
				{
					canPlayAudio = false;
					playerAudio.clip = kickWhoosh;
					playerAudio.Play();
					StartCoroutine(AudioCooldown());
				}

			}
			if (Input.GetButtonDown("SpecialP2"))
			{
				anim.SetTrigger("Special");
				if (canPlayAudio && isGrounded)
				{
					canPlayAudio = false;
					playerAudio.clip = kickWhoosh;
					playerAudio.Play();
					StartCoroutine(AudioCooldown());
				}

			}
			if (Input.GetAxis("BlockP2") > 0)
			{
				anim.SetBool("Block", true);
			}
			if (Input.GetAxis("BlockP2") == 0)
			{
				anim.SetBool("Block", false);
			}

			if (Input.GetAxis("HorizontalP2") > 0)
			{
				anim.SetBool("Forward", true);
				transform.Translate(0.035f, 0, 0);
			}
			else if (Input.GetAxis("HorizontalP2") < 0)
			{
				anim.SetBool("Backward", true);
				transform.Translate(-0.035f, 0, 0);
			}
			else
			{
				anim.SetBool("Forward", false);
				anim.SetBool("Backward", false);
			}
		}

		if (Input.GetAxis("VerticalP2") > 0 && !animState.IsTag("Jumping") && !animState.IsTag("KnockedOut"))
		{
			StartCoroutine(JumpCooldown());
		}
		else if (Input.GetAxis("VerticalP2") < 0)
		{
			anim.SetBool("Crouch", true);

			if (animState.IsTag("Crouching"))
			{
				if (Input.GetButtonDown("KickP2"))
				{
					anim.SetTrigger("Kick");
					if (canPlayAudio && isGrounded)
					{
						canPlayAudio = false;
						playerAudio.clip = kickWhoosh;
						playerAudio.Play();
						StartCoroutine(AudioCooldown());
					}
				}
			}
		}
		else
		{
			anim.SetBool("Crouch", false);
		}

		if (animState.IsTag("Blocking") && Input.GetAxis("BlockP2") == 0)
		{
			anim.SetBool("Block", false);
		}
	}

	// Keep the character facing the enemy
	private void FaceEnemy()
	{
		if (controllerCharacter.transform.position.x > enemy.transform.position.x)
		{
			if (facingLeft == false)
			{
				facingLeft = true;
				controllerCharacter.transform.Rotate(0, 180, 0);
				anim.SetLayerWeight(1, 1);
			}
		}
		if (controllerCharacter.transform.position.x < enemy.transform.position.x)
		{
			if (facingLeft == true)
			{
				facingLeft = false;
				controllerCharacter.transform.Rotate(0, -180, 0);
				anim.SetLayerWeight(1, 0);
			}
		}
	}

	// Detect and handle this character being hit
	private void OnTriggerEnter(Collider other)
	{
		if (!animState.IsTag("KnockedOut"))
		{
			if (other.gameObject.CompareTag("Fist"))
			{
				anim.SetTrigger("HeadReact");
				if (canPlayAudio)
				{
					canPlayAudio = false;
					playerAudio.clip = punch;
					playerAudio.Play();
					StartCoroutine(AudioCooldown());
				}
			}
			else if (other.gameObject.CompareTag("Kick"))
			{
				anim.SetTrigger("HeadReact");
				if (canPlayAudio)
				{
					canPlayAudio = false;
					playerAudio.clip = kick;
					playerAudio.Play();
					StartCoroutine(AudioCooldown());
				}
			}
			else if (other.gameObject.CompareTag("Special"))
			{
				if (canFall)
				{
					canFall = false;
					anim.SetTrigger("BigReact");
					if (canPlayAudio)
					{
						canPlayAudio = false;
						playerAudio.clip = special;
						playerAudio.Play();
						StartCoroutine(AudioCooldown());
					}
					StartCoroutine(FallCooldown());
				}
			}
		}
		
	}

	// Handle jumps and jump timing
	IEnumerator JumpCooldown()
	{
		if (!animState.IsTag("Jumping"))
		{
			anim.SetTrigger("Jump");
			yield return new WaitForSeconds(0.2f);
			if (isGrounded)
			{
				rigidBody.AddForce(new Vector3(0.0f, 2.0f, 0.0f) * 1.4f, ForceMode.Impulse);
			}
		}
		else
			yield break;
	}

	// Handle knockouts and knockout timing
	IEnumerator KO()
	{
		alreadyDead = true;
		controllerCharacter.SetActive(false);
		controllerCharacter.SetActive(true);
		anim.Play("knocked out");
		playerAudio.clip = die;
		playerAudio.Play();

		if (facingLeft)
		{
			StartCoroutine(P1Win(anim.GetCurrentAnimatorStateInfo(1).length));
		}
		else
		{
			StartCoroutine(P1Win(anim.GetCurrentAnimatorStateInfo(0).length));
		}

		yield return new WaitForSeconds(0.04f);
		// gameObject.GetComponent<P2Controller>().enabled = false;
	}

	// Displays win screen after death animation
	public IEnumerator P1Win(float delay)
	{
		StatsManager.timerWinEnabled = false;
		yield return new WaitForSeconds(delay);
		StatsManager.P2Hearts -= 1;

		// check if out of hearts, if so then display gameoverscreen
		if (StatsManager.P2Hearts == 0)
		{
			enemyMatchWin.SetActive(true);
			PauseMenu.P1Match = true;
		}
		else
		{
			enemyRoundWin.SetActive(true);
			PauseMenu.P1Round = true;
			StartCoroutine(ReloadScene());
		}
	}

	// Reload the fight scene, keeping UI elements
	public IEnumerator ReloadScene()
	{
		yield return new WaitForSeconds(3.0f);
		SceneManager.LoadScene(4);
	}

	// Handle cooldown timer for when the character can get knocked over
	IEnumerator FallCooldown()
	{
		yield return new WaitForSeconds(1.0f);
		canFall = true;
	}

	// Handle cooldown timer for when character audio can play
	IEnumerator AudioCooldown()
	{
		yield return new WaitForSeconds(0.2f);
		canPlayAudio = true;
	}
}

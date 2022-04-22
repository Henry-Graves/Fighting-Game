using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
	private AudioSource audio;
	[SerializeField] private AudioClip forward;
	[SerializeField] private AudioClip back;
	// all of these functions use the value of each scene in the build settings
	// if scenes are moved around values must be changed

	void Start()
	{
		audio = gameObject.GetComponent<AudioSource>();
	}

	public void BackToMenu()
	{
		audio.clip = back;
		audio.Play();
		MusicController.trackToPlay = 0;
		Time.timeScale = 1.0f;
		PauseMenu.IsPaused = false;
		SceneManager.LoadScene(0);
	}

	public void ToControls()
	{
		audio.clip = forward;
		audio.Play();
		SceneManager.LoadScene(1);
	}

	public void ToCharSelect()
	{
		audio.clip = forward;
		audio.Play();
		SceneManager.LoadScene(2);
	}

	public void QuitGame()
	{
		audio.clip = back;
		audio.Play();
		Debug.Log("QUIT!");
		Application.Quit();
	}

	public void Rematch()
	{
		audio.clip = forward;
		audio.Play();
		StatsManager.P1Hearts = 2;
		StatsManager.P2Hearts = 2;
		SceneManager.LoadScene(4);
	}

	public void Continue()
	{
		audio.clip = forward;
		audio.Play();
		StatsManager.P1Hearts = 2;
		StatsManager.P2Hearts = 2;
		SceneManager.LoadScene(3);
	}
}

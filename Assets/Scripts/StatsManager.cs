using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StatsManager : MonoBehaviour
{
	public static float P1Health = 1.0f;
	public static float P2Health = 1.0f;
	public static int P1Hearts = 2;
	public static int P2Hearts = 2;
	public static bool CanDamage;
	private GameObject P1;
	private GameObject P2;

	// variables for the timer
	private int roundTime = 60;
	private float lastTimeUpdate = 0;
	public TMP_Text timer;
	public static bool timerWinEnabled = true;

	// used to control the round count
	public GameObject P1Ui;
	public GameObject P2Ui;
	private bool ScoreUpdated;

	// UI elements for player healthbars
	[SerializeField] private TMP_Text P1HealthNumber;
	[SerializeField] private TMP_Text P2HealthNumber;
	private int temp1;
	private int temp2;

	// UI for if a round is a draw
	[SerializeField] private GameObject DrawScreen;

	// Start is called before the first frame update
	void Start()
	{
		P1 = GameObject.Find("Player1");
		P2 = GameObject.Find("Player2");
		CanDamage = true;
		ScoreUpdated = false;
		PauseMenu.P1Round = false;
		PauseMenu.P1Match = false;
		PauseMenu.P2Round = false;
		PauseMenu.P2Match = false;
	}

	void Update()
	{
		// timer script
		if (roundTime > 0 && Time.time - lastTimeUpdate > 1)
		{
			roundTime--;
			lastTimeUpdate = Time.time;
		}

		// Handling round score updates if the timer runs out and players are still alive
		// If timer runs out, the player with the higher percentage of their starting health wins
		if (roundTime <= 0 && !ScoreUpdated && timerWinEnabled)
		{
			CanDamage = false;

			if (gameObject.GetComponent<HealthBars>().Player1Health.fillAmount > gameObject.GetComponent<HealthBars>().Player2Health.fillAmount)
			{
				StartCoroutine(P2.GetComponentInParent<P2Controller>().P1Win(0));
			}
			else if (gameObject.GetComponent<HealthBars>().Player1Health.fillAmount < gameObject.GetComponent<HealthBars>().Player2Health.fillAmount)
			{
				StartCoroutine(P1.GetComponentInParent<P1Controller>().P2Win(0));
			}
			else
			{
				DrawScreen.SetActive(true);
				StartCoroutine(P1.GetComponentInParent<P1Controller>().ReloadScene());
			}
			ScoreUpdated = true;
		}
		timer.text = roundTime.ToString();

		// Display health as ints instead of floats
		temp1 = Mathf.RoundToInt(P1Health * 100);
		temp2 = Mathf.RoundToInt(P2Health * 100);

		if (temp1 == 0 && P1Health > 0)
			P1HealthNumber.text = "1";
		else if (temp1 < 0)
			P1HealthNumber.text = "0";
		else
			P1HealthNumber.text = temp1.ToString();

		if (temp2 == 0 && P2Health > 0)
			P2HealthNumber.text = "1";
		else if (temp2 < 0)
			P2HealthNumber.text = "0";
		else
			P2HealthNumber.text = temp2.ToString();

		// This controls the round count UI and ensures the heart is removed after the death animation
		if (P1Hearts == 1)
		{
			P1Ui.transform.Find("Heart2").gameObject.SetActive(false);
		}
		if (P2Hearts == 1)
		{
			P2Ui.transform.Find("Heart2").gameObject.SetActive(false);
		}
		if (P1Hearts == 0)
		{
			P1Ui.transform.Find("Heart2").gameObject.SetActive(false);
			P1Ui.transform.Find("Heart1").gameObject.SetActive(false);
		}
		if (P2Hearts == 0)
		{
			P2Ui.transform.Find("Heart2").gameObject.SetActive(false);
			P2Ui.transform.Find("Heart1").gameObject.SetActive(false);
		}
	}
}

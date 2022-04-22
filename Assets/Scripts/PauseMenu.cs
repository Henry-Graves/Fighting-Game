using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public static bool IsPaused = false;
	public static bool P1Round = false;
	public static bool P2Round = false;
	public static bool P1Match = false;
	public static bool P2Match = false;
	public GameObject P1RoundWin;
	public GameObject P2RoundWin;
	public GameObject P1MatchWin;
	public GameObject P2MatchWin;
	public GameObject PauseUI;

    // Update is called once per frame
    void Update()
    {
		 if (Input.GetKeyDown(KeyCode.Escape))
		 {
			 if (IsPaused)
			 {
				 Resume();
			 }
			 else
			 {
				 Pause();
			 }
		 }
    }

	 public void Resume()
	 {
		 PauseUI.SetActive(false);
		 Time.timeScale = 1f;
		 IsPaused = false;
		 if (P1Round)
		 {
			 P1RoundWin.SetActive(true);
		 }
		 if (P2Round)
		 {
			 P2RoundWin.SetActive(true);
		 }
		 if (P2Match)
		 {
			 P2MatchWin.SetActive(true);
		 }
		 if (P1Match)
		 {
			 P1MatchWin.SetActive(true);
		 }
	 }

	 void Pause()
	 {
		 PauseUI.SetActive(true);
		 P1RoundWin.SetActive(false);
		 P2RoundWin.SetActive(false);
		 P1MatchWin.SetActive(false);
		 P2MatchWin.SetActive(false);
		 Time.timeScale = 0f;
		 IsPaused = true;
	 }
}

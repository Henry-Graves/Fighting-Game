using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class HighlightedCharacter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	[SerializeField] private TextMeshProUGUI p1Name;
	[SerializeField] private TextMeshProUGUI p2Name;

	[SerializeField] private GameObject gills1;
	[SerializeField] private GameObject morph1;
	[SerializeField] private GameObject zlorp1;
	[SerializeField] private GameObject maw1;
	[SerializeField] private GameObject warrok1;
	[SerializeField] private GameObject ely1;
	[SerializeField] private GameObject astra1;

	[SerializeField] private GameObject gills2;
	[SerializeField] private GameObject morph2;
	[SerializeField] private GameObject zlorp2;
	[SerializeField] private GameObject maw2;
	[SerializeField] private GameObject warrok2;
	[SerializeField] private GameObject ely2;
	[SerializeField] private GameObject astra2;

	[SerializeField] private GameObject continueButton;

	private AudioSource audio;
	[SerializeField] private AudioClip select;
	[SerializeField] private AudioClip reset;

	public static int player = 1;

	public static string CharacterSelectionP1;
	public static string CharacterSelectionP2;

	public static bool p1Selected;
	public static bool p2Selected;

	// Start is called before the first frame update
	void Start()
	{
		player = 1;

		p1Selected = false;
		p2Selected = false;

		p1Name.gameObject.SetActive(false);
		p2Name.gameObject.SetActive(false);
		audio = gameObject.GetComponent<AudioSource>();
	}

	public void OnPointerClick(PointerEventData pointerEventData)
	{
		// Player choose character
		// Update which player has been chosen
		audio.clip = select;
		audio.Play();
		if (pointerEventData.pointerClick.gameObject.CompareTag("Gills"))
		{
			if (player == 1)
			{
				p1Name.text = "gills";
				p1Name.gameObject.SetActive(true);
				gills1.SetActive(true);
				CharacterSelectionP1 = "Gills";
				player = 2;
				p1Selected = true;
				Debug.Log("P1 Click");
			}

			else if (player == 2)
			{
				p2Name.text = "gills";
				p2Name.gameObject.SetActive(true);
				gills2.SetActive(true);
				CharacterSelectionP2 = "Gills";
				player = -1;
				p2Selected = true;
				Debug.Log("P2 Click");
				continueButton.SetActive(true);
			}
		}

		if (pointerEventData.pointerClick.gameObject.CompareTag("Morph"))
		{
			if (player == 1)
			{
				p1Name.text = "morph";
				p1Name.gameObject.SetActive(true);
				morph1.SetActive(true);
				CharacterSelectionP1 = "Morph";
				player = 2;
				p1Selected = true;
				Debug.Log("P1 Click");

			}

			else if (player == 2)
			{
				p2Name.text = "morph";
				p2Name.gameObject.SetActive(true);
				morph2.SetActive(true);
				CharacterSelectionP2 = "Morph";
				player = -1;
				p2Selected = true;
				Debug.Log("P2 Click");
				continueButton.SetActive(true);
			}
		}

		if (pointerEventData.pointerClick.gameObject.CompareTag("Zlorp"))
		{
			if (player == 1)
			{
				p1Name.text = "zlorp";
				p1Name.gameObject.SetActive(true);
				zlorp1.SetActive(true);
				CharacterSelectionP1 = "Zlorp";
				player = 2;
				p1Selected = true;
				Debug.Log("P1 Click");
			}

			else if (player == 2)
			{
				p2Name.text = "zlorp";
				p2Name.gameObject.SetActive(true);
				zlorp2.SetActive(true);
				CharacterSelectionP2 = "Zlorp";
				player = -1;
				p2Selected = true;
				Debug.Log("P2 Click");
				continueButton.SetActive(true);
			}
		}
		if (pointerEventData.pointerClick.gameObject.CompareTag("Maw"))
		{
			if (player == 1)
			{
				p1Name.text = "maw";
				p1Name.gameObject.SetActive(true);
				maw1.SetActive(true);
				CharacterSelectionP1 = "Maw";
				player = 2;
				p1Selected = true;
				Debug.Log("P1 Click");
			}

			else if (player == 2)
			{
				p2Name.text = "maw";
				p2Name.gameObject.SetActive(true);
				maw2.SetActive(true);
				CharacterSelectionP2 = "Maw";
				player = -1;
				p2Selected = true;
				Debug.Log("P2 Click");
				continueButton.SetActive(true);
			}
		}
		if (pointerEventData.pointerClick.gameObject.CompareTag("Warrok"))
		{
			if (player == 1)
			{
				p1Name.text = "warrok";
				p1Name.gameObject.SetActive(true);
				warrok1.SetActive(true);
				CharacterSelectionP1 = "Warrok";
				player = 2;
				p1Selected = true;
				Debug.Log("P1 Click");
			}

			else if (player == 2)
			{
				p2Name.text = "warrok";
				p2Name.gameObject.SetActive(true);
				warrok2.SetActive(true);
				CharacterSelectionP2 = "Warrok";
				player = -1;
				p2Selected = true;
				Debug.Log("P2 Click");
				continueButton.SetActive(true);
			}
		}
		if (pointerEventData.pointerClick.gameObject.CompareTag("Ely"))
		{
			if (player == 1)
			{
				p1Name.text = "ely";
				p1Name.gameObject.SetActive(true);
				ely1.SetActive(true);
				CharacterSelectionP1 = "Ely";
				player = 2;
				p1Selected = true;
				Debug.Log("P1 Click");
			}

			else if (player == 2)
			{
				p2Name.text = "ely";
				p2Name.gameObject.SetActive(true);
				ely2.SetActive(true);
				CharacterSelectionP2 = "Ely";
				player = -1;
				p2Selected = true;
				Debug.Log("P2 Click");
				continueButton.SetActive(true);
			}
		}
		if (pointerEventData.pointerClick.gameObject.CompareTag("Astra"))
		{
			if (player == 1)
			{
				p1Name.text = "astra";
				p1Name.gameObject.SetActive(true);
				astra1.SetActive(true);
				CharacterSelectionP1 = "Astra";
				player = 2;
				p1Selected = true;
				Debug.Log("P1 Click");
			}

			else if (player == 2)
			{
				p2Name.text = "astra";
				p2Name.gameObject.SetActive(true);
				astra2.SetActive(true);
				CharacterSelectionP2 = "Astra";
				player = -1;
				p2Selected = true;
				Debug.Log("P2 Click");
				continueButton.SetActive(true);
			}
		}
	}


	// Make text and character appear if mouse points to character
	public void OnPointerEnter(PointerEventData pointerEventData)
	{
		// Case Gills
		if (pointerEventData.pointerEnter.gameObject.CompareTag("Gills"))
		{
			if (player == 1)
			{
				p1Name.text = "gills";
				p1Name.gameObject.SetActive(true);
				gills1.SetActive(true);
				Debug.Log("P1 Hover");
			}


			else if (player == 2)
			{
				p2Name.text = "gills";
				p2Name.gameObject.SetActive(true);
				gills2.SetActive(true);
				Debug.Log("P2 Hover");
			}

		}

		// Case Morph
		if (pointerEventData.pointerEnter.gameObject.CompareTag("Morph"))
		{
			if (player == 1)
			{
				p1Name.text = "morph";
				p1Name.gameObject.SetActive(true);
				morph1.SetActive(true);
				Debug.Log("P1 Hover");
			}

			else if (player == 2)
			{
				p2Name.text = "morph";
				p2Name.gameObject.SetActive(true);
				morph2.SetActive(true);
				Debug.Log("P2 Hover");
			}

		}

		// Case Zlorp
		if (pointerEventData.pointerEnter.gameObject.CompareTag("Zlorp"))
		{
			if (player == 1)
			{
				p1Name.text = "zlorp";
				p1Name.gameObject.SetActive(true);
				zlorp1.SetActive(true);
				Debug.Log("P1 Hover");
			}

			else if (player == 2)
			{
				p2Name.text = "zlorp";
				p2Name.gameObject.SetActive(true);
				zlorp2.SetActive(true);
				Debug.Log("P2 Hover");
			}
		}

		// Case Maw
		if (pointerEventData.pointerEnter.gameObject.CompareTag("Maw"))
		{
			if (player == 1)
			{
				p1Name.text = "maw";
				p1Name.gameObject.SetActive(true);
				maw1.SetActive(true);
				Debug.Log("P1 Hover");
			}

			else if (player == 2)
			{
				p2Name.text = "maw";
				p2Name.gameObject.SetActive(true);
				maw2.SetActive(true);
				Debug.Log("P2 Hover");
			}
		}

		// Case Warrok
		if (pointerEventData.pointerEnter.gameObject.CompareTag("Warrok"))
		{
			if (player == 1)
			{
				p1Name.text = "warrok";
				p1Name.gameObject.SetActive(true);
				warrok1.SetActive(true);
				Debug.Log("P1 Hover");
			}

			else if (player == 2)
			{
				p2Name.text = "warrok";
				p2Name.gameObject.SetActive(true);
				warrok2.SetActive(true);
				Debug.Log("P2 Hover");
			}
		}

		// Case Ely
		if (pointerEventData.pointerEnter.gameObject.CompareTag("Ely"))
		{
			if (player == 1)
			{
				p1Name.text = "ely";
				p1Name.gameObject.SetActive(true);
				ely1.SetActive(true);
				Debug.Log("P1 Hover");
			}

			else if (player == 2)
			{
				p2Name.text = "ely";
				p2Name.gameObject.SetActive(true);
				ely2.SetActive(true);
				Debug.Log("P2 Hover");
			}
		}

		// Case Astra
		if (pointerEventData.pointerEnter.gameObject.CompareTag("Astra"))
		{
			if (player == 1)
			{
				p1Name.text = "astra";
				p1Name.gameObject.SetActive(true);
				astra1.SetActive(true);
				Debug.Log("P1 Hover");
			}

			else if (player == 2)
			{
				p2Name.text = "astra";
				p2Name.gameObject.SetActive(true);
				astra2.SetActive(true);
				Debug.Log("P2 Hover");
			}
		}

	}

	public void Reselect()
	{
		audio.clip = reset;
		audio.Play();

		player = 1;

		p1Selected = false;
		p2Selected = false;

		p1Name.gameObject.SetActive(false);
		p2Name.gameObject.SetActive(false);
		continueButton.SetActive(false);
		P1SetInactive();
		P2SetInactive();
	}

	// Make text disappear if mouse stops pointing at level one
	public void OnPointerExit(PointerEventData data)
	{

		if (player == 1 && p1Selected == false)
		{
			P1SetInactive();
			Debug.Log("P1 SetInactive");
		}
		if (player == 2 && p2Selected == false)
		{
			P2SetInactive();
			Debug.Log("P2 SetInactive");
		}
	}

	public void P1SetInactive()
	{
		p1Name.gameObject.SetActive(false);
		gills1.SetActive(false);
		morph1.SetActive(false);
		zlorp1.SetActive(false);
		maw1.SetActive(false);
		warrok1.SetActive(false);
		ely1.SetActive(false);
		astra1.SetActive(false);
	}
	public void P2SetInactive()
	{
		p2Name.gameObject.SetActive(false);
		gills2.SetActive(false);
		morph2.SetActive(false);
		zlorp2.SetActive(false);
		maw2.SetActive(false);
		warrok2.SetActive(false);
		ely2.SetActive(false);
		astra2.SetActive(false);
	}
}

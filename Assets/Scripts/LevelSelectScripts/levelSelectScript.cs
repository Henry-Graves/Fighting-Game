using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class levelSelectScript : MonoBehaviour, IPointerClickHandler
{
    public static int sLevel;
    private AudioSource audio;
	[SerializeField] private AudioClip select;

    // Start is called before the first frame update
    void Start()
    {
        sLevel = -1;
        audio = gameObject.GetComponent<AudioSource>();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        audio.clip = select;
		audio.Play();
        // Player selects level one
        if (pointerEventData.pointerClick.gameObject.CompareTag("LevelOne"))
        {
            //sLevel = pointerEventData.pointerClick.gameObject;
            sLevel = 1;
            MusicController.trackToPlay = 1;
            SceneManager.LoadScene(4);
        }

        // Player selects level two
        if (pointerEventData.pointerClick.gameObject.CompareTag("LevelTwo"))
        {
           // sLevel = pointerEventData.pointerClick.gameObject;
            sLevel = 2;
            MusicController.trackToPlay = 2;
            SceneManager.LoadScene(4);
        }
    }
}

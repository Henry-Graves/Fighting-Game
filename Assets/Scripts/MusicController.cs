using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private static AudioSource audio;
    [SerializeField] private static MusicController instance;
    [SerializeField] private AudioClip menu;       // 0
	[SerializeField] private AudioClip beach;      // 1
    [SerializeField] private AudioClip lighthouse; // 2
    public static int trackToPlay = 0;
    private static int trackPlaying = 0;

    // Play only one instance of the music
    void Start()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        audio = gameObject.GetComponent<AudioSource>();

        audio.clip = menu;
		audio.Play();

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (trackToPlay != trackPlaying)
        {
            if (trackToPlay == 0)
            {
                audio.Stop();
                audio.clip = menu;
		        audio.Play();
                trackPlaying = 0;
            }
            if (trackToPlay == 1)
            {
                audio.Stop();
                audio.clip = lighthouse;
		        audio.Play();
                trackPlaying = 1;
            }
            if (trackToPlay == 2)
            {
                audio.Stop();
                audio.clip = beach;
		        audio.Play();
                trackPlaying = 2;
            }
        }
    }
}

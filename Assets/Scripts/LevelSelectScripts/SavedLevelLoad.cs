using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedLevelLoad : MonoBehaviour
{
    public static GameObject level;
    [SerializeField] private GameObject backgroundOne;
    [SerializeField] private GameObject backgroundTwo;

    // Update is called once per frame
    void Update()
    {
        int myLevel = levelSelectScript.sLevel;

        if (myLevel == 1)
        {
            backgroundOne.SetActive(true);
            backgroundTwo.SetActive(false);
        }

        if (myLevel == 2)
        {
            backgroundOne.SetActive(false);
            backgroundTwo.SetActive(true);
        }
    }
}

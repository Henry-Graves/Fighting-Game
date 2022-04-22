using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelSelectTextTwo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject textTwo;

    // Start with no text
    void Start()
    {
        textTwo.SetActive(false);
    }

    // If the mouse points at level two, display the text
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (pointerEventData.pointerEnter.gameObject.CompareTag("LevelTwo"))
        {
            textTwo.SetActive(true);
        }
    }

    // Remove text if mouse no longer points at level two
    public void OnPointerExit(PointerEventData data)
    {
        textTwo.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelSelectTextOne : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject textOne;

    // Start screen without text
    void Start()
    {
        textOne.SetActive(false);
    }
    
    // Make text appear if mouse points to level one picture
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (pointerEventData.pointerEnter.gameObject.CompareTag("LevelOne"))
        {
            textOne.SetActive(true);
        }
    }

    // Make text disappear if mouse stops pointing at level one
    public void OnPointerExit(PointerEventData data)
    {
      textOne.SetActive(false);
    }
}

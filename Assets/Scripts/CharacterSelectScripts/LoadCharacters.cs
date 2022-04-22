using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Loads characters, their UI icon, and their correct health into the gameplay scene
public class LoadCharacters : MonoBehaviour
{
    // characters & icons disabled until enabled by this script. Uses variables from the character selection script (not sure which one)
    [SerializeField] private GameObject AstraP1;
    [SerializeField] private GameObject AstraP2;
    [SerializeField] private GameObject ElyP1;
    [SerializeField] private GameObject ElyP2;
    [SerializeField] private GameObject GillsP1;
    [SerializeField] private GameObject GillsP2;
    [SerializeField] private GameObject MawP1;
    [SerializeField] private GameObject MawP2;
    [SerializeField] private GameObject MorphP1;
    [SerializeField] private GameObject MorphP2;
    [SerializeField] private GameObject WarrokP1;
    [SerializeField] private GameObject WarrokP2;
    [SerializeField] private GameObject ZlorpP1;
    [SerializeField] private GameObject ZlorpP2;

    [SerializeField] private GameObject AstraP1ICON;
    [SerializeField] private GameObject AstraP2ICON;
    [SerializeField] private GameObject ElyP1ICON;
    [SerializeField] private GameObject ElyP2ICON;
    [SerializeField] private GameObject GillsP1ICON;
    [SerializeField] private GameObject GillsP2ICON;
    [SerializeField] private GameObject MawP1ICON;
    [SerializeField] private GameObject MawP2ICON;
    [SerializeField] private GameObject MorphP1ICON;
    [SerializeField] private GameObject MorphP2ICON;
    [SerializeField] private GameObject WarrokP1ICON;
    [SerializeField] private GameObject WarrokP2ICON;
    [SerializeField] private GameObject ZlorpP1ICON;
    [SerializeField] private GameObject ZlorpP2ICON;

    private string p1;
    private string p2;

    void Start()
    {
        p1 = HighlightedCharacter.CharacterSelectionP1;
        p2 = HighlightedCharacter.CharacterSelectionP2;

        // Load player 1
        if (p1 == "Astra")
        {
            AstraP1.SetActive(true);
            AstraP1ICON.SetActive(true);
            StatsManager.P1Health = 0.9f;
        }
        else if (p1 == "Ely")
        {
            ElyP1.SetActive(true);
            ElyP1ICON.SetActive(true);
            StatsManager.P1Health = 1.0f;
        }
        else if (p1 == "Gills")
        {
            GillsP1.SetActive(true);
            GillsP1ICON.SetActive(true);
            StatsManager.P1Health = 1.1f;
        }
        else if (p1 == "Maw")
        {
            MawP1.SetActive(true);
            MawP1ICON.SetActive(true);
            StatsManager.P1Health = 1.4f;
        }
        else if (p1 == "Morph")
        {
            MorphP1.SetActive(true);
            MorphP1ICON.SetActive(true);
            StatsManager.P1Health = 1.2f;
        }
        else if (p1 == "Warrok")
        {
            WarrokP1.SetActive(true);
            WarrokP1ICON.SetActive(true);
            StatsManager.P1Health = 1.3f;
        }
        else if (p1 == "Zlorp")
        {
            ZlorpP1.SetActive(true);
            ZlorpP1ICON.SetActive(true);
            StatsManager.P1Health = 0.8f;
        }


        // Load player 2
        if (p2 == "Astra")
        {
            AstraP2.SetActive(true);
            AstraP2ICON.SetActive(true);
            StatsManager.P2Health = 0.9f;
        }
        else if (p2 == "Ely")
        {
            ElyP2.SetActive(true);
            ElyP2ICON.SetActive(true);
            StatsManager.P2Health = 1.0f;

        }
        else if (p2 == "Gills")
        {
            GillsP2.SetActive(true);
            GillsP2ICON.SetActive(true);
            StatsManager.P2Health = 1.1f;
        }
        else if (p2 == "Maw")
        {
            MawP2.SetActive(true);
            MawP2ICON.SetActive(true);
            StatsManager.P2Health = 1.4f;
        }
        else if (p2 == "Morph")
        {
            MorphP2.SetActive(true);
            MorphP2ICON.SetActive(true);
            StatsManager.P2Health = 1.2f;
        }
        else if (p2 == "Warrok")
        {
            WarrokP2.SetActive(true);
            WarrokP2ICON.SetActive(true);
            StatsManager.P2Health = 1.3f;
        }
        else if (p2 == "Zlorp")
        {
            ZlorpP2.SetActive(true);
            ZlorpP2ICON.SetActive(true);
            StatsManager.P2Health = 0.8f;
        }
    }
}

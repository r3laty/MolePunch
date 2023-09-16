using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;
using UnityEngine;

public class ChoosingGamemode : MonoBehaviour
{
    [SerializeField] private UiController uiController;
    [Header("LevelsMode")]
    [SerializeField] private GameObject easyModeLvl;
    [SerializeField] private GameObject normalModeLvl;
    [SerializeField] private GameObject hardModeLvl;
    private void Update()
    {
        if (uiController.gamemodChosen) easyModeLvl.SetActive(true);

        if (uiController.easy)
        {
            easyModeLvl.SetActive(true); 
            Debug.Log("Easy mode");
        }

        if (uiController.normal)
        {
            normalModeLvl.SetActive(true); 
            Debug.Log("Normal mode");
        }
        if (uiController.hard)
        {
            hardModeLvl.SetActive(true); 
            Debug.Log("Hard mode");

        } 
    }
}

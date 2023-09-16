using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MolesCounter : MonoBehaviour
{
    [SerializeField] private MoleSpawner spawner;
    [Space]
    [SerializeField] private TextMeshProUGUI moleCountText;
    private void Update()
    {
        moleCountText.text = "Moles count: " + spawner._moleCount;
    }
}

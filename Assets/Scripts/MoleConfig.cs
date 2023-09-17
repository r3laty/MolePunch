using System;
using UnityEngine;

public class MoleConfig : MonoBehaviour
{
    public GameObject[] molePrefab = new GameObject[3]; // Модель крота
    public float[] health = new float[3]; // Здоровье крота
    public float[] spawnInterval = new float[3]; // Время между спаунами
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public int currentCarIndex;
    public GameObject[] carModels;
    public GameObject[] carNames;

    private void Start()
    {
        currentCarIndex = PlayerPrefs.GetInt("SelectedCar", 0);
        UpdateCurrentCar();
    }

    public void ChangeNext()
    {
        carModels[currentCarIndex].SetActive(false);
        carNames[currentCarIndex].SetActive(false);

        currentCarIndex = (currentCarIndex + 1) % carModels.Length;
        UpdateCurrentCar();
    }

    public void ChangePrevious()
    {
        carModels[currentCarIndex].SetActive(false);
        carNames[currentCarIndex].SetActive(false);

        currentCarIndex = (currentCarIndex - 1 + carModels.Length) % carModels.Length;
        UpdateCurrentCar();
    }

    private void UpdateCurrentCar()
    {
        carModels[currentCarIndex].SetActive(true);
        carNames[currentCarIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedCar", currentCarIndex);
    }
}

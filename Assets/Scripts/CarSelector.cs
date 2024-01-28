using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelector : MonoBehaviour
{
    public int selectedCarIndex;
    public GameObject[] cars;
    public GameObject carHolder;

    private GameObject currentCar;
    private EndlessCarCamera endlessCarCamera;

    private void Start()
    {
        selectedCarIndex = PlayerPrefs.GetInt("SelectedCar", 0);
        SpawnSelectedCar();
    }

    public void SelectCar(int index)
    {
        selectedCarIndex = index;
        PlayerPrefs.SetInt("SelectedCar", selectedCarIndex);
        SpawnSelectedCar();
    }

    private void SpawnSelectedCar()
    {
        if (currentCar != null)
        {
            Destroy(currentCar);
        }

        currentCar = Instantiate(cars[selectedCarIndex], carHolder.transform.position + new Vector3(0, 0, cars[selectedCarIndex].transform.position.z), carHolder.transform.rotation);
        currentCar.transform.parent = carHolder.transform;

        if (endlessCarCamera == null)
        {
            endlessCarCamera = FindObjectOfType<EndlessCarCamera>();
        }

        endlessCarCamera.SetTarget(currentCar.transform);
    }
}
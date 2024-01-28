using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public GameObject LoadingPanel;
    public RectTransform HandleRect;
    public Image BarFill;

    private void Start()
    {
        StartCoroutine(LoadSceneAsync(1));
    }
    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        operation.allowSceneActivation = false;

        LoadingPanel.SetActive(true);

        float progressValue = 0f;
        float loadSpeed = 0.3f;
        float targetProgress = 1f;

        RectTransform handleRectTransform = HandleRect.GetComponent<RectTransform>();
        Vector2 barMin = BarFill.GetComponent<RectTransform>().anchorMin;
        Vector2 barMax = BarFill.GetComponent<RectTransform>().anchorMax;

        while (!operation.isDone)
        {
            progressValue = Mathf.MoveTowards(progressValue, targetProgress, loadSpeed * Time.deltaTime);

            BarFill.fillAmount = progressValue;
            handleRectTransform.anchorMin = new Vector2(barMin.x + progressValue * (barMax.x - barMin.x), barMin.y);
            handleRectTransform.anchorMax = new Vector2(barMin.x + progressValue * (barMax.x - barMin.x), barMax.y);

            if (progressValue >= targetProgress)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
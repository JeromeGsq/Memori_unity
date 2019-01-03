using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Root.DesignPatterns;
using UnityEngine.UI;

public class SceneLoader : GlobalSingleton<SceneLoader> {

    public CanvasGroup LoadScreen;

    public Slider Slider;

    [HideInInspector()]
    public bool loading;

    private float loadProgress;

    public void LoadSceneAsync(string nextSceneToLoad_Name, Action run = null) {
        StartCoroutine(Show(nextSceneToLoad_Name, run));
    }

    private IEnumerator Show(string nextSceneToLoad_Name, Action run = null) {
        // flag to check from ext
        loading = true;

        if(LoadScreen != null)
        {
            LoadScreen.gameObject.SetActive(true);
            LoadScreen.DOFade(1, 0.2f);
        }

        yield return new WaitForSeconds(0.2f);

        if (LoadScreen != null)
        {
            LoadScreen.interactable = true;
        }

        //create async op (async loading)
        AsyncOperation async = SceneManager.LoadSceneAsync(nextSceneToLoad_Name);

        //as long as loading not complete, get the progress status (percentage)
        while(!async.isDone) {
            loadProgress = async.progress;
            Slider.value = loadProgress;
            yield return null;
        }

        if (LoadScreen != null)
        {
            LoadScreen.DOFade(0, 0.2f);
        }
        yield return new WaitForSeconds(0.2f);

        if(run != null) {
            run.Invoke();
        }

        if (LoadScreen != null)
        {
            LoadScreen.interactable = false;
            LoadScreen.gameObject.SetActive(false);
        }

        //flag back
        loading = false;
    }
}

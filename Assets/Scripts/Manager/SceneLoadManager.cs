using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [Header("场景")]
    public GameSceneSO firstLoadScene;

    [Header("信息接收")]
    public SceneLoadEventSO sceneLoadEvent;

    [Header("广播")]
    public VoidEventSO beforeUnLoadEvent;
    public VoidEventSO afterLoadEvent;

    [Header("场景切换")]
    private bool isLoading;
    private GameSceneSO currentScene;
    private GameSceneSO sceneToLoad;

    [Header("加载动画")]
    private bool fadeScreen;
    private float fadeTime;

    private void Awake()
    {
        if(firstLoadScene != null)
        {
            OnLoadScene(firstLoadScene, false, 0);
        }
    }

    private void OnEnable()
    {
        sceneLoadEvent.sceneLoadEvent += OnLoadScene;
    }

    private void OnDisable()
    {
        sceneLoadEvent.sceneLoadEvent -= OnLoadScene;
    }

    private void OnLoadScene(GameSceneSO sceneToLoad, bool fadeScreen, float fadeTime)
    {
        if(isLoading)
        {
            return;
        }
        isLoading = true;
        this.sceneToLoad = sceneToLoad;
        this.fadeScreen = fadeScreen;
        this.fadeTime = fadeTime;

        if(currentScene != null )
        {
            StartCoroutine(UnLoadCurrentScene());
        }
        else
        {
            LoadNewScene();
        }
    }

    private IEnumerator UnLoadCurrentScene()
    {
        if(fadeScreen)
        {
            //fade in
        }
        DataManager.instance.SaveSceneData();
        yield return new WaitForSeconds(fadeTime);
        yield return currentScene.sceneReference.UnLoadScene();
        LoadNewScene() ;
    }

    private void LoadNewScene()
    {
        var loadingOption = sceneToLoad.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true);
        loadingOption.Completed += OnLoadCompleted;
    }

    private void OnLoadCompleted(AsyncOperationHandle<SceneInstance> handle)
    {
        DataManager.instance.LoadSavedSceneData();
        currentScene = sceneToLoad;
        isLoading = false;
        afterLoadEvent.RaiseVoidEvent();
        if (fadeScreen)
        {
            //Fadeout
        }
        
        Scene sceneToActive = handle.Result.Scene;
        if (sceneToActive.IsValid())
        {
            SceneManager.SetActiveScene(sceneToActive);
        }
    }
}

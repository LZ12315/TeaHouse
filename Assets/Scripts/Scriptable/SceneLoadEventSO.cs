using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventSO/SceneLoadEventSO")]
public class SceneLoadEventSO : ScriptableObject
{
    public Action<GameSceneSO,bool,float> sceneLoadEvent;

    public void RaiseSceneLoadEvent(GameSceneSO sceneToLoad, bool fadeScreen, float fadeTime)
    {
        sceneLoadEvent?.Invoke(sceneToLoad,fadeScreen,fadeTime);
    }
}

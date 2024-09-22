using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    [Header("Êý¾Ý±£´æ")]
    public List<ISaveable> savedObjects = new List<ISaveable>();
    public SceneData NowSceneData;


    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void SaveSceneData()
    {
        if (savedObjects.Count <= 0)
            return;

        foreach(var saveables in savedObjects)
        {
            if(saveables.GetDefination().persistentType == PersistentType.ReadWrite)
                saveables.Save(NowSceneData);
        }
    }

    public void LoadSavedSceneData()
    {
        if (savedObjects.Count <= 0)
            return;

        foreach (var saveables in savedObjects)
        {
            if (saveables.GetDefination().persistentType == PersistentType.ReadWrite)
                saveables.Load(NowSceneData);
        }
    }

    public void SaveArchiveData()
    {

    }

    public void LoadSavedArchiveData()
    {

    }
}

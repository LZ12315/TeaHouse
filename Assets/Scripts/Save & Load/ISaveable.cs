using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Pipeline;
using UnityEngine;

public interface ISaveable
{
    public DataDefination GetDefination();

    public void RegisterSaveData() => DataManager.instance.savedObjects.Add(this);

    public void UnRegisterSaveData() => DataManager.instance.savedObjects.Remove(this);

    public void Save(SceneData data);

    public void Load(SceneData data);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "DataSO/SceneData")]
public class SceneData : ScriptableObject
{
    public ArchieveNumber sceneDataNumber;

    public Dictionary<string, string> stringDictionary = new Dictionary<string, string>();
    public Dictionary<string, bool> boolDictionary = new Dictionary<string, bool>();
}

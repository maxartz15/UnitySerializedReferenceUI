using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DatabaseObject", menuName = "DatabaseObject")]
public class DatabaseObject : ScriptableObject
{
    public List<Achievement> achievements = new List<Achievement>();
}

[System.Serializable]
public class Achievement
{
    public string name;
    public Sprite icon;
    [SerializeReference, SerializeReferenceButton]
    public IPlatform[] platformsSettings = null;
    public Unlock unlock;
}
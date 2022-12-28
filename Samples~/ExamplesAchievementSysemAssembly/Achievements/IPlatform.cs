using UnityEngine;

public interface IPlatform
{
    public string AchievementKey { get; }
}

[System.Serializable]
public class PC : IPlatform
{
    public string AchievementKey => achievementKey;
    [SerializeField]
    private string achievementKey;
}

[System.Serializable]
public class PS4 : IPlatform
{
    public string AchievementKey => achievementKey;
    [SerializeField]
    private string achievementKey;
}

[System.Serializable]
public class PS5 : IPlatform
{
    public string AchievementKey => achievementKey;
    [SerializeField]
    private string achievementKey;
}

[System.Serializable]
public class XBOX : IPlatform
{
    public string AchievementKey => achievementKey;
    [SerializeField]
    private string achievementKey;
}

[System.Serializable]
public class Quest : IPlatform
{
    public string AchievementKey => achievementKey;
    [SerializeField]
    private string achievementKey;
}

[System.Serializable]
public class SteamDeck : IPlatform
{
    public string AchievementKey => achievementKey;
    [SerializeField]
    private string achievementKey;
}
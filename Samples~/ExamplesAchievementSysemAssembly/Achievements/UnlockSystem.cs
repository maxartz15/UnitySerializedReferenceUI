using UnityEngine;

public class UnlockSystem : MonoBehaviour
{
    public DatabaseObject dataBase;

    public void OnFireBaseLoaded()
    {
        foreach (Achievement achievement in dataBase.achievements)
        {
            achievement.unlock.Initialize();
        }
    }
}
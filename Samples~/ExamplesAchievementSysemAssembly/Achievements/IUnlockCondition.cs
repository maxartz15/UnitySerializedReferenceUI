using System;
using UnityEngine;

public interface IUnlockCondition
{
    public event Action OnUnlockEvent;
    public bool IsUnlocked { get; }
    public float Progress { get; }
    public bool ResetOnFailedCheck { get; }
    //public UnlockResetMode { get; }
    //public IString ProgressString { get; }
    //public IString UnlockString { get; }
    public bool ShouldBePersistent { get; }
    public string Data { get; set; }

    public void Initialize();
    public void Reset();
}

// Maybe make an IUnlockReset interface to have expandable unlock reset modes.
// The interface could then return a bool if it should reset or not.
public enum UnlockResetMode
{
    NeverReset,
    ResetOnFailedCheck,
    ResetWithOthers,
}

public enum EnemyType
{
    Skeleton,
    Zombie,
    Dragon,
    Snek
}

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

[System.Serializable]
public class KillEnemies : IUnlockCondition
{
    // Serialized Parameters.
    [SerializeField]
    private EnemyType targetType = EnemyType.Skeleton;
    [SerializeField]
    private int targetKills = 100;

    // Implementation.
    public event Action OnUnlockEvent;
    public bool IsUnlocked => kills >= targetKills;
    public float Progress => kills / targetKills;
    public bool ResetOnFailedCheck => false;
    public bool ShouldBePersistent => true;
    public string Data { get => kills.ToString(); set { kills = int.Parse(value); } }

    private int kills = 0;

    public void Initialize()
    {
        // Start listening to some events to collect data.
    }

    public void Reset()
    {
        kills = 0;
    }
}

[System.Serializable]
public class LevelDifficulty : IUnlockCondition
{
    [SerializeField]
    private Difficulty difficulty = Difficulty.Easy;

    public event Action OnUnlockEvent;
    public bool IsUnlocked => false;
    public float Progress => 0;
    public bool ResetOnFailedCheck => true;
    public bool ShouldBePersistent => false;
    public string Data { get => ""; set { } }

    public void Initialize()
    {
        // Start listening to some events to collect data.
    }

    public void Reset()
    {
    }
}

[System.Serializable]
public class Accuracy : IUnlockCondition
{
    [SerializeField, Range(0, 1)]
    private float targetAccuracy = 0.5f;

    public event Action OnUnlockEvent;
    public bool IsUnlocked => false;
    public float Progress => 0;
    public bool ResetOnFailedCheck => true;
    public bool ShouldBePersistent => false;
    public string Data { get => ""; set { } }

    public void Initialize()
    {
        // Start listening to some events to collect data.
    }

    public void Reset()
    {
    }
}

[System.Serializable]
public class OwnDLC : IUnlockCondition
{
    [SerializeField]
    private string dlcName = "";

    public event Action OnUnlockEvent;
    public bool IsUnlocked => false;
    public float Progress => 0;
    public bool ResetOnFailedCheck => true;
    public bool ShouldBePersistent => false;
    public string Data { get => ""; set { } }

    public void Initialize()
    {
        // Start listening to some events to collect data.
    }

    public void Reset()
    {
    }
}
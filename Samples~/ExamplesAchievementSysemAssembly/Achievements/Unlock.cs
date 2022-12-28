using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Unlock : IDisposable
{
    public event Action OnUnlockEvent;

    [SerializeReference, SerializeReferenceButton] private List<IUnlockTrigger> unlockTriggers = new List<IUnlockTrigger>();
    [SerializeReference, SerializeReferenceButton] private List<IUnlockCondition> unlockConditions = new List<IUnlockCondition>();

    public void Initialize()
	{
		foreach (IUnlockCondition condition in unlockConditions)
		{
            condition.Initialize();
		}

		foreach (IUnlockTrigger trigger in unlockTriggers)
		{
            trigger.OnTriggerEvent += HandleOnTriggerEvent;
            trigger.Initialize();
		}
	}

    public void Dispose()
    {
        foreach (IUnlockTrigger trigger in unlockTriggers)
        {
            trigger.OnTriggerEvent -= HandleOnTriggerEvent;
        }
    }

    // Format data in some way to store compactly and be re-storable after load.
    public bool Save(out string data)
	{
        data = "";

        bool shouldSave = false;
        foreach (IUnlockCondition condition in unlockConditions)
        {
			if (condition.ShouldBePersistent)
			{
                data += condition.Data;
                shouldSave = true;
            }
        }

        return shouldSave;
	}

    // Unpack data and load into conditions.
    public void Load(string data)
	{
        foreach (IUnlockCondition condition in unlockConditions)
        {
            if (condition.ShouldBePersistent)
            {
                condition.Data = data;
            }
        }
    }

    public bool IsUnlocked()
    {
        foreach (IUnlockCondition condition in unlockConditions)
        {
            if (!condition.IsUnlocked)
            {
                return false;
            }
        }

        return true;
    }

    private void HandleOnTriggerEvent()
	{
        bool shouldReset = false;

        foreach (IUnlockCondition condition in unlockConditions)
        {
            if (!condition.IsUnlocked && condition.ResetOnFailedCheck)
            {
                shouldReset = true;
                break;
            }
        }

        if (shouldReset)
		{
            foreach (IUnlockCondition condition in unlockConditions)
            {
                condition.Reset();
            }
        }
		else if (IsUnlocked())
		{
            OnUnlockEvent?.Invoke();
        }
    }
}
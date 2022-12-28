using System;

public interface IUnlockTrigger
{
    public event Action OnTriggerEvent;
    public void Initialize();
}

[System.Serializable]
public class LevelCompleteTrigger : IUnlockTrigger
{
	public event Action OnTriggerEvent;

	public void Initialize()
	{
		// Subscribe to on level complete event.
		// OnTriggerEvent?.Invoke();
	}
}

[System.Serializable]
public class EnemyKilledTrigger : IUnlockTrigger
{
	public event Action OnTriggerEvent;

	public void Initialize()
	{
		// Subscribe to on enemy killed event.
		// OnTriggerEvent?.Invoke();
	}
}
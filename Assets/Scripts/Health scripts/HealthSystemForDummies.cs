using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystemForDummies : MonoBehaviour
{
    public bool IsAlive;
    public float CurrentHealth = 1000;
    public float MaximumHealth = 1000;

    public bool HasAnimationWhenHealthChanges = true;
    public float AnimationDuration = 0.1f;

    public float CurrentHealthPercentage
    {
        get
        {
            return (CurrentHealth / MaximumHealth) * 100;
        }
    }

    public OnCurrentHealthChanged OnCurrentHealthChanged;
    public OnIsAliveChanged OnIsAliveChanged;
    public OnMaximumHealthChanged OnMaximumHealthChanged;

    public GameObject HealthBarPrefabToSpawn;

    public void AddToMaximumHealth(float value)
    {
        float cachedMaximumHealth = MaximumHealth;

        MaximumHealth += value;
        OnMaximumHealthChanged.Invoke(new MaximumHealth(cachedMaximumHealth, MaximumHealth));
    }

    public void DecreaseCurrentHealthBy(float value)
    {
        CurrentHealth -= value;
        float cachedCurrentHealth = CurrentHealth;

        if (CurrentHealth <= 0)
        {
            IsAlive = false;
            OnIsAliveChanged.Invoke(IsAlive);
            Destroy(gameObject);
        }

        OnCurrentHealthChanged.Invoke(new CurrentHealth(cachedCurrentHealth, CurrentHealth, CurrentHealthPercentage));
    }

    public void PlayerDead()
    {
        float previousHealth = CurrentHealth;

        CurrentHealth = 0;
        IsAlive = false;

        OnIsAliveChanged.Invoke(IsAlive);
        OnCurrentHealthChanged.Invoke(new CurrentHealth(previousHealth, CurrentHealth, CurrentHealthPercentage));

        SceneManager.LoadScene(3);
    }
}
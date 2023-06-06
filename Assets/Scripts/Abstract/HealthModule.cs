using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModule : MonoBehaviour
{
    private float health = 0;
    [HideInInspector] public float Health { get => health; }

    public delegate void MaxHealthRestored();
    public event MaxHealthRestored OnMaxHealthRestored;

    public delegate void Died();
    public event Died OnDied;

    public delegate void HealthChanged(float health);
    public event HealthChanged OnHealthChanged;

    /// <summary>
    /// �� ��������� ����������� 100 ��������.
    /// </summary>
    public float MaxHealth = 100;

    /// <summary>
    /// �� ��������� ���������� 100 ��������.
    /// </summary>
    public float MinHealth = 0;

    private void Start()
    {
        health = MaxHealth;
        OnHealthChanged?.Invoke(health);
    }

    /// <summary>
    /// �������� ��� ��������� ��������.
    /// </summary>
    /// <param name="health">���������� ����������� ��� ����������� ��������</param>
    public void RecountHealth(float health)
    {
        if ((this.health + health) <= MaxHealth && (this.health + health) > 0)
        {
            this.health += health;
            OnHealthChanged?.Invoke(this.health);
        }
        else
        {
            this.health = 0;
            OnHealthChanged?.Invoke(0);
        }

        if (this.health <= MinHealth)
            OnDied?.Invoke();
        if (this.health == MaxHealth)
            OnMaxHealthRestored?.Invoke();  
    }
}

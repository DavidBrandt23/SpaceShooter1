using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHP;
    private float currentHP;
    private bool invincible;
   // [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip hurtClip;
    public bool Dead { get; private set; }

    public delegate void OnDeathDelegate();
    OnDeathDelegate onDeathCallback;

    public delegate void OnHurtDelegate();
    OnHurtDelegate onHurtCallback;

    public void SetDeathCallback(OnDeathDelegate del)
    {
        onDeathCallback = del;
    }

    public void SetHurtCallback(OnHurtDelegate del)
    {
        onHurtCallback = del;
    }

    public bool Invincible
    {
        get { return invincible; }
        set { invincible = value; }
    }
    public float CurrentHP
    {
        get { return currentHP; }
    }

    public int getWholeCurrentHP()
    {
        return (int)(currentHP + 0.5f);
    }

    public float MaxHP
    {
        get { return maxHP; }
    }

    // Use this for initialization
    void Start()
    {
        currentHP = maxHP;
        Dead = false;
    }
    
    public void hurt(float damageAmount)
    {
        if (invincible)
        {
            return;
        }

        if (!Dead)
        {
            playHurtSound();
            if (onHurtCallback != null)
            {
                onHurtCallback();
            }
            currentHP -= damageAmount;
            if (currentHP <= 0)
            {
                die();
            }
        }
    }

    private void die()
    {
        Dead = true;
        if (onDeathCallback != null)
        {
            onDeathCallback();
        }
    }

    private void playHurtSound()
    {
        AudioSource audioSource = this.GetComponent<AudioSource>();
        audioSource.PlayOneShot(hurtClip);
    }
}

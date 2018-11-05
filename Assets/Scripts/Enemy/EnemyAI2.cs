using UnityEngine;
using System.Collections;
using System;

public class EnemyAI2 : EnemyAI
{
    public Transform shootOrigin;
    public GameObject projectilePrefab;
    public AudioClip shootNoise;
    public float speed;

    void Start()
    {
    }
    
    protected override IEnumerator MainAI()
    {
        IEnumerator moveRight = moveDir(1, 0, speed);
        IEnumerator moveDown = moveDir(0, -1, speed);
        StartCoroutine(moveDown);
        yield return new WaitForSeconds(0.3f);
        StopCoroutine(moveDown);
        StartCoroutine(moveRight);
        StartCoroutine(shoot());
    }
    
    private IEnumerator shoot()
    {
        while (true)
        {
            playShootNoise();
            GameObject projectile = Instantiate(projectilePrefab, shootOrigin.position, shootOrigin.rotation);
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void playShootNoise()
    {
        AudioSource audioSource = this.GetComponent<AudioSource>();
        audioSource.PlayOneShot(shootNoise);
    }
}

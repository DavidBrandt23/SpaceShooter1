using UnityEngine;
using System.Collections;

public class EnemyAI1 : EnemyAI
{
    public Transform shootOrigin;
    public GameObject projectilePrefab;
    public AudioClip shootNoise;

    void Start()
    {
    }
    
    protected override IEnumerator MainAI()
    {
        StartCoroutine(shoot());
        IEnumerator moveDownLeft = moveDir(-1, -1);
        IEnumerator moveDownRight = moveDir(1, -1);
        IEnumerator moveUpRight = moveDir(1, 1);
        IEnumerator moveUpLeft = moveDir(-1, 1);
        IEnumerator moveDown = moveDir(0, -1);
        StartCoroutine(moveDown);
        yield return new WaitForSeconds(2.0f);
        StopCoroutine(moveDown);
        while (true)
        {
            float sideLength = 1.5f;
            yield return StartCoroutine(doActionForTime(moveDownRight, sideLength));
            yield return StartCoroutine(doActionForTime(moveDownLeft, sideLength));
            yield return StartCoroutine(doActionForTime(moveUpLeft, sideLength));
            yield return StartCoroutine(doActionForTime(moveUpRight, sideLength));
        }
    }

    private IEnumerator shoot()
    {
        while (true)
        {
            GameObject projectile = Instantiate(projectilePrefab, shootOrigin.position, shootOrigin.rotation);
            playShootNoise();
            yield return new WaitForSeconds(2);
        }
    }
    private void playShootNoise()
    {
        AudioSource audioSource = this.GetComponent<AudioSource>();
        audioSource.PlayOneShot(shootNoise);
    }
}

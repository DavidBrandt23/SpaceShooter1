using UnityEngine;
using System.Collections;

public abstract class PlayerWeapon : MonoBehaviour
{

    public GameObject projectilePrefab;
    //public AudioSource shootSource;
    public AudioClip shootNoise;
    [SerializeField] private string displayName;

    public string DisplayName {
        get
        {
            return displayName;
        }
        private set
        {
            displayName = value;
        }
    }
    public float dsfsf { get; set; }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playShootNoise()
    {
        AudioSource audioSource = this.GetComponent<AudioSource>();
        audioSource.PlayOneShot(shootNoise);
    }

    public abstract void shootPressed();
    public virtual void shootNotPressed() { }
    public virtual void stopWeapon() { }
}

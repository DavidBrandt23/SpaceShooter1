using UnityEngine;
using System.Collections;

public class Enemy : Entity
{
    [SerializeField] private EnemyAI AI_Script;
    private const string screenRegionName = "screenRegion";
    [SerializeField] private GameObject explosionPrefab;
    private bool onScreen;
    public bool OnScreen
    {
        get
        {
            return onScreen;
        }
        private set
        {
            onScreen = value;
        }
    }
    private bool activated;
    public bool Activated
    {
        get
        {
            return activated;
        }
        private set
        {
            activated = value;
        }
    }
    // Use this for initialization
    void Start()
    {
        onStart();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static bool objectIsEnemy(GameObject obj)
    {
        return obj.tag.Equals("Enemy");
    }

    protected override void onDeath()
    {
        Transform transform = this.GetComponent<Transform>();
        this.GetComponent<Animator>().SetTrigger("Death");
        //GameObject projectile = Instantiate(explosionPrefab, transform.position, transform.rotation);
       // Destroy(this.gameObject);
    }

    private void onDeathAnimFinished()
    {
       Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        if (!Activated)
        {
            AI_Script.preActivateBehavior();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals(screenRegionName))
        {
            Activated = true;
            AI_Script.startAI();
            OnScreen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals(screenRegionName))
        {
            OnScreen = true;
            silenceSelf();
        }
    }

    private void silenceSelf()
    {
        AudioSource audioSource = this.GetComponent<AudioSource>();
        audioSource.mute = true;
    }
}

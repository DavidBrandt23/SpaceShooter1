using UnityEngine;
using System.Collections;

public class SuperLaserWeapon : PeriodicWeapon
{

    public Transform shootOrigin;
    private GameObject laser;
    private GameObject chargeObject;
    public float damage;
    [SerializeField] private float startupTime;
    private float startupTimer;
    [SerializeField] private float speedWhileShooting;
    [SerializeField] private AudioClip chargeNoise;
    [SerializeField] private GameObject sparkPrefab;
    [SerializeField] private GameObject chargePrefab;
    private const float pixelsToUnits = 100.0f;
    private const float laserSpriteHeight = 1000; //ToDo: don't hardcode this
    private const float laserSpriteWidth = 15;     //ToDo: don't hardcode this
    private int flipCounter;

    private Player player;

    public void Start()
    {
        player = this.GetComponent<Player>();
    }
    public override void shootPressed()
    {
        if(startupTimer == 0)
        {
            AudioSource audioSource = this.GetComponent<AudioSource>();
            audioSource.PlayOneShot(chargeNoise);
            chargeObject = Instantiate(chargePrefab, shootOrigin.position, new Quaternion(), player.GetComponent<Transform>());
        }

        startupTimer += Time.fixedDeltaTime;
        if(startupTimer < startupTime)
        {
            return;
        }

        if (chargeObject)
        {
            Destroy(chargeObject);
            chargeObject = null;
        }

        player.setCurrentSpeed(speedWhileShooting);
        
        if (offCooldown())
        {
            resetCooldown();
            playShootNoise();

            Vector2 boxSize = new Vector2(laserSpriteWidth / pixelsToUnits, 200.0f);
            Vector2 boxCenter = new Vector2(shootOrigin.position.x, shootOrigin.position.y + boxSize.y / 2);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(boxCenter, boxSize, 0);

            float closestY = 9999.0f;
            GameObject hitEnemy = null;
            foreach(Collider2D col in colliders)
            {
                GameObject ob = col.gameObject;
                if (Enemy.objectIsEnemy(ob))
                {
                    float obY = ob.transform.position.y;
                    bool enemyActive = ob.GetComponent<Enemy>().Activated;
                    if(enemyActive && (obY < closestY))
                    {
                        closestY = obY;
                        hitEnemy = ob;
                    }
                }
            }

            if(hitEnemy != null)
            {
                hitEnemy.GetComponent<Health>().hurt(damage);
            }
            

            if (laser == null)
            {
                laser = Instantiate(projectilePrefab, new Vector3(0,0,0), shootOrigin.rotation);
                flipCounter = 0;
            }
            flipCounter += 1;
            bool currentFlip = laser.GetComponent<SpriteRenderer>().flipX;
            if (flipCounter % (5) == 0)
            {
                laser.GetComponent<SpriteRenderer>().flipX = !currentFlip;
            }

            SpriteRenderer laserSpriteRenderer = laser.GetComponent<SpriteRenderer>();
            Sprite baseLaserSprite = laserSpriteRenderer.sprite;
            Texture2D baseTexture = baseLaserSprite.texture;
            Rect baseTextureRect = baseLaserSprite.textureRect;
            float laserHeightUnits;
            if(hitEnemy != null)
            {
                float hitEnemyPosition = hitEnemy.GetComponent<Transform>().position.y;
                float hitEnemyBoxOffset = hitEnemy.GetComponent<BoxCollider2D>().offset.y;
                float hitEnemyBoxHeight = hitEnemy.GetComponent<BoxCollider2D>().size.y;
                float hitEnemyBottomY = (hitEnemyPosition - hitEnemyBoxOffset - (hitEnemyBoxHeight / 2));
                laserHeightUnits = hitEnemyBottomY - shootOrigin.position.y;
                createSpark(new Vector2(laser.GetComponent<Transform>().position.x, hitEnemyBottomY));
            }
            else
            {
                laserHeightUnits = laserSpriteHeight / pixelsToUnits;
            }
            
            Vector3 spawnPos = new Vector3(shootOrigin.position.x, shootOrigin.position.y + (laserHeightUnits / 2.0f), shootOrigin.position.z);
            laser.GetComponent<Transform>().position = spawnPos;

            Rect cropRect = new Rect();
            cropRect.x = 0;
            cropRect.y = 0;
            cropRect.width = baseTextureRect.width;
            cropRect.height = laserHeightUnits * pixelsToUnits;
            Sprite croppedSprite = Sprite.Create(baseTexture, cropRect, new Vector2(0.5f, 0.5f));
            laserSpriteRenderer.sprite = croppedSprite;
        }
    }

    public override void shootNotPressed()
    {
        stopWeapon();
    }

    private void createSpark(Vector2 hitPosition)
    {
        float horizontalSpread = laserSpriteWidth / 2 / pixelsToUnits;
        float verticalSpread = 0.05f;
        Vector2 sparkPosition = new Vector2();
        sparkPosition.x = hitPosition.x + Random.Range(-1 * horizontalSpread, horizontalSpread);
        sparkPosition.y = hitPosition.y + Random.Range(-1 * verticalSpread, verticalSpread);
        Instantiate(sparkPrefab, sparkPosition, new Quaternion());
    }

    public override void stopWeapon()
    {
        if (laser != null)
        {
            Destroy(laser);
        }
        if (chargeObject != null)
        {
            Destroy(chargeObject);
        }
        laser = null;
        chargeObject = null;
        startupTimer = 0;
        player.resetSpeed();
    }

    void FixedUpdate()
    {
        incrementCooldown();
    }
}

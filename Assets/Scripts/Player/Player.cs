using UnityEngine;
using System.Collections;
using System;

public class Player : Entity
{
    private PlayerWeaponControl playerWeapons;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float speed;
    [SerializeField] private GameObject screenRegion;
    private float currentSpeed;
    private Transform myTransform;
    private CircleCollider2D myCollider;
    public void Start()
    {
        onStart();
        resetSpeed();
        playerWeapons = this.GetComponent<PlayerWeaponControl>();
        myTransform = this.GetComponent<Transform>();
        myCollider = this.GetComponent<CircleCollider2D>();
        Screen.SetResolution(400,800,false);
    }

    protected override void onDeath()
    {
        playerWeapons.stopCurrentWeapon();
        GameObject projectile = Instantiate(explosionPrefab, myTransform.position, myTransform.rotation);
        Destroy(this.gameObject);
    }

    public void setCurrentSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }
    public void resetSpeed()
    {
        currentSpeed = speed;
    }

    public void Move(int xDirection, int yDirection, bool shootPressed)
    {

        float speedMod = currentSpeed;
        if(xDirection != 0 && yDirection != 0)
        {
            speedMod = 1/((float)Math.Sqrt(2)) * currentSpeed;
        }
        Vector2 translateVector = new Vector2(xDirection * speedMod, yDirection * speedMod);

        myTransform.Translate(translateVector);
        keepInRegion(screenRegion);

        if (shootPressed)
        {
            playerWeapons.shootPressed();
        }
        else
        {
            playerWeapons.shootNotPressed();
        }
    }

    public void SetPosition(Vector2 pos)
    {
        myTransform.position = pos;
        keepInRegion(screenRegion);
    }

    private void keepInRegion(GameObject region)
    {
        float xMin, xMax, yMin, yMax;
        Vector3 regionPosition = region.GetComponent<Transform>().position;
        Vector2 regionColliderSize = region.GetComponent<BoxCollider2D>().size;
        Vector2 regionColliderOffset = region.GetComponent<BoxCollider2D>().offset;
        Vector2 myColliderSize = new Vector2(myCollider.radius, myCollider.radius);
        Vector2 myColliderOffset = myCollider.offset;
        xMin = regionPosition.x - (regionColliderSize.x / 2) + (myColliderSize.x / 2);
        xMax = regionPosition.x + (regionColliderSize.x / 2) - (myColliderSize.x / 2);
        yMin = regionPosition.y - (regionColliderSize.y / 2) + (myColliderSize.y / 2);
        yMax = regionPosition.y + (regionColliderSize.y / 2) - (myColliderSize.y / 2);
        myTransform.position = new Vector3
        (
            Mathf.Clamp(myTransform.position.x, xMin, xMax),
            Mathf.Clamp(myTransform.position.y, yMin, yMax),
            0.0f
        );
    }
}

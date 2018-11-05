using UnityEngine;
using System.Collections;

//depends on also having a MovementScripts component
public abstract class EnemyAI : MonoBehaviour
{
    void Start()
    {

    }

    public virtual void preActivateBehavior()
    {
        float speed = 0.05f;
        Vector2 direction = new Vector2(0, -1);
        Transform transform = this.GetComponent<Transform>();
        transform.Translate(direction.normalized * speed);
    }

    public void startAI()
    {
        StartCoroutine(MainAI());
    }


    protected IEnumerator doActionForTime(IEnumerator action, float time)
    {
        StartCoroutine(action);
        yield return new WaitForSeconds(time);
        StopCoroutine(action);
    }

    protected IEnumerator moveDir(int x, int y, float speed = 0.01f)
    {
        while (true)
        {
            if (ControllerScript.paused)
            {
                yield return null;
            }
            else
            {
                MovementScripts movementScripts = this.GetComponent<MovementScripts>();
                movementScripts.MoveInDirection(new Vector2(x, y), speed);
                yield return null;
            }
        }
    }

    /// <summary>
    /// This function is started as a Coroutine when Enemy is activated
    /// </summary>
    /// <returns></returns>
    protected abstract IEnumerator MainAI();
}

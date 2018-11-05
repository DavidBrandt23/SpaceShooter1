using UnityEngine;

public class DestroyOffscreen : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.name.Equals("screenRegion"))
        {
            Destroy(this.gameObject);
        }
    }
}
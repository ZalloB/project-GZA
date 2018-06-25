using UnityEngine;

public class DestroyController : MonoBehaviour
{

    public float destroyTime = 0.3f;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }

}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public Rigidbody HeadBody;

    private void Awake()
    {
        Instance = this;
    }
}
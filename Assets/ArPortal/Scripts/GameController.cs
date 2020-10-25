using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public ARSessionOrigin Origin;
    public ARPlaneManager PlaneManager;
    public ARSession Session;
    public ARInputManager InputManager;
    public ARCameraManager Camera;
    public ARCameraBackground Background;
    
    public MeshRenderer PortalRend;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

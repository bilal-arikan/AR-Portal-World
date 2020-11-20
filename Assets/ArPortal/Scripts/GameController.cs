using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public ARSessionOrigin Origin;
    public ARPlaneManager PlaneManager;
    public ARSession Session;
    public ARInputManager InputManager;
    public ARCameraManager Camera;
    public ARCameraBackground Background;
    public ARPlaneManager Plane;
    [Space]
    public ARPlacementInteractable aRPlacementInteractable;
    public ARGestureInteractor aRGestureInteractor;
    [Space]
    public GameObject PortalPrefab;
    public GameObject BoxPrefab;
    [Space]
    public Toggle PlacePortalBtn;
    public Toggle PlaceBoxBtn;
    public Toggle DeleteSelctdBtn;

    // Start is called before the first frame update 
    void Start()
    {
        Instance = this;
        aRPlacementInteractable.gameObject.SetActive(false);

        aRPlacementInteractable.onObjectPlaced.AddListener((arP, obj) =>
        {
            Debug.Log(obj.name + " " + arP.name);
        });
        PlacePortalBtn.onValueChanged.AddListener((v) =>
        {
            if (v)
            {
                aRPlacementInteractable.gameObject.SetActive(true);
                aRPlacementInteractable.placementPrefab = PortalPrefab;
                Debug.Log("Click Portal");
            }
        });
        PlaceBoxBtn.onValueChanged.AddListener((v) =>
        {
            if (v)
            {
                aRPlacementInteractable.gameObject.SetActive(true);
                aRPlacementInteractable.placementPrefab = BoxPrefab;
                Debug.Log("Click Box");
            }
        });
        DeleteSelctdBtn.onValueChanged.AddListener((v) =>
        {
            if (v)
            {
                aRPlacementInteractable.gameObject.SetActive(false);
                Debug.Log("Click Del");
            }
        });
    }
}

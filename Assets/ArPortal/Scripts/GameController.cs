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
    [Space]
    public ARPlacementInteractable aRPlacementInteractable;
    public ARGestureInteractor aRGestureInteractor;
    [Space]
    public GameObject PortalPrefab;
    public GameObject BoxPrefab;
    public MeshRenderer PortalRend;
    [Space]
    public Button PlacePortalBtn;
    public Button PlaceBoxBtn;
    public Button DeleteSelctdBtn;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        aRPlacementInteractable.onObjectPlaced.AddListener((arP, obj) =>
        {
            Debug.Log(obj.name + " " + arP.name);
        });
        PlacePortalBtn.onClick.AddListener(() =>
        {
            aRPlacementInteractable.placementPrefab = PortalPrefab;
            Debug.Log("Click Portal");
        });
        PlaceBoxBtn.onClick.AddListener(() =>
        {
            aRPlacementInteractable.placementPrefab = BoxPrefab;
            Debug.Log("Click Box");
        });
        DeleteSelctdBtn.onClick.AddListener(() =>
        {
            Debug.Log("Click Del");

        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}

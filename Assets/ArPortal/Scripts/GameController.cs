using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public GameObject[] ItemPrefabs;
    [Space]
    public Button AboutBtn;
    public Toggle PlacePortalBtn;
    public Toggle EmptyPlacerBtn;
    public Button ClearScenedBtn;
    public RectTransform PlaceItemBtns;

    private float nextSpawnItemTime = 5;

    // Start is called before the first frame update 
    void Start()
    {
        Instance = this;
        aRPlacementInteractable.gameObject.SetActive(false);

        aRPlacementInteractable.onObjectPlaced.AddListener((arP, obj) =>
        {
            Debug.Log(obj.name + " " + arP.name);
        });
        AboutBtn.onClick.AddListener(() =>
        {
            Application.OpenURL("https://github.com/bilal-arikan/AR-Portal-World");
        });
        PlacePortalBtn.onValueChanged.AddListener((v) =>
        {
            if (v)
            {
                aRPlacementInteractable.placementPrefab = PortalPrefab;
            }
        });
        EmptyPlacerBtn.onValueChanged.AddListener((v) =>
        {
            if (v)
            {
                aRPlacementInteractable.placementPrefab = null;
            }
        });
        ClearScenedBtn.onClick.AddListener(() =>
        {
            var objs = FindObjectsOfType<SelectableObject>().ToArray();
            foreach (var obj in objs)
            {
                DestroyImmediate(obj.gameObject);
            }
        });
        var btns = PlaceItemBtns.GetComponentsInChildren<Toggle>();
        foreach (var btn in btns)
        {
            btn.onValueChanged.AddListener(v =>
            {
                if (v)
                {
                    aRPlacementInteractable.placementPrefab = ItemPrefabs[btn.transform.GetSiblingIndex()];
                }
            });
        }
        PlaneManager.planesChanged += OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs pm)
    {
        foreach (var plane in pm.added)
        {
            Debug.Log("Added " + plane.name);
        }
        foreach (var plane in pm.added)
        {
            Debug.Log("Updated " + plane.name);
        }
        foreach (var plane in pm.added)
        {
            Debug.Log("Removed " + plane.name);
        }
    }

    private void Update()
    {
        if (Time.time > nextSpawnItemTime)
        {
            SpawnRandomItem();
            nextSpawnItemTime = Time.time + UnityEngine.Random.Range(2f, 4f);
        }
    }

    void SpawnRandomItem()
    {
        var itemPrefab = ItemPrefabs[UnityEngine.Random.Range(0, ItemPrefabs.Length - 1)];
        // var position = 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableObject : MonoBehaviour
{
    public GameObject TraceObj;
    public Button ReCenterBtn;
    public Button DublicateBtn;
    public Button DeleteBtn;

    // Start is called before the first frame update
    void Start()
    {
        ReCenterBtn.onClick.AddListener(() => {
            TraceObj.SetActive(!TraceObj.activeSelf);
        });
        DublicateBtn.onClick.AddListener(() => {

        });
        DeleteBtn.onClick.AddListener(() => {
            DestroyImmediate(gameObject);
        });
    }
}

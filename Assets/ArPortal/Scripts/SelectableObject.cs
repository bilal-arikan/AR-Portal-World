using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class SelectableObject : MonoBehaviour
{
    public GameObject TraceObj;
    public GameObject MeshObject;

    private CanvasAnnotations canvasAnnotations;
    private ARSelectionInteractable aRSelection;
    private ARAnnotationInteractable aRAnnotation;

    // Start is called before the first frame update
    void Start()
    {
        canvasAnnotations = GetComponentInChildren<CanvasAnnotations>(true);
        aRSelection = GetComponent<ARSelectionInteractable>();
        aRAnnotation = GetComponent<ARAnnotationInteractable>();
        aRSelection.onSelectEntered.AddListener((xrc) =>
        {
            Debug.Log("Selected " + name, this);
            foreach (var ann in aRAnnotation.annotations)
            {
                ann.annotationVisualization.SetActive(true);
            }
        });
        aRSelection.onSelectExited.AddListener((xrc) =>
        {
            Debug.Log("UnSelected " + name, this);
            foreach (var ann in aRAnnotation.annotations)
            {
                ann.annotationVisualization.SetActive(false);
            }
        });

        canvasAnnotations.ReCenterBtn.onClick.AddListener(() =>
        {
            TraceObj.SetActive(!TraceObj.activeInHierarchy);
        });
        canvasAnnotations.DublicateBtn.onClick.AddListener(() =>
        {

        });
        canvasAnnotations.DeleteBtn.onClick.AddListener(() =>
        {
            DestroyImmediate(gameObject);
        });
    }

    private void OnEnable()
    {
        var rends = MeshObject?.GetComponentsInChildren<MeshRenderer>() ?? new MeshRenderer[0];
        foreach (var rend in rends)
        {
            foreach (var mat in rend.materials)
            {
                if (mat.shader.name == "Stencil/Read")
                {
                    mat.SetInt("_StencilRef", 3);
                }
            }
        }
    }
}

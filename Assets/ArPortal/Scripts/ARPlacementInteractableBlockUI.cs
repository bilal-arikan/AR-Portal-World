using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class ARPlacementInteractableBlockUI : ARPlacementInteractable
{
    protected override bool CanStartManipulationForGesture(TapGesture gesture)
    {
        if (!placementPrefab)
        {
            return false;
        }
        if (IsPointerOverUIObject(gesture.startPosition))
        {
            return false;
        }
        if (gesture.TargetObject == null || gesture.TargetObject.layer == 9)
        {
            return true;
        }
        return false;
    }
    protected override void OnEndManipulation(TapGesture gesture)
    {
        if (placementPrefab)
        {
            base.OnEndManipulation(gesture);
        }
    }

    // Checks if an input is on a UI object
    static bool IsPointerOverUIObject(Vector2 screenPosition)
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = screenPosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
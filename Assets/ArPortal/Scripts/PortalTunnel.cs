
using UnityEngine;
using UnityEngine.Rendering;

public class PortalTunnel : MonoBehaviour
{
    public Transform device;
    public Transform portalWindow;
    [Range(0, 3)]
    public float tunnelLength = 1;

    bool inOtherWorld;

    void Start()
    {
        ExitOtherWorld();
    }

    void OnDestroy()
    {
        ExitOtherWorld();
    }

    void EnterOtherWorld()
    {
        SetPortalWindowPosition(-tunnelLength / 2);
        Shader.SetGlobalInt("_StencilTest", (int)CompareFunction.NotEqual);
    }

    void ExitOtherWorld()
    {
        SetPortalWindowPosition(tunnelLength / 2);
        Shader.SetGlobalInt("_StencilTest", (int)CompareFunction.Equal);
    }

    void SetPortalWindowPosition(float zPos)
    {
        portalWindow.localPosition = new Vector3(
            portalWindow.localPosition.x,
            portalWindow.localPosition.y,
            zPos);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
            return;
        inOtherWorld = !inOtherWorld;
        if (inOtherWorld)
            EnterOtherWorld();
        else
            ExitOtherWorld();
    }

}
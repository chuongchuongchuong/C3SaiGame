using UnityEngine;

public class ScriptInputManager : MonoBehaviour
{
    public static ScriptInputManager Instance { get; private set; }

    public Vector3 mouseWorldPos;

    [SerializeField] private Camera mainCamera;

    private void Reset()
    {
        mainCamera = Camera.main;
    }

    public void Update()
    {
        // Get the position of the mouse in World space
        mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
    }
}
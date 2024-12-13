using UnityEngine;

public class ScriptInputManager : MonoBehaviour
{
    public static ScriptInputManager Instance { get; private set; }

    public Vector3 mouseWorldPos;
    public float onFiring;

    [SerializeField] private Camera mainCamera;

    private void Reset()
    {
        mainCamera = Camera.main;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("More than one ScriptInputManager in scene.");
            return;
        }

        Instance = this;
    }

    public void Update()
    {
        GetMousePosition();

        GetMouseDown();
    }

    // Get the position of the mouse in World space
    private void GetMousePosition()
    {
        mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
    }

    //Get the Fire Signal
    private void GetMouseDown()
    {
        onFiring = Input.GetAxis("Fire1");
    }
}
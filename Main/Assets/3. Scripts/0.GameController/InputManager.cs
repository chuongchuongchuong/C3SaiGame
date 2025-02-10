using UnityEngine;

public class InputManager : ChuongMono
{
    #region Singleton Implementation
    public static InputManager Instance { get; private set; }

    protected override void GuaranteeSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("More than one " + GetType().Name + " in scene.");
            return;
        }

        Instance = this;
    }
    #endregion
    
    public Vector3 mouseWorldPos;
    public float onFiring;

    [SerializeField] private Camera mainCamera;

    protected override void Reset_LoadObjects()
    {
        mainCamera = Camera.main;
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

    public bool ChangeToBullet_1Button() => Input.GetKeyDown(KeyCode.Alpha1);
    public bool ChangeToBullet_2Button() => Input.GetKeyDown(KeyCode.Alpha2);
}
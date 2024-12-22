using UnityEngine;

public class ScriptInputManager : ChuongMonoSingleton<ScriptInputManager>
{
    public Vector3 mouseWorldPos;
    public float onFiring;
    public int weaponIndex = 1;

    [SerializeField] private Camera mainCamera;

    protected override void LoadObjects()
    {
        mainCamera = Camera.main;
    }

    public void Update()
    {
        GetMousePosition();
        GetMouseDown();

        GetWeaponIndex();
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

    private void GetWeaponIndex()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) weaponIndex = 1;
        if (Input.GetKeyDown(KeyCode.Alpha2)) weaponIndex = 2;
    }
}
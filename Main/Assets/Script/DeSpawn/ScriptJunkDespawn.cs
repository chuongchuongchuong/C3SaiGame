using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditorInternal;
using UnityEngine;

public class ScriptJunkDespawn : BaseDespawner
{
    private Camera _mainCamera;
    [SerializeField] private Vector3 viewportPosition;
    private int flag;

    protected override void ResetValues()
    {
        poolList = ScriptJunkPoolObject.Instance.poolList;
    }

    protected override void OnEnable()
    {
        flag = 0;
    }

    protected override void LoadComponents()
    {
        _mainCamera = Camera.main;
    }


    protected override bool CanDespawn()
    {
        viewportPosition = _mainCamera.WorldToViewportPoint(transform.parent.position);
        Debug.Log(viewportPosition);
        switch (flag)
        {
            case 0:
            {
                if (viewportPosition.x < 0) return false;
                if (viewportPosition.x > 1) return false;
                if (viewportPosition.y < 0) return false;
                if (viewportPosition.y > 1) return false;

                flag = 1; // đã đi vào maàn hình
                return false;
            }

            case 1:
            {
                if (viewportPosition.x < 0) return true;
                if (viewportPosition.x > 1) return true;
                if (viewportPosition.y < 0) return true;
                if (viewportPosition.y > 1) return true;

                return false;
            }
        }

        return false;
    }

    protected override void Update()
    {
        //Debug.Log(CanDespawn());
        if (!CanDespawn()) return;
        base.Despawn();
    }
}
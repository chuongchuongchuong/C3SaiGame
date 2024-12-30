using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BaseFlyStraight : ChuongPrefabs
{
    [Header("BaseFlyStraight")]
    [SerializeField] protected float speed; // tốc độ bay
    protected Vector2 direction; // hướng bay

    private void Update()
    {
        transform.parent.Translate(speed * Time.deltaTime * direction);
    }
}

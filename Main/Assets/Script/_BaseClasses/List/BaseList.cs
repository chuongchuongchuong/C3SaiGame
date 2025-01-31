using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseList<T> : ChuongMono
{
    public List<T> List;
    [SerializeField] protected int index = 1;
}
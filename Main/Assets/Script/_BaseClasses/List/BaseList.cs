using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseList<TListType> : ChuongMono
{
    [SerializeField] protected List<TListType> List;
    [SerializeField] protected int index = 1;
}
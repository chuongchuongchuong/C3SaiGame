using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservePattern : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public interface IObservePattern
{
    public void OnAppearStart();
    public void OnAppearFinish();
}

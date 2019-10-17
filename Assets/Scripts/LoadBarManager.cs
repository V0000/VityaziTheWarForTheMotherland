using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadBarManager : MonoBehaviour
{
    public Slider slider;
    public float speed = 0.001f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value != 1) slider.value += speed;
        else slider.value = 0;
    }
}

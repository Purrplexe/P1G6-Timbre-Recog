using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarRoom : MonoBehaviour
{
    Slider slider;
    public AnimationCurve curve;
    private float time = 1;
    public float maxtime = 2;
    private float valueGoal = 0;
    private float valueStart = 0;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        setGoal(22);
    }

    public void setGoal(float goal)
    {
        valueStart = slider.value;
        valueGoal = goal;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= maxtime)
        {
            time += Time.deltaTime;
            slider.value = valueStart + curve.Evaluate(time/maxtime) * valueGoal;
        }
    }
}

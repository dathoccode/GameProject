using UnityEngine;

public class StatBar : MonoBehaviour
{
    //Children
    public RectTransform background;
    public RectTransform line;
    // attributes
    public float maxValue { get; private set; }
    public float currentValue { get; private set; }
    void Start()
    {
        background = transform.Find("Background").GetComponent<RectTransform>();
        line = transform.Find("Line").GetComponent<RectTransform>();
    }

    void Update()
    {
        //update health bar based on current health

        if (maxValue <= 0)
        {
            line.localScale = new Vector3(0, 1, 1);
            return;
        }
        line.localScale = new Vector3(currentValue / maxValue, 1, 1);
    }

    public void SetValue(float value)
    {
        maxValue = value;
        currentValue = value;
    }
    
    public void ChangeCurrentValue(float value)
    {
        currentValue += value;
        if (currentValue < 0) currentValue = 0;
        if (currentValue > maxValue) currentValue = maxValue;
    }
}
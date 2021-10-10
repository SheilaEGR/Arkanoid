using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    private Text labelText = null;
    private Text valueText = null;

    public void SetLabel(string label)
    {
        if (labelText == null) return;
        labelText.text = label;
    }

    public void SetValue(int value)
    {
        if (valueText == null) return;
        valueText.text = value.ToString();
    }

    public void SetVisible(bool visible)
    {
        gameObject.SetActive(visible);
    }

    private void Awake()
    {
        labelText = transform.Find("Label").GetComponent<Text>();
        valueText = transform.Find("Value").GetComponent<Text>();
    }


}

using UnityEngine;
using UnityEngine.UI;

public class SetActiveToggle : MonoBehaviour
{
    [SerializeField] ToggleGroup myToggleGroup;
    Toggle activeToggle = null;
    [HideInInspector] public int toggleNumber;

    private void Update()
    {
        activeToggle = myToggleGroup.GetActive();
        if (activeToggle == null)
            toggleNumber = 0;
        else if (activeToggle.name == "A Toggle")
            toggleNumber = 1;
        else if (activeToggle.name == "B Toggle")
            toggleNumber = 2;
        else if (activeToggle.name == "C Toggle")
            toggleNumber = 3;
        else if (activeToggle.name == "D Toggle")
            toggleNumber = 4;
    }
}

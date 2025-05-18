using UnityEngine;
using UnityEngine.UI; 

public class StacksBar_Script : MonoBehaviour
{
    public Slider slider; 

    public void SetMaxStacks(int stacks)
    {
        slider.maxValue = stacks;
        slider.value = 0;
    }

    public void SetStacks(int stacks)
    {
        slider.value = stacks;
    }
}

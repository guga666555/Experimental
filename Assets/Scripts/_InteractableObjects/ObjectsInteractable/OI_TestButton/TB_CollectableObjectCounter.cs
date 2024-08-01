using TMPro;
using UnityEngine;

public class TB_CollectableObjectCounter : MonoBehaviour
{
    [field: SerializeField] private TextMeshProUGUI textString;
    [field: SerializeField] private int collectablesAmount;

    private void Start()
    {
        collectablesAmount = TB_CollectableObject.CollectableCount;
        textString = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        int i = Mathf.Abs(collectablesAmount - TB_CollectableObject.CollectableCount);
        textString.text = i + "/" + collectablesAmount;
    }
}

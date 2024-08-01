using Unity.Collections;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    private float frameRate = default;
    public int targetFrameRate = default;
    public bool seeFps;

    float updateTimer = 0.2f;
    [ReadOnly] public int fpsCurrent;

    private void CalculateFrameRate()
    {
        updateTimer -= Time.deltaTime;
        if (updateTimer <= 0f)
        {
            frameRate = 1f / Time.unscaledDeltaTime;
            fpsCurrent = (int)frameRate;
            updateTimer = 0.2f;
        }
    }

    private void Update()
    {
        if (seeFps) CalculateFrameRate();
    }
}

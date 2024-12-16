using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField] float shrinkSpeed = 0.0005f;
    [SerializeField] float minRingScale = 0.0445f;
    [SerializeField] float justRingScale = 0.0445f;

    private void Update()
    {
        Vector3 currentScale = transform.localScale;
        if (currentScale.x > minRingScale)
        {
            transform.localScale = new(currentScale.x - shrinkSpeed, currentScale.y - shrinkSpeed, currentScale.z - shrinkSpeed);
        }
    }
}
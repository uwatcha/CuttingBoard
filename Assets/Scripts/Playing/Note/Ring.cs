using UnityEngine;
public class Ring : MonoBehaviour
{
    [SerializeField] private float shrinkSpeed = 0.0005f;
    [SerializeField] private float minRingScale = 0.0445f;
    [SerializeField] private float justRingScale = 0.0445f;
    [SerializeField] private float appearDelaySeconds = 1.0f;
    private double noteAppearTime;
    [SerializeField] private SpriteRenderer ringSprite;
    void Start()
    {
        noteAppearTime = Timer.GetPlayingTime();
        shrinkSpeed = (transform.localScale.x - justRingScale) / appearDelaySeconds;
    }

    private void Update()
    {
        if (ringSprite.enabled || noteAppearTime + appearDelaySeconds < Timer.GetPlayingTime())
        {
            ringSprite.enabled = true;
            Vector3 currentScale = transform.localScale;
            if (currentScale.x > minRingScale)
            {
                transform.localScale -= new Vector3(shrinkSpeed, shrinkSpeed, shrinkSpeed) * Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
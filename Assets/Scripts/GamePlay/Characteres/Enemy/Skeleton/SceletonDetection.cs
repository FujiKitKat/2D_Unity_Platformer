using UnityEngine;

public class SceletonDetection : EnemyDetectionBase
{
    private bool _prevInRange;

    protected override void Update()
    {
        base.Update();

        if (!_prevInRange && IsPlayerInRange)
        {
            Debug.Log("Skeleton: player entered detection radius");
        }
        else if (_prevInRange && !IsPlayerInRange)
        {
            Debug.Log("Skeleton: player left detection radius");
        }

        _prevInRange = IsPlayerInRange;
    }
}

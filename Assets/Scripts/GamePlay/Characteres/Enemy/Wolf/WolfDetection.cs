using UnityEngine;

public class WolfDetection : EnemyDetectionBase
{
    private bool _prevInRange;

    protected override void Update()
    {
        base.Update();

        if (!_prevInRange && IsPlayerInRange)
        {
            Debug.Log("Wolf: player entered detection radius");
        }
        
        else if (_prevInRange && !IsPlayerInRange)
        {
            Debug.Log("Wolf: player left detection radius");
        }
        
        _prevInRange  = IsPlayerInRange;
    }
}

using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;

public class Bee : MonoBehaviour
{   
    Vector3 _targetPos;
    Hive _targetHive;

    public void GoToHive(Hive target, Transform flyOutPoint)
    {
        _targetHive = target;
        // fly out first, pause, then go to hive.
        Tween.Position(transform, flyOutPoint.position, 1f, 0f, Tween.EaseInOutBack,Tween.LoopType.None, null, GoToHive);
    }

    void GoToHive()
    {
        Tween.Position(transform, _targetHive.transform.position, 3f, 0f, Tween.EaseInOut, Tween.LoopType.None,null, OnHiveReached);
    }

    void OnHiveReached()
    {
        // TODO: optimise. Pool instead of destroy.
        Destroy(gameObject);
    }
}

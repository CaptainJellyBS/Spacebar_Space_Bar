using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy
{
    protected override IEnumerator Behavior()
    {
        yield return null;
    }
}

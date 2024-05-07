using System.Collections;
using System.Collections.Generic;
using Territory.Datas;
using UnityEngine;

namespace Territory.Events
{
    [CreateAssetMenu(fileName ="New Pair Game Event", menuName ="Events/Pair Event")]
    public class PairGameEvent : BaseGameEvent<Pair<GameObject, GameObject>>
    {
    }
}

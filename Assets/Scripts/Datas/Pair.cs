using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Territory.Datas
{
    [Serializable]
    public struct Pair<T, K>
    {
        public Pair(T item1, K item2)
        {
            Value1 = item1;
            Value2 = item2;
        }

        public T Value1;
        public K Value2;

    }
}

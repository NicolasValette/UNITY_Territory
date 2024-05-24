using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Territory.Datas
{
    [Serializable]
    public struct Triplet <T, K, L>
    {
        public Triplet(T item1, K item2, L item3)
        {
            Value1 = item1;
            Value2 = item2;
            Value3 = item3;
        }

        public T Value1;
        public K Value2;
        public L Value3;
    }
}

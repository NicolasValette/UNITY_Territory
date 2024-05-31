using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Territory
{
    [CreateAssetMenu (fileName ="New Game Options", menuName ="Datas/Game Options")]
    public class GameOptionsData : ScriptableObject
    {
        public int NumberOfHumanPlayer { get; set; }
        public int NumberOfAIPlayer { get; set; }

    }
}

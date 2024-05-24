using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Territory.Map;

namespace Territory.CustomEdit
{
    [CustomEditor(typeof(GraphManager))]
    public class GraphEditor : Editor
    {
        private GraphManager _graph;
        public void OnSceneGUI()
        {

            _graph = target as GraphManager;
          //  _graph.BuildGraph();
           
     

        }
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
          
            if (GUILayout.Button("Draw roads"))
            {
                Debug.Log("draw");
                _graph.DrawGraph();
            }
            if (GUILayout.Button("Erase roads"))
            {
                GameObject roadDrawer = GameObject.Find("RoadDrawer");
                Debug.Log("children : " + roadDrawer.transform.childCount);
                for (int i = roadDrawer.transform.childCount - 1; i >= 0; i--)
                {
                    Transform child = roadDrawer.transform.GetChild(i);
                    DestroyImmediate(child.gameObject);
                }
                
               
            }
        }
    }
}

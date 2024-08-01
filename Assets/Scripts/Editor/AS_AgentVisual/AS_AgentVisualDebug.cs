using UnityEngine.UIElements;
using UnityEditor;
using AIAgentScript;

[CustomEditor(typeof(AS_AgentDebugScripts))]
public class AS_AgentVisualDebug : Editor
{
    public VisualTreeAsset visualTree;
    
    public override VisualElement CreateInspectorGUI()
    {
        VisualElement root = new VisualElement();

        visualTree.CloneTree(root);

        return root;
    }
}

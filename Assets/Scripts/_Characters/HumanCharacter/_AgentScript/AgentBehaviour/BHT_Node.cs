using System.Collections.Generic;

namespace BehaviourTree
{
    public enum BHT_NodeState
    {
        RUNNING,
        FAILURE,
        SUCCESS
    }

    public class BHT_Node
    {
        protected BHT_NodeState state;

        public BHT_Node parent;
        public List<BHT_Node> Children { get; protected set; } = new();

        private Dictionary<string, object> dataContext = new();

        public BHT_Node()
        {
            parent = null;
        }

        public BHT_Node(List<BHT_Node> children)
        {
            foreach (BHT_Node child in children)
                Attach(child);
        }

        private void Attach(BHT_Node node) 
        {
            node.parent = this;
            Children.Add(node);
        }  

        public virtual BHT_NodeState Evaluate() => BHT_NodeState.FAILURE;

        public void SetData(string key, object value)
        {
            dataContext[key] = value;
        }

        public object GetData(string key)
        {
            object value = null;
            if (dataContext.TryGetValue(key, out value))
                return value;

            BHT_Node node = parent;
            while (node != null)
            {
                value = node.GetData(key);
                if ( value != null) 
                    return value;
                node = node.parent;
            }
            return null;
        }

        public bool ClearData(string key)
        {
            if (dataContext.ContainsKey(key))
            {
                dataContext.Remove(key);
                return true;
            }

            BHT_Node node = parent;
            while (node != null)
            {
                bool cleared = node.ClearData(key);
                if (cleared)
                    return true;
                node = node.parent;
            }
            return false;
        }
    }
}
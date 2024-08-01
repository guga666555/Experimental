using System.Collections.Generic;

namespace BehaviourTree
{
    public class BHT_Selector : BHT_Node
    {
        public BHT_Selector() : base() { }
        public BHT_Selector(List<BHT_Node> children) : base(children) { }

        public override BHT_NodeState Evaluate()
        {
            foreach (BHT_Node node in Children)
            {
                switch (node.Evaluate())
                {
                    case BHT_NodeState.FAILURE:
                        continue;
                    case BHT_NodeState.SUCCESS:
                        state = BHT_NodeState.SUCCESS;
                        return state;
                    case BHT_NodeState.RUNNING:
                        state = BHT_NodeState.RUNNING;
                        return state;
                    default:
                        continue;
                }
            }
            state = BHT_NodeState.FAILURE;
            return state;
        }
    }
}
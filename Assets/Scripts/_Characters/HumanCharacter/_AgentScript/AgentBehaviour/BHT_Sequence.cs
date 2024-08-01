using System.Collections.Generic;

namespace BehaviourTree
{
    public class BHT_Sequence : BHT_Node
    {
        public BHT_Sequence() : base() { }
        public BHT_Sequence(List<BHT_Node> children) : base(children) { }

        public override BHT_NodeState Evaluate()
        {
            bool anyChildIsRunning = false;

            foreach (BHT_Node node in Children)
            {
                switch (node.Evaluate())
                {
                    case BHT_NodeState.FAILURE:
                        state = BHT_NodeState.FAILURE;
                        return state;
                    case BHT_NodeState.SUCCESS:
                        continue;
                    case BHT_NodeState.RUNNING:
                        anyChildIsRunning = true;
                        continue;
                    default:
                        state = BHT_NodeState.SUCCESS;
                        return state;
                }
            }
            state = anyChildIsRunning ? BHT_NodeState.RUNNING : BHT_NodeState.SUCCESS;
            return state;
        }
    }
}
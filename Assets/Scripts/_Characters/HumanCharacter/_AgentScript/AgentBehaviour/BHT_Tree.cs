using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public abstract class BHT_Tree : MonoBehaviour
    {
        private BHT_Node root = null;

        protected void Start()
        {
            root = SetupTree();
        }

        private void Update()
        {
            if (root != null) { root.Evaluate(); }
        }

        protected abstract BHT_Node SetupTree();

        // *********************************************************************************
        // ********************** CONSTRUCTORS FOR BETTER READABILITY **********************
        // *********************************************************************************
      
        protected BHT_Sequence BTH_NewBranchSequence(string name, params BHT_Node[] nodes) // 2 Exits
        {
            return new BHT_Sequence(new List<BHT_Node>(nodes)); 
        }
  
        protected BHT_Selector BTH_NewBranchSelector(string name, params BHT_Node[] nodes) // 2 Exits
        {
            return new BHT_Selector(new List<BHT_Node>(nodes));
        }
    }
}
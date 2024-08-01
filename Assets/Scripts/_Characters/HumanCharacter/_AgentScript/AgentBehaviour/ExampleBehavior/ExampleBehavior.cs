using BehaviourTree;
using System.Collections.Generic;

public class ExampleBehavior : BHT_Tree
{
    // *** These are for testing the Behavior tree outcomes ***
    public bool dfn_Branch1A, dfn_Branch1B, dfn_Branch1C, dfn_Branch2A, dfn_Branch2B;

    protected override BHT_Node SetupTree()
    {
        // *** REMEMBER IMPORTANT *** 
        // *** Selector == OR || Sequence == AND ***  
        // *** Adding an extra 'true' statement on 'TaskExample' overload will mark as running 
        // *** When running is 'true' dont forget to add a timer overload

        BHT_Node rootBehavior = new BHT_Selector(new List<BHT_Node>()
        {
            BTH_NewBranchSelector("Behavior 1",
                BTH_NewBranchSequence("Behavior 1 Sub Behavior",
                    new TaskExample(dfn_Branch1A, "1(A) | If i fail, the '1(B)' statement will be ignored!"),
                    new TaskExample(dfn_Branch1B, "1(B) | If im happening is because '1(A)' statement has successed!")
                ),
                new TaskExample(dfn_Branch1C, "1(C) | If i happened is because '1(A, B)' has failed!", true, 3f)
            ),
            BTH_NewBranchSequence("Behavior 2",
                new TaskExample(dfn_Branch2A, "2(A) | If im happening is because the '1(A, B, C)' branch has failed!"),
                new TaskExample(dfn_Branch2B, "2(B) | If im happening is because '2(A)' statement has successed!")
            ),
            new TaskExample("3(A) | If im happening is because everything else has failed!")
        });

        print(rootBehavior.Children.Count);
        return rootBehavior;
    }
}


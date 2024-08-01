using BehaviourTree;
using UnityEngine;

public class TaskExample : BHT_Node
{
    private bool willBeRunning;
    private bool willWork;
    private string printText;
    private float runForHowLong;

    public TaskExample(string printText)
    {
        this.printText = printText;
    }

    public TaskExample(bool willWork, string printText)
    {
        this.printText = printText;
        this.willWork = willWork;
    }

    public TaskExample(bool willWork, string printText, bool willBeRunning, float runForHowLong)
    {
        this.printText = printText;
        this.willWork = willWork;
        this.willBeRunning = willBeRunning;
        this.runForHowLong = runForHowLong;
    }

    public override BHT_NodeState Evaluate()
    {
        if (state == BHT_NodeState.RUNNING) Debug.Log(this + "HAS A TASK RUNNING!!!!");

        if (willBeRunning)
        {
            state = BHT_NodeState.RUNNING;
            Debug.Log(printText + state);
            return state;
        }
        if (willWork)
        {
            state = BHT_NodeState.SUCCESS;
            Debug.Log(printText + state);
            return state;
        }
        else
        {
            state = BHT_NodeState.FAILURE;
            Debug.Log(printText + state);
            return state;
        }
    }
}

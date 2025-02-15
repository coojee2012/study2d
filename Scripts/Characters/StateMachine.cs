using Godot;
using System;

public partial class StateMachine : Node
{
    [Export] private Node currentState;
    [Export] private Node[] states;
    public override void _Ready()
    {
        currentState.Notification(GameConstants.NOTIFICATION_STATE_ENTRY);
    }

    public void SwitchState<T>() {
        Node newState = null;
        foreach(Node state in states) {
            if(state is T) {
                newState = state;
            }
        }
        if (newState == null) {
            return;
        }
        currentState.Notification(GameConstants.NOTIFICATION_STATE_EXIT);
        currentState = newState;
        currentState.Notification(GameConstants.NOTIFICATION_STATE_ENTRY);
    }
}

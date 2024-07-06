using Godot;
using System;

public abstract partial class PlayerState : Node
{
    protected Player charaterNode;
    public override void _Ready()
    {
        charaterNode = GetOwner<Player>();
        SetPhysicsProcess(false);
        SetProcessInput(false);
    }

    public override void _Notification(int what)
    {
        base._Notification(what);
        if (what == GameConstants.NOTIFICATION_STATE_ENTRY)
        {
            SetPhysicsProcess(true);
            SetProcessInput(true);
            EntryState();
        }
        else if(what == GameConstants.NOTIFICATION_STATE_EXIT) {
            SetPhysicsProcess(false);
            SetProcessInput(false);
        }
    }

    public override void _Input(InputEvent @event)
    {
        if(Input.IsActionJustPressed(GameConstants.INPUT_DASH)) {
            charaterNode.StateMachine.SwitchState<PlayerDashState>();
        }
    }

    protected virtual void EntryState() {}
}
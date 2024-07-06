using Godot;
using System;

public partial class PlayerIdelState : PlayerState
{

    public override void _Ready()
    {
        base._Ready();
    }

    public override void _PhysicsProcess(double delta)
    {
        GD.Print("Idle State Process");
        if (charaterNode.direaction != Vector2.Zero)
        {
            charaterNode.StateMachine.SwitchState<PlayerMoveState>();
        }
    }

    public override void _Notification(int what)
    {
        base._Notification(what);
    }

    

    protected override void EntryState()
    {
         charaterNode.AnimationPlayerNode.Play(GameConstants.ANIM_IDLE);
    }

}

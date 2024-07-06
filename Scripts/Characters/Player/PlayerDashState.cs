using Godot;
using System;
using System.Reflection.Metadata;

public partial class PlayerDashState : PlayerState
{
    [Export] private Timer dashTimerNode;
    [Export(PropertyHint.Range, "0,20,0.1")] private float speed = 10;
    public override void _Ready()
    {
        base._Ready();
        dashTimerNode.Timeout += HandleDashTimeout;
    }

    public override void _PhysicsProcess(double delta)
    {
        GD.Print("Dash State Process");
        charaterNode.MoveAndSlide();
        charaterNode.Flip();
    }

    public override void _Notification(int what)
    {
        base._Notification(what);
    }

    protected override void EntryState()
    {
         charaterNode.AnimationPlayerNode.Play(GameConstants.ANIM_DASH);
         charaterNode.Velocity = new(charaterNode.direaction.X, 0, charaterNode.direaction.Y);
         charaterNode.Velocity *= speed;
         if(charaterNode.Velocity == Vector3.Zero) {
            charaterNode.Velocity = charaterNode.Sprite3DNode.FlipH ? Vector3.Left : Vector3.Right;
         }
         dashTimerNode.Start();
    }

    private void HandleDashTimeout() {
        charaterNode.Velocity = Vector3.Zero;
        charaterNode.StateMachine.SwitchState<PlayerIdelState>();
    }
}

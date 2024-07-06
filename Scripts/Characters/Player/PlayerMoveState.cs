using Godot;
using System;

public partial class PlayerMoveState : PlayerState
{

    [Export(PropertyHint.Range, "0,10,0.1")] private float speed = 5;
    public override void _Ready()
    {
        base._Ready();
    }

    public override void _PhysicsProcess(double delta)
    {
        GD.Print("Move State Process");

        if (charaterNode.direaction == Vector2.Zero)
        {
            charaterNode.StateMachine.SwitchState<PlayerIdelState>();
            return;
        }
        charaterNode.Velocity = new Vector3(charaterNode.direaction.X, 0, charaterNode.direaction.Y);
        charaterNode.Velocity *= speed;
        charaterNode.MoveAndSlide();
        charaterNode.Flip();
    }

    protected override void EntryState()
    {
        charaterNode.AnimationPlayerNode.Play(GameConstants.ANIM_RUNNING);
    }
}

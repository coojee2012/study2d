using Godot;
using System;

public partial class Player : CharacterBody3D
{
	[ExportGroup("Required Nodes")]
	[Export] public AnimationPlayer AnimationPlayerNode {get; private set;}
	[Export] public Sprite3D Sprite3DNode {get; private set;}
	[Export] public StateMachine StateMachine {get; private set;}
	public Vector2 direaction = new();

	public override void _Ready()
	{
		GD.Print(AnimationPlayerNode.Name);
	}
	public override void _PhysicsProcess(double delta)
	{
		//GD.Print("Physics Process!");
		// Velocity = new Vector3(direaction.X, 0, direaction.Y);
		// Velocity *= 5;
		// MoveAndSlide();
		// Flip();
	}

	public override void _Input(InputEvent @event)
	{
		direaction = Input.GetVector(GameConstants.INPUT_MOVE_LEFT, GameConstants.INPUT_MOVE_RIGHT, 
		GameConstants.INPUT_MOVE_FORWARD,  GameConstants.INPUT_MOVE_BACKWARD);
	}

	public void Flip() {
		var isNotMoveingHorizontally = direaction.X == 0;
		if (isNotMoveingHorizontally) {return;}
		var isMoveLeft = direaction.X < 0;
		Sprite3DNode.FlipH = isMoveLeft;
	}
}

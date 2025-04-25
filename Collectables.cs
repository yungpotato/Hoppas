using Godot;
using System;

public partial class Collectables : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		BodyEntered += OnBodyEntered;
	}
	private void OnBodyEntered(Node body)
	{
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	if (body is CharacterBody2D)
	{
		// Huudellaan metodia
		Countter.AddPoint();

		QueueFree();
	}
	}
}

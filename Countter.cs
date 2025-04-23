using Godot;
using System;

public partial class Countter : Node
{
    public static int Points { get; private set; } = 0;

	    private static Label _pointsLabel;

    public override void _Ready()
    {
  
        _pointsLabel = GetTree()
            .Root
            .GetNode<Node>("Node")      // pääscene
            .GetNode<Label>("halp/Panel/Label");

        // Aseta aluksi nollaksi
        _pointsLabel.Text = Points.ToString();
    }


    public static void AddPoint()
    {
        Points++;
        GD.Print($"Kukkaset: {Points}");

		if (_pointsLabel != null)
           	_pointsLabel.Text = Points.ToString();
    }
}

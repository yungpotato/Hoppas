using Godot;
using System;

public partial class Countter : Node
{
    public static int Points { get; private set; } = 0;

    // Funktio pisteiden kasvattamiseen
    public static void AddPoint()
    {
        Points++;
        GD.Print($"Pisteet: {Points}");
    }
}

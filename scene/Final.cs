using Godot;
using System;

public partial class Final : Area2D
{
    Label _winLabel;

    public override void _Ready()
    {
        // 1) kytketään signal
        BodyEntered += OnBodyEntered;

        // 2) haetaan WinLabel suoraan CurrentScene:n juuresta
        var sceneRoot = GetTree().CurrentScene as Node;
        _winLabel = sceneRoot.GetNode<Label>("halp/Panel/WinLabel");
        _winLabel.Visible = false;

        GD.Print("Final valmis, label löytyi: ", _winLabel != null);
    }

    private void OnBodyEntered(Node body)
    {
        GD.Print("Final: BodyEntered fired! osunut: ", body);
        if (body is CharacterBody2D)
        {
            GD.Print("Pelaaja maalissa!");
            _winLabel.Text = "Voitit pelin!";
            _winLabel.Visible = true;

            // halutessasi pysäytä peli
            GetTree().Paused = true;
        }
    }
}
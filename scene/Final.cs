using Godot;
using System;

public partial class Final : Area2D
{
    // Tallennetaan Label
    private static Label _winlabel;

    public override void _Ready()
    {
        // Kuunnellaan/odotellaan osumia
        BodyEntered += OnBodyEntered;
    }

    private void OnBodyEntered(Node body)
    {
        if (body is CharacterBody2D)
        {
            ShowWinText();
            // halutessasi pysäytä peli, koska miksei
            GetTree().Paused = true;
        }
    }

    private void ShowWinText()
    {
        // Hae winlabel VAIN kerran
        if (_winlabel == null)
        {
            // Haetaan scenen roottista
            var sceneRoot = GetTree().CurrentScene as Node;
            _winlabel = sceneRoot.GetNodeOrNull<Label>("halp/Panel/winlabel");

            if (_winlabel == null)
            {
               GD.PrintErr("Et löytänyt maalia.");
                return;
            }
        }

        // Voittoteksti ja näkyvyys true (falsesta)
        _winlabel.Text = "ONNEOLKOO VOITIT PELIN!";
        _winlabel.Visible = true;
    }
}
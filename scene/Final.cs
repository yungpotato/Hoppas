using Godot;
using System;

public partial class Final : Area2D
{
    // Staattinen kenttä, johon talletamme Label-viitteen
    private static Label _winlabel;

    public override void _Ready()
    {
        // Liitetään signaali kuuntelemaan osumia
        BodyEntered += OnBodyEntered;
    }

    private void OnBodyEntered(Node body)
    {
        if (body is CharacterBody2D)
        {
            ShowWinText();
            // halutessasi pysäytä peli:
            GetTree().Paused = true;
        }
    }

    private void ShowWinText()
    {
        // Hae Label-node vain kerran
        if (_winlabel == null)
        {
            // Nykyisen scene-rootin läpi löydät halp/Panel/WinLabel
            var sceneRoot = GetTree().CurrentScene as Node;
            _winlabel = sceneRoot.GetNodeOrNull<Label>("halp/Panel/winlabel");

            if (_winlabel == null)
            {
                GD.PrintErr("Final: ei löytänyt WinLabel-nodea polulla halp/Panel/winlabel");
                return;
            }
        }

        // Aseta teksti ja tee näkyväksi
        _winlabel.Text = "ONNEOLKOO VOITIT PELIN!";
        _winlabel.Visible = true;
    }
}
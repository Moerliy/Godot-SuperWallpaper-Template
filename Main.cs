using Godot;
using System;
using SuperWallpaper.Scripts.Events;

namespace SuperWallpaper;

public partial class Main : Node3D
{
	/// <summary>
	/// Main entry point for the SuperWallpaper application. Inherits from Node3D and initializes
	/// the event management system when the scene is ready.
	/// </summary>
	public override void _Ready() {
		EventManager.Instance.StartAll();
		
		 // Adjust path as needed
		var animationPlayer = GetNode<AnimationPlayer>("Sketchfab_Scene/AnimationPlayer");

		// Check available animations in the editor, use the exact name
		animationPlayer.Play("Take 001");
	}
}

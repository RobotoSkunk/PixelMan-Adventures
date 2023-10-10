/*
	PixelMan Adventures - An open-source 2D platformer game.
	Copyright (C) 2023 Edgar Lima (RobotoSkunk) <contact@robotoskunk.com>
	Copyright (C) 2023 Repertix

	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU Affero General Public License as published
	by the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU Affero General Public License for more details.

	You should have received a copy of the GNU Affero General Public License
	along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/


using ClockBombGames.PixelMan.Utils;
using Godot;


namespace ClockBombGames.PixelMan.GameObjects
{
	public partial class Saw : Area2D
	{
		[Export] VisibleOnScreenNotifier2D notifier;
		[Export] Sprite2D sprite;

		float rotationSpeed;

		public bool Enabled { get; set; } = true;


		public override void _Ready()
		{
			rotationSpeed = RSRandom.Range(600f, 700f) * RSRandom.Sign();
		}

		public override void _Process(double delta)
		{
			if (notifier.IsOnScreen() && Enabled) {
				sprite.RotationDegrees += rotationSpeed * (float)delta;
				sprite.Position = RSRandom.Circle2D();
			}
		}

		public override void _PhysicsProcess(double delta)
		{
			Monitorable = Enabled;
		}
	}
}
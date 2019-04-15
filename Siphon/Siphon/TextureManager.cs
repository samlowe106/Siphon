using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Siphon
{
	class TextureManager
	{
		// fields
		// textures
		public Texture2D startButtonTexture;
		public Texture2D backButtonTexture;
		public Texture2D arrow;
		public Texture2D turret;
		public Texture2D bullet;
		public Texture2D playerModel;
		public Texture2D plugEnemyModel;
		public Texture2D groundTexture;
		public Texture2D batteryTexture;
		public Texture2D healthBar;
		public Texture2D repairDestroy;
		public Texture2D GameUI;
		public Texture2D menuBackground;
		public Texture2D gameBackground;
		public Texture2D NextWave;
		public Texture2D instructions;
		public Texture2D pistol;

		// constructor
		public TextureManager(
			Texture2D startButtonTexture,
			Texture2D backButtonTexture,
			Texture2D arrow,
			Texture2D turret,
			Texture2D bullet,
			Texture2D playerModel,
			Texture2D plugEnemyModel,
			Texture2D groundTexture,
			Texture2D batteryTexture,
			Texture2D healthBar,
			Texture2D repairDestroy,
			Texture2D GameUI,
			Texture2D menuBackground,
			Texture2D gameBackground,
			Texture2D NextWave,
			Texture2D instructions,
			Texture2D pistol)
		{
			this.startButtonTexture = startButtonTexture;
			this.backButtonTexture = backButtonTexture;
			this.arrow = arrow;
			this.turret = turret;
			this.bullet = bullet;
			this.playerModel = playerModel;
			this.plugEnemyModel = plugEnemyModel;
			this.groundTexture = groundTexture;
			this.batteryTexture = batteryTexture;
			this.healthBar = healthBar;
			this.repairDestroy = repairDestroy;
			this.GameUI = GameUI;
			this.menuBackground = menuBackground;
			this.gameBackground = gameBackground;
			this.NextWave = NextWave;
			this.instructions = instructions;
			this.pistol = pistol;
		}

	}
}

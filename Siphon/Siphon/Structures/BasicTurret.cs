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
	enum TurretState
	{
		idle,
		firing
	}

	class BasicTurret : Structure
	{
		#region Fields

		private Enemy target;
		private int counter1;
		private float drawCounter;
		private float fireRate;
		private GameTime timer;

		private Queue<Bullet> bullets;

		// draw variables
		private TurretState turretState;
		private int fireState;

		#endregion

		#region Constructor

		public BasicTurret(Vector2 position, Texture2D texture, Texture2D bulletTexture, int dimension)
			: base(position, texture, dimension)
		{
			counter1 = 0;
			drawCounter = 0f;
			target = null;
			fireRate = 0.25f;
			fireState = 1;
			turretState = TurretState.idle;
			timer = new GameTime();

			bullets = new Queue<Bullet>();
			for (int i = 0; i < 20; i++)
			{
				bullets.Enqueue(new Bullet(bulletTexture, width * 10, height * 10));
			}
		}
		#endregion

		#region Methods

		public override void Update(List<Enemy> enemies)
		{
			drawCounter += timer.TotalGameTime.Milliseconds;
			fireRate += timer.TotalGameTime.Milliseconds;

			if (counter1 > 10)
			{
				counter1 = 0;

				pickTarget(enemies);
			}

			if (target != null)
			{
				SetAngle((int)target.Position.X, (int)target.Position.Y);

				if (fireRate >= 0.25)
				{
					fireRate = 0;
					//Bullet b = bullets.Dequeue();
					//Shoot(target, b);
					//bullets.Enqueue(b);
				}

			}
		}

		private void pickTarget(List<Enemy> enemies)
		{
			if (enemies == null || enemies.Count < 1)
			{
				target = null;
			}
			else
			{
				Enemy temp = enemies[0];
				foreach(Enemy e in enemies)
				{
					temp = getCloser(temp, e);
				}
				target = temp;
			}
		}

		private Enemy getCloser(Enemy e1, Enemy e2)
		{
			Vector2 dist1 = position - e1.Position;
			Vector2 dist2 = position - e2.Position;

			if (dist1.LengthSquared() > dist2.LengthSquared())
			{
				return e1;
			}

			return e2;
		}

		public override void Draw(SpriteBatch sp)
		{
			switch (turretState)
			{
				case TurretState.idle:
					sp.Draw(texture, rectangle, new Rectangle(0, 0, 32, 32), Color.White);
					break;
				case TurretState.firing:
					sp.Draw(texture, rectangle, new Rectangle(fireState * 32, 0, 32, 32), Color.White);

					

					if (drawCounter >= 0.25)
					{
						drawCounter -= 0.25f;
						if (fireState == 1)
							fireState = 2;
						else
							fireState = 1;
					}

					break;
			}
			
		}

		public void Shoot(Enemy e, Bullet b)
		{

		}
		#endregion
	}
}

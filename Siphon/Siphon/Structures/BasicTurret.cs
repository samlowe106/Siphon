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
		private bool fireState;

		#endregion

		#region Constructor

		public BasicTurret(Vector2 position, Texture2D texture, Texture2D bulletTexture, int dimension)
			: base(position, texture, dimension)
		{
			counter1 = 0;
			drawCounter = 0f;
			target = null;
			fireRate = 0.25f;
			fireState = true;
			turretState = TurretState.firing;
			timer = new GameTime();
            origin = new Vector2(16, 16);

			bullets = new Queue<Bullet>();
			for (int i = 0; i < 20; i++)
			{
				bullets.Enqueue(new Bullet(bulletTexture));
			}
		}
		#endregion

		#region Methods

		public override void Update(List<Enemy> enemies)
		{
            drawCounter += (1 / 60f);
            fireRate += (1 / 60f);
            counter1++;

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
                    sp.Draw(texture, rectangle, new Rectangle(0, 0, 32, 32), Color.White, (float)(angle + (Math.PI / 2)), origin, SpriteEffects.None, 1f);
                    break;

				case TurretState.firing:
					//sp.Draw(texture, rectangle, new Rectangle(32, 0, 32, 32), Color.White);

                    

                    if (drawCounter >= .125f)
                    {
                        drawCounter = 0;
                        fireState = !fireState;
                    }

                    if (fireState)
                        sp.Draw(texture, new Rectangle(rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2, rectangle.Width, rectangle.Height), new Rectangle(64, 0, 32, 32), Color.White, (float)(angle + (Math.PI / 2)), origin, SpriteEffects.None, 1f);
                    else
                        sp.Draw(texture, new Rectangle(rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2, rectangle.Width, rectangle.Height), new Rectangle(32, 0, 32, 32), Color.White, (float)(angle + (Math.PI / 2)), origin, SpriteEffects.None, 1f);
                    break;
			}
			
		}

		public void Shoot(Enemy e, Bullet b)
		{

		}
		#endregion
	}
}

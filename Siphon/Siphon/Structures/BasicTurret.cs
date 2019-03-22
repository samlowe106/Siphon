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
		private float deltaTime;
		private GameTime timer;
		private Texture2D groundTexture;

		private Queue<Bullet> bullets;

		// draw variables
		private TurretState turretState;
		private bool fireState;

		#endregion

		#region Constructor

		public BasicTurret(Vector2 position, Texture2D texture, Texture2D bulletTexture, Texture2D groundTexture, int dimension)
			: base(position, texture, dimension)
		{
			counter1 = 0;
			drawCounter = 0f;
			target = null;
			fireRate = 0.25f;
			fireState = true;
			turretState = TurretState.idle;
			timer = new GameTime();
            origin = new Vector2(16, 16);
			this.groundTexture = groundTexture;

			bullets = new Queue<Bullet>();
			for (int i = 0; i < 20; i++)
			{
				bullets.Enqueue(new Bullet(bulletTexture));
			}
		}
		#endregion

		#region Methods

		public void Update(List<Enemy> enemies, GameTime gameTime)
		{
			deltaTime = (float)(gameTime.ElapsedGameTime.TotalSeconds);
            fireRate += deltaTime;
            
            counter1++;

			if (counter1 > 10)
			{
				counter1 = 0;

				pickTarget(enemies);
			}

            if (target != null && target.Active)
            {
                SetAngle((int)target.Position.X, (int)target.Position.Y);

                if (fireRate >= 0.25f)
                {
                    fireRate = 0f;

                    target.TakeDamage(1);

                    //Bullet b = bullets.Dequeue();
                    //Shoot(target, b);
                    //bullets.Enqueue(b);
                }

                turretState = TurretState.firing;
            }
            else
                turretState = TurretState.idle;
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

                if (GetDistanceSquared(temp) <= (width * width * 9))
                    target = temp;
                else
                    target = null;
			}
		}

		private Enemy getCloser(Enemy e1, Enemy e2)
		{
			Vector2 dist1 = position - e1.Position;
			Vector2 dist2 = position - e2.Position;

			if (dist1.LengthSquared() < dist2.LengthSquared())
			{
				return e1;
			}

			return e2;
		}

		public override void Draw(SpriteBatch sp)
		{
			sp.Draw(groundTexture, rectangle, Color.White);

			switch (turretState)
			{
				case TurretState.idle:
					sp.Draw(texture,
							new Rectangle(rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2, rectangle.Width, rectangle.Height),
							new Rectangle(0, 0, 32, 32),
							Color.White,
							(float)(angle + (Math.PI / 2)),
							origin, SpriteEffects.None, 1f);
					break;

				case TurretState.firing:
					drawCounter += deltaTime;
					if (drawCounter >= .125f)
					{
						drawCounter -= 0.125f;
						fireState = !fireState;
					}

					if (fireState)
					{
						sp.Draw(texture,
								new Rectangle(rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2, rectangle.Width, rectangle.Height),
								new Rectangle(64, 0, 32, 32),
								Color.White,
								(float)(angle + (Math.PI / 2)),
								origin, SpriteEffects.None, 1f);
					}
					else
					{
						sp.Draw(texture,
								new Rectangle(rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2, rectangle.Width, rectangle.Height),
								new Rectangle(32, 0, 32, 32),
								Color.White,
								(float)(angle + (Math.PI / 2)),
								origin, SpriteEffects.None, 1f);
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

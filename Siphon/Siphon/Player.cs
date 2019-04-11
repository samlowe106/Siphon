﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Siphon
{
    /// <summary>
    /// The GameObject player-character which the player will control
    /// </summary>
	class Player : GameObject
	{
        Weapon currentWeapon;
        int money;
        public Player(Vector2 position, Texture2D texture, int dimensions)
            : base(position, texture, dimensions, new Vector2(dimensions / 3, dimensions / 3))
        {
        }

        /// <summary>
        /// Runs player movement function and checks to see if gun should be fired
        /// </summary>
        /// <param name="kbState">Current keyboard state to be tested</param>
        /// <param name="currentMouseState">Current mouse state to be tested</param>
        /// <param name="previousMouseState">Previous mouse state to be tested</param>
        public void Update(KeyboardState kbState, MouseState currentMouseState, MouseState previousMouseState, bool safe)
        {
            // Move
            PlayerMovement(kbState);
            // Set angle
            SetAngle(currentMouseState.X, currentMouseState.Y);
            // Shoot (if left mouse button is down)
            if (!safe && currentMouseState.LeftButton == ButtonState.Pressed && CurrentWeapon != null)
            {
                CurrentWeapon.PullTrigger(currentMouseState, previousMouseState);
            }
            base.Update();
        }

        /// <summary>
        /// Draws the player and their weapon (if it exists)
        /// </summary>
        /// <param name="sp"></param>
        public override void Draw(SpriteBatch sp)
        {
            // Draw the held weapon
            if (this.CurrentWeapon != null)
            {
                CurrentWeapon.Draw(sp);
                CurrentWeapon.Update();
            }
            base.Draw(sp);
        }

        /// <summary>
        /// Player Movement Method that will be called in the update method
        /// </summary>
        /// <param name="current">Current keyboard state to be tested</param>
        public void PlayerMovement(KeyboardState current)
        {
            if (current.IsKeyDown(Keys.W))
            {
                position = new Vector2(position.X, position.Y - speed.Y);
            }
            if (current.IsKeyDown(Keys.A))
            {
                position = new Vector2(position.X - speed.X, position.Y);
            }
            if (current.IsKeyDown(Keys.S))
            {
                position = new Vector2(position.X, position.Y + speed.Y);
            }
            if (current.IsKeyDown(Keys.D))
            {
                position = new Vector2(position.X + speed.X, position.Y);
            }
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, rectangle.Width, rectangle.Height);

        }

        #region Properties
        /// <summary>
        /// The weapon that this player object holds
        /// </summary>
        public Weapon CurrentWeapon
        {
            get
            {
                return currentWeapon;
            }
            set
            {
                currentWeapon = value;
                currentWeapon.Holder = this;
            }
        }

        public int Money
        {
            get{
                return money;
            }

            set
            {
                money += value;
            }
        }
        #endregion
    }
}

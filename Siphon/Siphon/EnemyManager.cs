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
    class EnemyManager
    {
        #region Constants
        const int ENEMIES_PER_WAVE = 3;
        const double DELAY = 15000; // in milliseconds
        #endregion

        #region Fields
        private int waveNumber;
        private List<Enemy> activeEnemies;
        private Random generator;
        private MainStructure mainStructure;
        private int screenWidth;
        private int screenHeight;
        private Map map;
        private List<Structure> listOfTurrets;
        private GameTime currentTime;
		private Texture2D plugEnemyModel;
        private double timeUntilNextWave;

		// health bar stuff
		private Texture2D bar;

        // Starter enemy's texture
        private Texture2D startTexture;
        #endregion

        #region Constructor
        public EnemyManager(Texture2D startTexture, Map map, int screenWidth, int screenHeight, Texture2D plugEnemyModel, Texture2D bar)
        {
            this.generator = new Random();
            this.startTexture = startTexture;
            this.activeEnemies = new List<Enemy>();
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.map = map;
            this.listOfTurrets = map.Turrets;
            this.mainStructure = map.mainStructure;
            this.timeUntilNextWave = DELAY;
			this.bar = bar;
			this.plugEnemyModel = plugEnemyModel; //Starter Enemy
        }
        #endregion

        #region Methods
        public void BeginNextWave()
        {
            // Increment the current wave
            ++waveNumber;

            // Reset the time until the next wave
            timeUntilNextWave = DELAY;

            #region StarterEnemySpawn
            for (int i = 0; i < (waveNumber * 15); ++i)
            {
                //int xCoord = screenWidth * generator.Next(0, 2);
                //int yCoord = screenHeight * generator.Next(0, 2);

                int sideDecider = generator.Next(0, 4);
                // Get coords for the next enemy to be spawned in
                int xCoord;
                int yCoord;
                // 50% chance that the enemy will spawn on the right
                if (sideDecider == 0)
                {
                    // make the enemy spawn on the left
                    xCoord = generator.Next(0, 50);
                    yCoord = generator.Next(0, screenHeight);
                }
                else if(sideDecider == 1)
                {
                    //Spawn On the top
                    xCoord = generator.Next(0, screenWidth);
                    yCoord = generator.Next(0, 50);
                }
                else if (sideDecider == 2)
                {
                    //Spawn on the right
                    xCoord = generator.Next(screenWidth - 50, screenWidth);
                    yCoord = generator.Next(0, screenHeight);
                }
                else
                {
                    //Spawn on the bottom
                    xCoord = generator.Next(0, screenWidth);
                    yCoord = generator.Next(screenHeight - 50, screenHeight);
                }

                Vector2 enemyCoords = new Vector2(xCoord, yCoord);
                // Spawn in 3 additional enemies per wave
                AddToList(new StarterEnemy(enemyCoords, plugEnemyModel, bar, mainStructure, map.Turrets));
            }
            #endregion
        }

        /// <summary>
        /// Loops over enemies, updating each one
        /// </summary>
        public void Update(GameTime gameTime)
        {
            currentTime = gameTime;
            timeUntilNextWave -= currentTime.ElapsedGameTime.Milliseconds;
            
            // Spawn the next wave when it's time (use the variable timeUntilNextWave for precision)
            if (timeUntilNextWave <= 1)
            {
                BeginNextWave();
            }

            listOfTurrets = map.Turrets;

            // Loop over each enemy, updating them
            for (int i = activeEnemies.Count - 1; i > -1; --i)
            {
                activeEnemies[i].Update(gameTime, listOfTurrets);
                // If the enemy isn't active (it's died), remove it from the list
                if (!activeEnemies[i].Active)
                {
                    activeEnemies.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Loop over each enemy, drawing them
        /// </summary>
        /// <param name="sp">The spriteBatch that will draw each enemy</param>
        public void Draw(SpriteBatch sp)
        {
            foreach (Enemy enemy in activeEnemies)
            {
                enemy.Draw(sp);
            }
        }

        /// <summary>
        /// Checks a bullet against ALL active enemies
        /// </summary>
        /// <param name="b">Bullet to check</param>
        /// <returns>An enemy that the bullet is collding with, null if the bullet doesn't collide with anything</returns>
        public Enemy CheckCollision(Bullet b)
        {
            foreach (Enemy e in activeEnemies)
            {
                // If the enemy's hitbox overlaps with the bullet's, return true
                if (e.Rectangle.Intersects(b.Rectangle))
                {
                    return e;
                }
            }
            // If the bullet doesn't intersect with any rectangles, return false
            return null;
        }

        public void AddToList(Enemy e)
        {
            
            activeEnemies.Add(e);
        }
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public int WaveNumber
        {
            get
            {
                return waveNumber;
            }
        }

        /// <summary>
        /// The amount of time, in seconds, until the next wave spawns
        /// </summary>
        public int TimeUntilNextWave
        {
            get
            {
                return (int)timeUntilNextWave / 1000;
            }
        }

        /// <summary>
        /// True if there are no enemies on the stage, false if there are still enemies on the stage
        /// </summary>
        public bool StageClear
        {
            get
            {
                return activeEnemies.Count == 0;
            }
        }

        /// <summary>
        /// List of all enemies currently active on the map
        /// </summary>
        public List<Enemy> ActiveEnemies
        {
            get
            {
                return activeEnemies;
            }
        }

        #endregion
    }
}

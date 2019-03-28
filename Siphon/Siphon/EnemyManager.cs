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
        #endregion

        #region Fields
        private int waveNumber;
        private List<Enemy> activeEnemies;
        private Random generator;
        private bool stageClear;
        private MainStructure mainStructure;
        private Texture2D plugEnemyModel;
        private int screenWidth;
        private int screenHeight;
        private Map map;
        private List<Structure> listOfTurrets;


        private GameTime nextWaveSpawnTime;
        private GameTime timeUntilNextWave;
        // Starter enemy's texture
        private Texture2D startTexture;
        #endregion

        #region Constructor
        public EnemyManager(Texture2D startTexture, Map map, int screenWidth, int screenHeight, Texture2D plugEnemyModel)
        {
            this.generator = new Random();
            this.startTexture = startTexture;
            this.activeEnemies = new List<Enemy>();
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.map = map;
            this.listOfTurrets = map.Turrets;
            mainStructure = map.mainStructure;
        }
        #endregion

        #region Methods
        public void BeginNextWave(GameTime gameTime)
        {
            // Increment the current wave
            ++waveNumber;
            // Set the amount of time until the next wave
            //timeUntilNextWave = gameTime + SOMETHING;

            #region StarterEnemySpawn
            for (int i = 0; i < (waveNumber * 15); ++i)
            {

                int sideDecider = generator.Next(0, 4);
                // Get coords for the next enemy to be spawned in
                int xCoord;
                int yCoord;
                // 50% chance that the enemy will spawn on the right
                if (sideDecider == 0)
                {
                    xCoord = generator.Next(0, 50);
                    yCoord = generator.Next(0, screenHeight);
                    // make the enemy spawn on the left
                }
                else if(sideDecider == 1)
                {
                    xCoord = generator.Next(0, screenWidth);
                    yCoord = generator.Next(0, 50);
                }
                else if (sideDecider == 2)
                {
                    xCoord = generator.Next(screenWidth - 50, screenWidth);
                    yCoord = generator.Next(0, screenHeight);
                }
                else
                {
                    xCoord = generator.Next(0, screenWidth);
                    yCoord = generator.Next(screenHeight - 50, screenHeight);
                }

                Vector2 enemyCoords = new Vector2(xCoord, yCoord);
                // Spawn in 3 additional enemies per wave
                AddToList(new StarterEnemy(enemyCoords, startTexture, mainStructure, listOfTurrets));
            }
            #endregion
        }

        /// <summary>
        /// Loops over enemies, updating each one
        /// </summary>
        public void Update(GameTime gameTime)
        {
            List<Structure> listOfTurrets = map.Turrets;
            
            // Loop over each enemy, updating them
            for (int i = activeEnemies.Count - 1; i > -1; --i)
            {
                activeEnemies[i].Update();
                // If the enemy isn't active (it's died), remove it from the list
                if (!activeEnemies[i].Active)
                {
                    activeEnemies.RemoveAt(i);
                }
            }
            // If all the enemies have died, mark the stage as clear
            stageClear = activeEnemies.Count == 0;
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
        /// True if there are no enemies on the stage, false if there are still enemies on the stage
        /// </summary>
        public bool StageClear
        {
            get
            {
                return stageClear;
            }
        }

        /// <summary>
        /// Timer representing the amount of time until the next wave will spawn
        /// </summary>
        public double TimeUntilNextWave
        {
            get
            {
                return timeUnitilNextWave;
            }
        }

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

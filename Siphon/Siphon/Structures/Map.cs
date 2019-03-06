using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Siphon
{
    class Map
    {
        // fields 
        Structure[ , ] structures;
        private int sideLength;
        private int screenWidth;
        private int screenHeight;

		public MainStructure mainStructure;

        // textures
        private Texture2D mainStructureTexture;
        private Texture2D turretTexture;
        private Texture2D bulletTexture;

        public Map(int screenWidth, int screenHeight, Texture2D mainStructureTexture, Texture2D turretTexture, Texture2D bulletTexture)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.mainStructureTexture = mainStructureTexture;
			this.turretTexture = turretTexture;
			this.bulletTexture = bulletTexture;

            Load();
        }

        private void Load()
        {
            //Load("..\\..\\..\\..\\Content\\allBases.level");
            Load("..\\..\\..\\..\\Content\\empty.level");
        }

        private void Load(string filePath)
        {
            Stream inStream = File.OpenRead(filePath);
            BinaryReader input = new BinaryReader(inStream);

            int height = input.ReadInt32();
            int width = input.ReadInt32();
            //set enemy health to input.ReadInt32()
            //set enemy damage to input.ReadInt32()
            //set turret health to input.ReadInt32()
            //set enemy damage to input.ReadInt32()
            //set main structure health to input.ReadInt32()
            structures = new Structure[height, width];

            sideLength =(int)((screenHeight / height) * 0.8);

            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    switch (input.ReadInt32())
                    {
                        case 0:
                            structures[r, c] = null;
                            break;
                        case 1:
							structures[r, c] = new BasicTurret(new Vector2(
																(int)((screenWidth / 2) - ((9 - r) - 4.5) * sideLength), 
																(int)((screenHeight / 2) - ((9 - c) - 4.5) * sideLength)), 
                                                                turretTexture, bulletTexture,
                                                                sideLength);
							break;
                        case 2:
                            mainStructure = new MainStructure(new Vector2(
																(int)((screenWidth / 2) - ((9 - r) - 5) * sideLength), 
                                                                (int)((screenHeight / 2) - ((9 - c) - 5) * sideLength)), 
                                                                mainStructureTexture, 
                                                                sideLength * 2);
							structures[r, c] = mainStructure;

							break;
                    }
                }
            }
        }

        public void Update(List<Enemy> enemies)
        {
            foreach (Structure structure in structures)
            {
                if (structure != null)
                    structure.Update(enemies);
            }
        }

        public void Draw(SpriteBatch sp)
        {
            foreach (Structure structure in structures)
            {
                if (structure != null)
                    structure.Draw(sp);
            }
        }

		
    }
}

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

        public Map(int screenWidth, int screenHeight, Texture2D mainStructureTexture)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.mainStructureTexture = mainStructureTexture;

            Load();
        }

        private void Load()
        {
            Load("..\\..\\..\\..\\Content\\allBases.level");
            //Load("..\\..\\..\\..\\Content\\empty.level");
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

            for (int r = height - 1; r >= 0; r--)
            {
                for (int c = width - 1; c <= 0; c--)
                {
                    switch (input.ReadInt32())
                    {
                        case 0:
                            structures[r, c] = null;
                            break;
                        case 1:
							structures[r, c] = new MainStructure(new Vector2((int)((screenWidth / 2) - (r - 4.5) * sideLength), 
							                                    (int)((screenHeight / 2) - (c - 4.5) * sideLength)), 
                                                                mainStructureTexture, 
                                                                sideLength);
							break;
                        case 2:
                            mainStructure = new MainStructure(new Vector2((int)((screenWidth / 2) - (r - 4) * sideLength), 
                                                                (int)((screenHeight / 2) - (c - 4) * sideLength)), 
                                                                mainStructureTexture,
                                                                sideLength * 2);
							structures[r, c] = mainStructure;

							break;
                    }
                }
            }
        }

        public void Update()
        {
            foreach (Structure structure in structures)
            {
                if (structure != null)
                    structure.Update();
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

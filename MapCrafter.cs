using Substrate;
using Substrate.Core;
using System;
using System.Diagnostics;

namespace DwarvenRealms
{
    class MapCrafter
    {
        int mapCenterX, mapCenterY;
        int tilesPerRegionTile;
        int borderNorth, borderSouth, borderEast, borderWest;

        NbtWorld currentWorld;
        DwarfWorldMap currentDwarfMap;

        int maxHeight = -9999;
        int minHeight = 9999;

        public void simpleWriteTest()
        {
            currentWorld = AnvilWorld.Create("C:\\Users\\Japa\\AppData\\Roaming\\.minecraft\\saves\\testing\\");

            currentDwarfMap = new DwarfWorldMap();
            currentDwarfMap.loadElevationMap("D:\\DwarfFortress\\df_34_11_win\\world_graphic-el-region2-250-15510.bmp");
            currentDwarfMap.loadWaterMap("D:\\DwarfFortress\\df_34_11_win\\world_graphic-elw-region2-250-15510.bmp");
            currentDwarfMap.loadBiomeMap("D:\\DwarfFortress\\df_34_11_win\\world_graphic-bm-region2-250-15510.bmp");

            IChunkManager cm = currentWorld.GetChunkManager();

            // We can set different world parameters
            currentWorld.Level.LevelName = "Flatlands";
            currentWorld.Level.Spawn = new SpawnPoint(20, 255, 20);
            currentWorld.Level.GameType = GameType.CREATIVE;
            currentWorld.Level.AllowCommands = true;

            int cropWidth = 320;
            int cropHeight = 320;

            borderWest = 1088;
            borderEast = borderWest + cropWidth;

            borderNorth = 1024;
            borderSouth = borderNorth + cropHeight;

            tilesPerRegionTile = 4;
            mapCenterX = (borderWest + borderEast) / 2;
            mapCenterY = (borderNorth + borderSouth) / 2;

            //We have to split up the area we're working on into chunks.
            //We use X and Y because minecraft's coordinate system is just retarded.
            int chunkStartX = ((borderWest - mapCenterX) * tilesPerRegionTile) / 16;
            int chunkStartY = ((borderNorth - mapCenterY) * tilesPerRegionTile) / 16;
            int chunkFinishX = ((borderEast - mapCenterX) * tilesPerRegionTile) / 16;
            int chunkFinishY = ((borderSouth - mapCenterY) * tilesPerRegionTile) / 16;

            //int xmin = -20;
            //int xmax = 20;
            //int zmin = -20;
            //int zmaz = 20;
            // We'll create chunks at chunk coordinates xmin,zmin to xmax,zmax
            Console.WriteLine("Starting conversion now.");
            Stopwatch watch = Stopwatch.StartNew();
            for (int xi = chunkStartX; xi < chunkFinishX; xi++)
            {
                for (int zi = chunkStartY; zi < chunkFinishY; zi++)
                {
                    // This line will create a default empty chunk, and create a
                    // backing region file if necessary (which will immediately be
                    // written to disk)
                    ChunkRef chunk = cm.CreateChunk(xi, zi);

                    // This will make sure all the necessary things like trees and
                    // ores are generated for us.
                    chunk.IsTerrainPopulated = false;

                    // Auto light recalculation is horrifically bad for creating
                    // chunks from scratch, because we're placing thousands
                    // of blocks.  Turn it off.
                    chunk.Blocks.AutoLight = false;

                    double xMin = ((xi * 16.0 / (double)tilesPerRegionTile) + mapCenterX);
                    double xMax = (((xi + 1) * 16.0 / (double)tilesPerRegionTile) + mapCenterX);
                    double yMin = ((zi * 16.0 / (double)tilesPerRegionTile) + mapCenterY);
                    double yMax = (((zi + 1) * 16.0 / (double)tilesPerRegionTile) + mapCenterY);


                    // Make the terrain
                    HeightMapChunk(chunk, xMin, xMax, yMin, yMax);

                    // Reset and rebuild the lighting for the entire chunk at once
                    chunk.Blocks.RebuildHeightMap();
                    chunk.Blocks.RebuildBlockLight();
                    chunk.Blocks.RebuildSkyLight();

                    // Save the chunk to disk so it doesn't hang around in RAM
                    cm.Save();
                }
                TimeSpan elapsedTime = watch.Elapsed;
                int finished = xi - chunkStartX + 1;
                int left = chunkFinishX - xi - 1;
                TimeSpan remainingTime = TimeSpan.FromTicks(elapsedTime.Ticks / finished * left);
                Console.WriteLine("Built Chunk Row {0} of {1}. {2}:{3}:{4} elapsed, {5}:{6}:{7} remaining.",
                    finished, chunkFinishX - chunkStartX,
                    elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds,
                    remainingTime.Hours, remainingTime.Minutes, remainingTime.Seconds);
                maxHeight = -9999;
                minHeight = 9999;
            }

            // Save all remaining data (including a default level.dat)
            // If we didn't save chunks earlier, they would be saved here
            currentWorld.Save();


        }

        void HeightMapChunk(ChunkRef chunk, double mapXMin, double mapXMax, double mapYMin, double mapYMax)
        {
            for (int x = 0; x < 16; x++)
            {
                for (int z = 0; z < 16; z++)
                {
                    double mux = (mapXMax - mapXMin) * x / 16.0 + mapXMin;
                    double muy = (mapYMax - mapYMin) * z / 16.0 + mapYMin;
                    int height = (int)currentDwarfMap.getElevation(mux, muy) - 34;
                    int waterlevel = currentDwarfMap.getWaterbodyLevel((int)Math.Floor(mux - 0.5), (int)Math.Floor(muy - 0.5)) - 34;
                    if (height > maxHeight) maxHeight = height;
                    if (height < minHeight) minHeight = height;
                    int biomeIndex = currentDwarfMap.getBiome((int)Math.Floor(mux - 0.5), (int)Math.Floor(muy - 0.5));
                    chunk.Biomes.SetBiome(x, z, BiomeList.biomes[biomeIndex].mineCraftBiome);
                    //create bedrock
                    for (int y = 0; y < 2; y++)
                    {
                        chunk.Blocks.SetID(x, y, z, BlockType.BEDROCK);
                    }
                    // Create the rest, according to biome
                    for (int y = 2; y < height; y++)
                    {
                        if (y >= chunk.Blocks.YDim) break;
                        chunk.Blocks.SetID(x, y, z, BiomeList.biomes[biomeIndex].getBlockID(height - y, x + (chunk.X * 16), z + (chunk.Z * 16)));
                    }
                    // Create Oceans and lakes
                    for (int y = height; y < waterlevel; y++)
                    {
                        if (y < 2) continue;
                        if (y >= chunk.Blocks.YDim) break;
                        chunk.Blocks.SetID(x, y, z, BlockType.STATIONARY_WATER);
                    }
                }
            }
        }

        static void FlatChunk(ChunkRef chunk, int height)
        {
            // Create bedrock
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    for (int z = 0; z < 16; z++)
                    {
                        chunk.Blocks.SetID(x, y, z, (int)BlockType.BEDROCK);
                    }
                }
            }

            // Create stone
            for (int y = 2; y < height - 5; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    for (int z = 0; z < 16; z++)
                    {
                        chunk.Blocks.SetID(x, y, z, (int)BlockType.STONE);
                    }
                }
            }

            // Create dirt
            for (int y = height - 5; y < height - 1; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    for (int z = 0; z < 16; z++)
                    {
                        chunk.Blocks.SetID(x, y, z, (int)BlockType.DIRT);
                    }
                }
            }

            // Create grass
            for (int y = height - 1; y < height; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    for (int z = 0; z < 16; z++)
                    {
                        chunk.Blocks.SetID(x, y, z, (int)BlockType.GRASS);
                    }
                }
            }
        }
    }
}

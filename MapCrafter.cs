using Substrate;
using Substrate.Core;
using System;
using System.Diagnostics;
using DwarvenRealms.Properties;

namespace DwarvenRealms
{
    class MapCrafter
    {
        int shift = -35;

        NbtWorld currentWorld;
        DwarfWorldMap currentDwarfMap;
        CaveThing currentCaveMap;

        int maxHeight = -9999;
        int minHeight = 9999;

        /// <summary>
        /// Generates and saves a single minecraft chunk using current settings.
        /// </summary>
        /// <param name="xi">X coordinate of the chunk.</param>
        /// <param name="zi">Y coordinate of the chunk.</param>
        public void generateSingleChunk(int xi, int zi)
        {
            // This line will create a default empty chunk, and create a
            // backing region file if necessary (which will immediately be
            // written to disk)
            ChunkRef chunk = currentWorld.GetChunkManager().CreateChunk(xi, zi);

            // This will make sure all the necessary things like trees and
            // ores are generated for us.
            chunk.IsTerrainPopulated = false;

            // Auto light recalculation is horrifically bad for creating
            // chunks from scratch, because we're placing thousands
            // of blocks.  Turn it off.
            chunk.Blocks.AutoLight = false;

            double xMin = ((xi * 16.0 / (double)Settings.Default.blocksPerEmbarkTile) + Settings.Default.mapCenterX);
            double xMax = (((xi + 1) * 16.0 / (double)Settings.Default.blocksPerEmbarkTile) + Settings.Default.mapCenterX);
            double yMin = ((zi * 16.0 / (double)Settings.Default.blocksPerEmbarkTile) + Settings.Default.mapCenterY);
            double yMax = (((zi + 1) * 16.0 / (double)Settings.Default.blocksPerEmbarkTile) + Settings.Default.mapCenterY);


            // Make the terrain
            HeightMapChunk(chunk, xMin, xMax, yMin, yMax);

            // Reset and rebuild the lighting for the entire chunk at once
            chunk.Blocks.RebuildHeightMap();
            chunk.Blocks.RebuildBlockLight();
            chunk.Blocks.RebuildSkyLight();

            // Save the chunk to disk so it doesn't hang around in RAM
            currentWorld.GetChunkManager().Save();
        }

        public static int getChunkStartX() { return ((Settings.Default.borderWest - Settings.Default.mapCenterX) * Settings.Default.blocksPerEmbarkTile) / 16; }
        public static int getChunkStartY() { return ((Settings.Default.borderNorth - Settings.Default.mapCenterY) * Settings.Default.blocksPerEmbarkTile) / 16; }
        public static int getChunkFinishX() { return ((Settings.Default.borderEast - Settings.Default.mapCenterX) * Settings.Default.blocksPerEmbarkTile) / 16; }
        public static int getChunkFinishY() { return ((Settings.Default.borderSouth - Settings.Default.mapCenterY) * Settings.Default.blocksPerEmbarkTile) / 16; }

        public void loadDwarfMaps()
        {
            currentDwarfMap = new DwarfWorldMap();
            currentDwarfMap.loadElevationMap(Settings.Default.elevationMapPath);
            currentDwarfMap.loadWaterMap(Settings.Default.elevationWaterMapPath);
            currentDwarfMap.loadBiomeMap(Settings.Default.biomeMapPath);
            currentCaveMap = new CaveThing(currentDwarfMap);
        }

        public void initializeMinecraftWorld()
        {
            currentWorld = AnvilWorld.Create(Settings.Default.outputPath);

            // We can set different world parameters
            currentWorld.Level.LevelName = Settings.Default.levelName;
            currentWorld.Level.Spawn = new SpawnPoint(0, 255, 0);
            if (Settings.Default.gameMode == 0)
            {
                currentWorld.Level.GameType = GameType.SURVIVAL;
            }
            else
            {
                currentWorld.Level.GameType = GameType.CREATIVE;
                currentWorld.Level.AllowCommands = true;
            }
        }

        public void saveMinecraftWorld()
        {
            // Save all remaining data (including a default level.dat)
            // If we didn't save chunks earlier, they would be saved here
            currentWorld.Save();
        }

        public void simpleWriteTest()
        {
            initializeMinecraftWorld();
            IChunkManager cm = currentWorld.GetChunkManager();

            loadDwarfMaps();



            int cropWidth = 40;
            int cropHeight = 40;

            Settings.Default.borderWest = 40;
            Settings.Default.borderEast = Settings.Default.borderWest + cropWidth;

            Settings.Default.borderNorth = 40;
            Settings.Default.borderSouth = Settings.Default.borderNorth + cropHeight;

            //FIXME get rid of this junk
            Settings.Default.mapCenterX = (Settings.Default.borderWest + Settings.Default.borderEast) / 2;
            Settings.Default.mapCenterY = (Settings.Default.borderNorth + Settings.Default.borderSouth) / 2;


            Console.WriteLine("Starting conversion now.");
            Stopwatch watch = Stopwatch.StartNew();
            for (int xi = getChunkStartX(); xi < getChunkFinishX(); xi++)
            {
                for (int zi = getChunkStartY(); zi < getChunkFinishY(); zi++)
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

                    double xMin = ((xi * 16.0 / (double)Settings.Default.blocksPerEmbarkTile) + Settings.Default.mapCenterX);
                    double xMax = (((xi + 1) * 16.0 / (double)Settings.Default.blocksPerEmbarkTile) + Settings.Default.mapCenterX);
                    double yMin = ((zi * 16.0 / (double)Settings.Default.blocksPerEmbarkTile) + Settings.Default.mapCenterY);
                    double yMax = (((zi + 1) * 16.0 / (double)Settings.Default.blocksPerEmbarkTile) + Settings.Default.mapCenterY);


                    // Make the terrain
                    HeightMapChunk(chunk, xMin, xMax, yMin, yMax);

                    // Reset and rebuild the lighting for the entire chunk at once
                    chunk.Blocks.RebuildHeightMap();
                    if (Settings.Default.lightGenerationEnable)
                    {
                        chunk.Blocks.RebuildBlockLight();
                        chunk.Blocks.RebuildSkyLight();
                    }

                    // Save the chunk to disk so it doesn't hang around in RAM
                    cm.Save();
                }
                //TimeSpan elapsedTime = watch.Elapsed;
                //int finished = xi - chunkStartX + 1;
                //int left = chunkFinishX - xi - 1;
                //TimeSpan remainingTime = TimeSpan.FromTicks(elapsedTime.Ticks / finished * left);
                //Console.WriteLine("Built Chunk Row {0} of {1}. {2}:{3}:{4} elapsed, {5}:{6}:{7} remaining.",
                //    finished, chunkFinishX - chunkStartX,
                //    elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds,
                //    remainingTime.Hours, remainingTime.Minutes, remainingTime.Seconds);
                maxHeight = int.MinValue;
                minHeight = int.MaxValue;
            }

            saveMinecraftWorld();
        }

        void HeightMapChunk(ChunkRef chunk, double mapXMin, double mapXMax, double mapYMin, double mapYMax)
        {
            for (int x = 0; x < 16; x++)
            {
                for (int z = 0; z < 16; z++)
                {
                    double mux = (mapXMax - mapXMin) * x / 16.0 + mapXMin;
                    double muy = (mapYMax - mapYMin) * z / 16.0 + mapYMin;
                    int height = (int)currentDwarfMap.getElevation(mux, muy) + shift;
                    int caveCeiling = currentCaveMap.getCaveCeiling(mux, muy) + shift;
                    int caveFloor = currentCaveMap.getCaveFloor(mux, muy) + shift;
                    int waterLevel = currentDwarfMap.getWaterbodyLevel((int)Math.Floor(mux + 0.5), (int)Math.Floor(muy + 0.5)) + shift;
                    int riverLevel = currentDwarfMap.getRiverLevel((int)Math.Floor(mux + 0.5), (int)Math.Floor(muy + 0.5)) + shift;
                    if (height > maxHeight) maxHeight = height;
                    if (height < minHeight) minHeight = height;
                    int biomeIndex = currentDwarfMap.getBiome((int)Math.Floor(mux + 0.5), (int)Math.Floor(muy + 0.5));
                    chunk.Biomes.SetBiome(x, z, BiomeList.biomes[biomeIndex].mineCraftBiome);
                    //create bedrock
                    for (int y = 0; y < 2; y++)
                    {
                        chunk.Blocks.SetID(x, y, z, BlockType.BEDROCK);
                    }
                    //deal with rivers
                    if (riverLevel >= 0)
                    {
                        chunk.Biomes.SetBiome(x, z, BiomeType.River);
                        height = riverLevel;
                        for (int y = 0; y < height - 2; y++)
                        {
                            chunk.Blocks.SetID(x, y, z, BlockType.STONE);
                        }
                        for (int y = height - 2; y < height - 1; y++)
                        {
                            chunk.Blocks.SetID(x, y, z, BlockType.GRAVEL);
                        }
                        for (int y = height - 1; y < height; y++)
                        {
                            chunk.Blocks.SetID(x, y, z, BlockType.WATER);
                        }
                    }
                    else if (BiomeList.biomes[biomeIndex].mineCraftBiome == BiomeID.DeepOcean && waterLevel <= height)
                    {
                        //make beaches
                        chunk.Biomes.SetBiome(x, z, BiomeType.Beach);
                        height = 98 + shift;
                        for (int y = 0; y < height - 4; y++)
                        {
                            chunk.Blocks.SetID(x, y, z, BlockType.STONE);
                        }
                        for (int y = height - 4; y < height - 3; y++)
                        {
                            chunk.Blocks.SetID(x, y, z, BlockType.SANDSTONE);
                        }
                        for (int y = height - 3; y < height; y++)
                        {
                            chunk.Blocks.SetID(x, y, z, BlockType.SAND);
                        }

                    }
                    else
                    {
                        // Create the rest, according to biome
                        for (int y = 2; y < height; y++)
                        {
                            if (y >= chunk.Blocks.YDim) break;
                            chunk.Blocks.SetID(x, y, z, BiomeList.biomes[biomeIndex].getBlockID(height - y, x + (chunk.X * 16), z + (chunk.Z * 16)));
                        }
                    }
                    // Create Oceans and lakes
                    for (int y = height; y < waterLevel; y++)
                    {
                        if (y < 2) continue;
                        if (y >= chunk.Blocks.YDim) break;
                        chunk.Blocks.SetID(x, y, z, BlockType.STATIONARY_WATER);
                    }
                    //hollow out caves
                    if (caveFloor < caveCeiling)
                        for (int y = caveFloor - 1; y < caveCeiling; y++)
                        {
                            if (y < 2) continue;
                            if (y >= chunk.Blocks.YDim) break;
                            if (y == caveFloor - 1)
                                chunk.Blocks.SetID(x, y, z, BlockType.MYCELIUM);
                            else
                                chunk.Blocks.SetID(x, y, z, BlockType.AIR);
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

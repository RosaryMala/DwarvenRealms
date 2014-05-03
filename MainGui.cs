using DwarvenRealms.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace DwarvenRealms
{
    public partial class MainGui : Form
    {
        MapCrafter mc = new MapCrafter();
        int totalChunks, doneChunks;
        public MainGui()
        {
            InitializeComponent();
            minecraftSaveTextBox.Text = Settings.Default.outputPath;
            elevationMapPathTextBox.Text = Settings.Default.elevationMapPath;
            elevationWaterMapPathTextBox.Text = Settings.Default.elevationWaterMapPath;
            biomeMapPathTextBox.Text = Settings.Default.biomeMapPath;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\saves";
            minecraftSaveSelector.SelectedPath = path;
        }

        private void MapGenerationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            MapCrafter craft = e.Argument as MapCrafter;
            mapGenerationWorker.ReportProgress(0,"Initializing Minecraft Realm...");
            craft.initializeMinecraftWorld();
            mapGenerationWorker.ReportProgress(0,"Loading Dorf Maps...");
            craft.loadDwarfMaps();
            totalChunks = (MapCrafter.getChunkFinishX() - MapCrafter.getChunkStartX()) *
                 (MapCrafter.getChunkFinishY() - MapCrafter.getChunkStartY());
            doneChunks = 0;
            Stopwatch watch = Stopwatch.StartNew();
            Stopwatch unitTime = new Stopwatch();
            for (int xi = MapCrafter.getChunkStartX(); xi < MapCrafter.getChunkFinishX(); xi++)
            {
                for (int zi = MapCrafter.getChunkStartY(); zi < MapCrafter.getChunkFinishY(); zi++)
                {
                    if (mapGenerationWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }
                    unitTime.Restart();
                    craft.generateSingleChunk(xi, zi);
                    doneChunks++;
                    TimeSpan elapsedTime = watch.Elapsed;
                    TimeSpan remainingTime = TimeSpan.FromTicks(elapsedTime.Ticks / doneChunks * (totalChunks - doneChunks));
                    double speed = 1000 / unitTime.ElapsedMilliseconds;
                    mapGenerationWorker.ReportProgress((doneChunks * 1000) / totalChunks, "Done " + doneChunks + " out of " + totalChunks + " Minecraft chunks at " + speed + " chunks per second. " + remainingTime.ToString(@"hh\:mm\:ss") + " left.");
                }
                if (mapGenerationWorker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
            }
            craft.saveMinecraftWorld();
        }

        private void MapGenerationWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MapGenerationProgressBar.Value = e.ProgressPercentage;
            MapGenerationProgressLable.Text = e.UserState as string;
        }

        private void MapGenerationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MapGenerationStartButton.Enabled = true;
            MapGenerationAbortButton.Enabled = false;
            if (e.Cancelled)
                MapGenerationProgressLable.Text = "Aborted map generation.";
            else
                MapGenerationProgressLable.Text = "Done! Hopefully.";
        }

        private void MapGenerationStartButton_Click(object sender, EventArgs e)
        {
            MapGenerationStartButton.Enabled = false;
            MapGenerationAbortButton.Enabled = true;
            mapGenerationWorker.RunWorkerAsync(mc);
        }

        private void MapGenerationAbortButton_Click(object sender, EventArgs e)
        {
            mapGenerationWorker.CancelAsync();
        }

        private void minecraftSaveButton_Click(object sender, EventArgs e)
        {
            DialogResult result = minecraftSaveSelector.ShowDialog();
            if(result == DialogResult.OK)
            {
                minecraftSaveTextBox.Text = minecraftSaveSelector.SelectedPath;
            }
        }

        private void minecraftSaveTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.outputPath = minecraftSaveTextBox.Text;
            Console.WriteLine("Output path changed to " + Settings.Default.outputPath);
        }

        private void elevationMapPathTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.elevationMapPath = elevationMapPathTextBox.Text;
            Console.WriteLine("Elevation map path changed to " + Settings.Default.elevationMapPath);
        }

        private void elevationMapLoadButton_Click(object sender, EventArgs e)
        {
            DialogResult result = elevationMapFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                elevationMapPathTextBox.Text = elevationMapFileDialog.FileName;
            }
        }

        private void biomeMapPathTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.biomeMapPath = biomeMapPathTextBox.Text;
            Console.WriteLine("Biome map path changed to " + Settings.Default.biomeMapPath);
        }

        private void elevationWaterMapPathTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.elevationWaterMapPath = elevationWaterMapPathTextBox.Text;
            Console.WriteLine("Elevation water map path changed to " + Settings.Default.elevationWaterMapPath);
        }

        private void elevationWaterMapLoadButton_Click(object sender, EventArgs e)
        {
            DialogResult result = elevationWaterMapFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                elevationWaterMapPathTextBox.Text = elevationWaterMapFileDialog.FileName;
            }
        }

        private void biomeMapLoadButton_Click(object sender, EventArgs e)
        {
            DialogResult result = biomeMapFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
               biomeMapPathTextBox.Text = biomeMapFileDialog.FileName;
            }
        }
    }
}

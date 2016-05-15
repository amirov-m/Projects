using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.MediaFoundation;

namespace MusicalPlayer
{
    public partial class PlayerForm : Form
    {
        public PlayerForm()
        {
            InitializeComponent();
            AddWidgets();
        }

        private NAudio.Wave.WaveFileReader wave = null;
        private NAudio.Wave.DirectSoundOut output = null;

        private Button chooseFileButton;
        private Button playPauseButton;

        private void AddWidgets()
        {
            AddChooseFileButton();
            AddPlayPauseButton();
            AddIncreaseVolumeButton();
            AddDecreaseVolumeButton();
        }

        private void AddIncreaseVolumeButton()
        {
            Button increaseVolume = new Button();
            increaseVolume.Text = "+";
            increaseVolume.Left = 100;
            increaseVolume.Top = 10;

            increaseVolume.Click += new EventHandler(IncreaseVolumeButton_OnClick);

            this.Controls.Add(increaseVolume);
        }

        private void IncreaseVolumeButton_OnClick(object sender, EventArgs eventArgs)
        {
            output.PlaybackPosition.Add(TimeSpan.FromSeconds(10));
        }

        private void AddDecreaseVolumeButton()
        {
            Button decreaseVolume = new Button();
            decreaseVolume.Text = "-";
            decreaseVolume.Left = 100;
            decreaseVolume.Top = 40;

            this.Controls.Add(decreaseVolume);
        }

        private void AddPlayPauseButton()
        {
            playPauseButton = new Button();
            playPauseButton.Top = 40;
            playPauseButton.Left = 10;
            playPauseButton.Text = "Play/Pause";
            playPauseButton.Enabled = false;

            playPauseButton.Click += new System.EventHandler(PlayPauseButton_OnClick);

            this.Controls.Add(playPauseButton);
        }

        private void AddChooseFileButton()
        {
            chooseFileButton = new Button();
            chooseFileButton.Text = "Open WAV";
            chooseFileButton.Top = 10;
            chooseFileButton.Left = 10;

            chooseFileButton.Click += new System.EventHandler(ChooseFileButton_OnClick);

            this.Controls.Add(chooseFileButton);
        }

        private void ChooseFileButton_OnClick(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Wave File (*.wav)|*.wav;";
            if (open.ShowDialog() != DialogResult.OK) return;

            DisposeWave();

            wave = new NAudio.Wave.WaveFileReader(open.FileName);
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(new NAudio.Wave.WaveChannel32(wave));
            output.Play();

            playPauseButton.Enabled = true;

        }

        private void PlayPauseButton_OnClick(object sender, EventArgs e)
        {
            if (output != null)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing)
                    output.Pause();
                else if (output.PlaybackState == NAudio.Wave.PlaybackState.Paused)
                    output.Play();
            }
        }

        private void DisposeWave()
        {
            if (output != null)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing) output.Stop();
                output.Dispose();
                output = null;
            }
            if (wave != null)
            {
                wave.Dispose();
                wave = null;
            }
        }
    }
}

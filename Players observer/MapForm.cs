using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Players_observer
{
    public partial class MapForm : Form
    {
        private Observer Observer = new Observer();
        private int CurrentMapZoneID;
        private List<RectangleF> PlayersInZone = new List<RectangleF>();
        private RectangleF ObservedPlayer = new RectangleF();
        public delegate void MapFormHiding();
        public event MapFormHiding HidingCompleted;

        public MapForm()
        {
            InitializeComponent();
            CurrentMapZoneID = Observer.CurrentZoneID;
            MapPictureBox.Image = Image.FromFile("Maps/" + CurrentMapZoneID.ToString() + ".png");
            var MapsList = Observer.GetMapsList();
            MapsListComboBox.DataSource = MapsList;
            MapsListComboBox.ValueMember = "ZoneID";
            MapsListComboBox.DisplayMember = "ZoneName";
            MapsListComboBox.SelectedIndex = MapsList.FindIndex(m => m.ZoneID == Observer.CurrentZoneID);
        }

        private void MapFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                CancelObservation();
                HidingCompleted();
            }
        }

        internal void AddPlayer(string UserID, int ZoneID, float X, float Z, float Y)
        {
            Observer.AddPlayer(UserID, ZoneID, X, Z, Y);
        }

        internal void UpdatePlayer(string UserID, int ZoneID, float X, float Z, float Y)
        {
            Observer.UpdatePlayer(UserID, ZoneID, X, Z, Y);

            if (Observer.ObservedUserID == UserID)
            {
                if (Observer.CurrentZoneID != ZoneID)
                {
                    Observer.CurrentZoneID = ZoneID;
                    var MapsList = Observer.GetMapsList();
                    MapsListComboBox.SelectedIndex = MapsList.FindIndex(m => m.ZoneID == ZoneID);
                    ZoneIDTextBox.Text = Observer.GetMapsList().FindIndex(m => m.ZoneID == ZoneID).ToString();
                }

                PositionXTextBox.Text = X.ToString();
                PositionZTextBox.Text = Z.ToString();
                PositionYTextBox.Text = Y.ToString();
            }
        }

        internal void RemovePlayer(string UserID)
        {
            Observer.RemovePlayer(UserID);

            if (Observer.ObservedUserID == UserID)
            {
                CancelObservation();
            }
        }

        internal void ObservePlayer(string UserID)
        {
            var PlayerInfo = Observer.GetPlayerInfo(UserID);

            if (PlayerInfo != null)
            {
                var MapsList = Observer.GetMapsList();
                Observer.CurrentZoneID = PlayerInfo.ZoneID;
                Observer.ObservedUserID = PlayerInfo.UserID;
                MapsListComboBox.SelectedIndex = MapsList.FindIndex(m => m.ZoneID == Observer.CurrentZoneID);
                UserIDTextBox.Text = UserID;
                ZoneIDTextBox.Text = PlayerInfo.ZoneID.ToString();
                PositionXTextBox.Text = PlayerInfo.X.ToString();
                PositionZTextBox.Text = PlayerInfo.Z.ToString();
                PositionYTextBox.Text = PlayerInfo.Y.ToString();
                StopObservingButton.Enabled = true;

                if (Visible == false)
                {
                    Visible = true;
                }
            }
        }

        internal void CancelObservation()
        {
            Observer.ObservedUserID = null;
            UserIDTextBox.Text = ZoneIDTextBox.Text = PositionXTextBox.Text = PositionYTextBox.Text = PositionZTextBox.Text = "";
            StopObservingButton.Enabled = false;
            ActiveControl = null;
        }

        internal void UpdateMap()
        {
            // TODO: In the future implement an animate players movement if nessesery
            PlayersInZone.Clear();
            ObservedPlayer = new RectangleF();
            var Players = Observer.GetPlayers(Observer.CurrentZoneID);

            if (Players.Count > 0)
            {
                int MapSize = Observer.GetMapSize(Observer.CurrentZoneID);
                float Delta = MapSize / (float)MapPictureBox.Width;

                // With a tolerance of ± 1 pixel 
                foreach (var Player in Players)
                {
                    if (Player.UserID != Observer.ObservedUserID)
                    {
                        PlayersInZone.Add(new RectangleF(Player.X / Delta, (MapSize - Player.Z) / Delta, 3f, 3f));
                    }
                    else
                    {
                        ObservedPlayer = new RectangleF(Player.X / Delta, (MapSize - Player.Z) / Delta, 3f, 3f);
                    }
                }
            }
            
            MapPictureBox.Invalidate(false);
        }

        internal void ClearPlayersList()
        {
            Observer.ClearPlayersList();
        }

        private void MapPictureBoxPaint(object sender, PaintEventArgs e)
        {
            // TODO: In the future you might consider adding some type of tooltip when hovering over the player
            // TODO: In the future you might consider adding player tracking by double-clicking on a point on map
            SuspendLayout();

            if (Observer.CurrentZoneID != CurrentMapZoneID)
            {
                CurrentMapZoneID = Observer.CurrentZoneID;
                string Path = "Maps/" + CurrentMapZoneID.ToString() + ".png";

                if (File.Exists(Path))
                {
                    MapPictureBox.Image = Image.FromFile(Path);
                }
                else
                {
                    MapPictureBox.Image = Image.FromFile("Maps/Unknown.png");
                }
            }

            if (PlayersInZone.Count > 0)
            {
                e.Graphics.FillRectangles(Brushes.Red, PlayersInZone.ToArray());
            }

            if (!ObservedPlayer.IsEmpty)
            {
                e.Graphics.FillRectangle(Brushes.Lime, ObservedPlayer);
            }

            ResumeLayout(false);
        }

        private void MapsListSelectionChangeCommitted(object sender, EventArgs e)
        {
            // If in doubt use the int.TryParse() construct 
            int ZoneID = Convert.ToInt32(MapsListComboBox.SelectedValue);

            if (Observer.CurrentZoneID != ZoneID)
            {
                Observer.CurrentZoneID = ZoneID;
                CancelObservation();
            }
        }

        private void StopObservingButtonClick(object sender, EventArgs e)
        {
            CancelObservation();
        }
    }
}
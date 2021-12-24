using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Players_observer
{
    public partial class MainForm : Form
    {
        private ProcessMemoryReader ProcessMemoryReader;
        private int MaxServerUsers, CurrentlyFreeUsersSlots, CurrentlyConnectedUsers, CurrentlyConnectedUsersInGame, ConnectionsListAddress;
        private Timer Updater = new Timer(100);
        private MapForm MapForm = new MapForm();

        public MainForm()
        {
            InitializeComponent();            
            Updater.AutoReset = true;
            Updater.SynchronizingObject = this;
            Updater.Elapsed += UpdateUsersList;
            MapForm.HidingCompleted += DisableOpenMapForm;
        }

        private void ObserveButtonClick(object sender, EventArgs e)
        {
            if (!Updater.Enabled)
            {
                ProcessMemoryReader = new ProcessMemoryReader("Ebenezer");
                MaxServerUsers = ProcessMemoryReader.ReadInt(ProcessMemoryReader.BaseAddress + 0x282810);
                ConnectionsListAddress = ProcessMemoryReader.ReadInt(ProcessMemoryReader.BaseAddress + 0x282824);
                ObserveButton.Text = "Stop";
                OpenMapButton.Enabled = true;
                Updater.Enabled = true;
            }
            else
            {
                ObserveButton.Text = "Observe";
                OpenMapButton.Enabled = false;
                ServerStatisticsLabel.Text = "";
                Updater.Enabled = false;
                UsersList.Rows.Clear();
                MapForm.CancelObservation();
                MapForm.ClearPlayersList();

                if(MapForm.Visible)
                {
                    MapForm.Hide();
                }
            }
        }

        private void OpenMapButtonClick(object sender, EventArgs e)
        {
            MapForm.Show();

            if (!MapForm.Focused)
            {
                MapForm.Focus();
            }

            OpenMapButton.Enabled = false;
        }

        private void UpdateUsersList(object sender, ElapsedEventArgs e)
        {
            CurrentlyFreeUsersSlots = ProcessMemoryReader.ReadInt(ProcessMemoryReader.BaseAddress + 0x282820);
            CurrentlyConnectedUsers = MaxServerUsers - CurrentlyFreeUsersSlots;

            foreach (DataGridViewRow Row in UsersList.Rows)
            {
                Row.Cells["IsUpdated"].Value = null;
            }

            if (CurrentlyConnectedUsers > 0)
            {
                for (int IndexElement = 0, ReadedPlayers = 0, MaxOffset = MaxServerUsers * 4; IndexElement < MaxOffset || ReadedPlayers < CurrentlyConnectedUsers; IndexElement += 4)
                {
                    int ConnectionAddress = ProcessMemoryReader.ReadInt(ConnectionsListAddress + IndexElement);

                    if (ConnectionAddress != 0)
                    {
                        bool IsInGame = ProcessMemoryReader.ReadByte(ConnectionAddress + 0x8055) == 0x03;

                        if (IsInGame)
                        {
                            int UserDataAddress = ProcessMemoryReader.ReadInt(ConnectionAddress + 0x8098);
                            byte[] UserID = ProcessMemoryReader.ReadBytes(UserDataAddress, 21);
                            byte[] AccountID = ProcessMemoryReader.ReadBytes(UserDataAddress + 0x15, 21);
                            int ZoneID = ProcessMemoryReader.ReadInt(UserDataAddress + 0x3C);
                            float PX = ProcessMemoryReader.ReadFloat(UserDataAddress + 0x40);
                            float PZ = ProcessMemoryReader.ReadFloat(UserDataAddress + 0x44);
                            float PY = ProcessMemoryReader.ReadFloat(UserDataAddress + 0x48);
                            string strUserID = Encoding.ASCII.GetString(UserID).TrimEnd('\0');

                            var Row = UsersList.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.Cells["Offset"].Value.Equals((object)IndexElement));

                            if (Row != null)
                            {
                                Row.Cells["IsUpdated"].Value = true;
                                Row.Cells["ZoneID"].Value = ZoneID;
                                Row.Cells["X"].Value = PX;
                                Row.Cells["Z"].Value = PZ;
                                Row.Cells["Y"].Value = PY;
                                MapForm.UpdatePlayer(strUserID, ZoneID, PX, PZ, PY);
                            }
                            else
                            {

                                int IndexList = UsersList.Rows.Add();
                                UsersList.Rows[IndexList].Cells["Offset"].Value = IndexElement;
                                UsersList.Rows[IndexList].Cells["IsUpdated"].Value = true;
                                UsersList.Rows[IndexList].Cells["AccountID"].Value = Encoding.ASCII.GetString(AccountID).TrimEnd('\0');
                                UsersList.Rows[IndexList].Cells["UserID"].Value = strUserID;
                                UsersList.Rows[IndexList].Cells["ZoneID"].Value = ZoneID;
                                UsersList.Rows[IndexList].Cells["X"].Value = PX;
                                UsersList.Rows[IndexList].Cells["Z"].Value = PZ;
                                UsersList.Rows[IndexList].Cells["Y"].Value = PY;
                                MapForm.AddPlayer(strUserID, ZoneID, PX, PZ, PY);
                            }
                        }

                        ++ReadedPlayers;
                    } 
                }
            }

            foreach (DataGridViewRow Row in UsersList.Rows)
            {
                if(Row.Cells["IsUpdated"].Value == null)
                {
                    MapForm.RemovePlayer(Row.Cells["UserID"].Value.ToString());
                    UsersList.Rows.RemoveAt(Row.Index);
                }
            }
            
            CurrentlyConnectedUsersInGame = UsersList.Rows.Count;
            ServerStatisticsLabel.Text = CurrentlyConnectedUsersInGame.ToString() + " / (" + CurrentlyFreeUsersSlots.ToString() + ") " + MaxServerUsers.ToString();
            MapForm.UpdateMap();
        }

        private void UsersListCellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                MapForm.ObservePlayer(UsersList.Rows[e.RowIndex].Cells["UserID"].Value.ToString());
                OpenMapButton.Enabled = false;
            }
        }

        private void DisableOpenMapForm()
        {
            OpenMapButton.Enabled = true;
        }
    }
}
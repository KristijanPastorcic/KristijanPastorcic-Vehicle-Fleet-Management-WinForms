using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Vehicle_Fleet_Management.Forms;
using Vehicle_Fleet_Management.Helpers;
using Vehicle_Fleet_Management.Models;
using Vehicle_Fleet_Management.Repositoryes;

namespace Vehicle_Fleet_Management
{
    public partial class Main : Form
    {
        private readonly string FILE = Application.StartupPath + "\\bak.xml";
        private string cs { get; }
            = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private IDriversRepository DriversRepository { get; }
        private IVehiclesRepository VehiclesRepository { get; }
        private ITravelWarrentsRepository TravelWarrentsRepository { get; }
        private IList<TravelWarrantState> TravelWarrantStates { get; set; } =
            TravelWarrantState.GetTravelWarrantStates().ToList();
        private IList<TravelWarrent> TravelWarrents { get; set; }


        private IList<Vehicle> Vehicles { get; set; }
        private IList<Driver> Drivers { get; set; }
        public Main()
        {
            InitializeComponent();
            DriversRepository = Factories.RepositoryFactory.GetDriversRepository(cs);
            VehiclesRepository = Factories.RepositoryFactory.GetVehiclesRepository(cs);
            TravelWarrentsRepository = Factories.RepositoryFactory.GetTravelWarrentsRepository(cs);
        }
        private void Main_Load(object sender, EventArgs e)
        {
            init();
            TravelWarrentsRepository.TravelWarrents_InfoMessage += TravelWarrent_Info;
        }

        private void init()
        {
            TravelWarrents = TravelWarrentsRepository.GetTravelWarrents().ToList();
            Vehicles = VehiclesRepository.GetVehicles().ToList();
            Drivers = DriversRepository.GetDrivers().ToList();


            lbWarrents.DataSource = TravelWarrents;
            cbDrivers.DataSource = Drivers;

            // select driwers that are not on any warrent, selected driver for warent
            cbWarrentDrivers.DataSource = Drivers;

            // get free vehicles
            //cbWarrentVehicle.DataSource = Vehicles
            // .Where(v => TravelWarrents.Any(tw => v.IDVehicle == tw.FK_Vehicles)).ToList();
            cbWarrentVehicle.DataSource = Vehicles;

            // selected state for warrent
            cbWarrentState.DataSource = TravelWarrantStates;
        }
        private void TravelWarrent_Info(object sender, SqlInfoMessageEventArgs e)
        {
            lblMessage.Text += $"{Environment.NewLine}Sql server info message--{e.Message}";
        }

        private void btnDrivers_Click(object sender, EventArgs e)
        {
            var f = new DriversForm(DriversRepository);
            f.Disposed += F_Disposed;
            f.Show();
        }

        private void F_Disposed(object sender, EventArgs e) => init();

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            var f = new VehiclesForm(VehiclesRepository);
            f.Disposed += F_Disposed;
            f.Show();
        }

        private void rbOpen_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOpen.Checked)
            {
                lbWarrents.DataSource = TravelWarrents
                    .Where(w => w.FK_TravelWarrantStates == (int)TravelWarrantState.EnumState.Open).ToList();
            }
        }

        private void rbClosed_CheckedChanged(object sender, EventArgs e)
        {
            if (rbClosed.Checked)
            {
                lbWarrents.DataSource = TravelWarrents
                    .Where(w => w.FK_TravelWarrantStates == (int)TravelWarrantState.EnumState.Closed).ToList();
            }
        }

        private void rbFuture_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFuture.Checked)
            {
                lbWarrents.DataSource = TravelWarrents
                    .Where(w => w.FK_TravelWarrantStates == (int)TravelWarrantState.EnumState.Future).ToList();
            }
        }

        private void rbAllStates_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAllStates.Checked)
            {
                lbWarrents.DataSource = TravelWarrents;
            }
        }

        private void lbWarrents_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowTravelWarrentData();
        }

        private void ShowTravelWarrentData()
        {
            TravelWarrent warrent = lbWarrents.SelectedItem as TravelWarrent;
            dtWarrent.Value = warrent.DateCreated;
            cbWarrentDrivers.SelectedItem = Drivers.First(d => d.IDDriver == warrent.FK_Drivers);
            cbWarrentVehicle.SelectedItem = Vehicles.First(v => v.IDVehicle == warrent.FK_Vehicles);
            cbWarrentState.SelectedItem =
                TravelWarrantStates.First(s => s.IDTravelWarrantState == warrent.FK_TravelWarrantStates);
            tbWarrentDescription.Text = warrent.RouteDescription;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show($"Are you sure to delete warrent and all of its data",
                                 "Confirm Delete!!",
                                 MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
                return;
                try
                {
                    bool deleted = TravelWarrentsRepository.
                        DeleteTravelWarrent((lbWarrents.SelectedItem as TravelWarrent).IDTravelWarrent);
                    if (deleted)
                    {
                        lblMessage.Text = "Warrent deleted";
                    RefreshForm();
                    }
                }
                catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                TravelWarrentsRepository
                    .UpdateTravelWarrent(new TravelWarrent()
                    {
                        IDTravelWarrent = (lbWarrents.SelectedItem as TravelWarrent).IDTravelWarrent,
                        RouteDescription = tbWarrentDescription.Text,
                        DateCreated = dtWarrent.Value,
                        FK_Drivers = (cbWarrentDrivers.SelectedItem as Driver).IDDriver,
                        FK_Vehicles = (cbWarrentVehicle.SelectedItem as Vehicle).IDVehicle,
                        FK_TravelWarrantStates = (cbWarrentState.SelectedItem as TravelWarrantState).IDTravelWarrantState
                    });
                RefreshForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                TravelWarrentsRepository.CreateTravelWarrent(
                        new TravelWarrent()
                        {
                            RouteDescription = tbWarrentDescription.Text,
                            DateCreated = dtWarrent.Value,
                            FK_Drivers = (cbWarrentDrivers.SelectedItem as Driver).IDDriver,
                            FK_Vehicles = (cbWarrentVehicle.SelectedItem as Vehicle).IDVehicle,
                            FK_TravelWarrantStates = (cbWarrentState.SelectedItem as TravelWarrantState).IDTravelWarrantState
                        });
                RefreshForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRoutes_Click(object sender, EventArgs e)
        {
            new RoutesForm(lbWarrents.SelectedItem as TravelWarrent).Show();
        }

        private void RefreshForm()
        {
            TravelWarrents = TravelWarrentsRepository.GetTravelWarrents().ToList();
            lbWarrents.DataSource = TravelWarrents;
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                XmlHelper.CreateBackupXml(FILE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                XmlHelper.RestoreDbFromXml(FILE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

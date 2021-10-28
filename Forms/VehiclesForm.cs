using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vehicle_Fleet_Management.Models;
using Vehicle_Fleet_Management.Repositoryes;

namespace Vehicle_Fleet_Management.Forms
{
    partial class VehiclesForm : Form
    {
        private IEnumerable<Control> ValidationFields { get; set; }
        private IVehiclesRepository Repository { get; }
        public VehiclesForm(IVehiclesRepository vehicleRepository)
        {
            InitializeComponent();
            Repository = vehicleRepository;
            ValidationFields = new List<Control>()
            {
                tbType, tbYear, tbManufacturer, tbKilometers
            };
        }

        private void VehiclesForm_Load(object sender, EventArgs e)
        {
            try
            {
                lbVehicles.DataSource = Repository.GetVehicles().ToList();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Vehicle vehicle = lbVehicles.SelectedItem as Vehicle;
                var confirmResult = MessageBox.Show(
                    $"Are you sure to delete {vehicle}",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    if (Repository.DeleteVehicle(vehicle.IDVehicle))
                    {
                        lblMessage.Text = $"{vehicle} has been deleted";
                        RefreshForm();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!FormValid())
            {
                lblMessage.Text = "Form not valid";
                return;
            }

            try
            {
                Vehicle vehicle = new Vehicle()
                {
                    Type = tbType.Text.Trim(),
                    Manufacturer = tbManufacturer.Text.Trim(),
                    Year = int.Parse(tbYear.Text.Trim()),
                    Kilometers = int.Parse(tbKilometers.Text.Trim())
                };

                if (Repository.CreateVehicle(vehicle))
                {
                    lblMessage.Text = $"{vehicle} created";
                    RefreshForm();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!FormValid())
            {
                lblMessage.Text = "Form not valid";
                return;
            }
            try
            {
                Vehicle vehicle = lbVehicles.SelectedItem as Vehicle;

                vehicle.Type = tbType.Text.Trim();
                vehicle.Manufacturer = tbManufacturer.Text.Trim();
                vehicle.Kilometers = int.Parse(tbKilometers.Text.Trim());
                vehicle.Year = int.Parse(tbYear.Text.ToString());

                if (Repository.UpdateVehicle(vehicle))
                {
                    lblMessage.Text = $"{vehicle} has been updated";
                    RefreshForm();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void lbVehicles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vehicle vehicle = lbVehicles.SelectedItem as Vehicle;
            tbYear.Text = vehicle.Year.ToString();
            tbType.Text = vehicle.Type;
            tbManufacturer.Text = vehicle.Manufacturer;
            tbKilometers.Text = vehicle.Kilometers.ToString();
        }

        private void RefreshForm()
        {
            lbVehicles.DataSource = Repository.GetVehicles().ToList();
            tbKilometers.Text = string.Empty;
            tbManufacturer.Text = string.Empty;
            tbType.Text = string.Empty;
            tbYear.Text = string.Empty;
        }

        private bool FormValid()
        {
            foreach (var field in ValidationFields)
            {
                if (string.IsNullOrWhiteSpace(field.Text))
                {
                    return false;
                }
                if (field.AccessibleDescription == "int")
                {
                    try
                    {
                        int.Parse(field.Text.Trim());
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            Vehicle v = lbVehicles.SelectedItem as Vehicle;
            new VehicleServices(v).Show();
        }
    }
}

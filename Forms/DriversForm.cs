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
using Vehicle_Fleet_Management.Models;
using Vehicle_Fleet_Management.Repositoryes;

namespace Vehicle_Fleet_Management.Forms
{
    partial class DriversForm : Form
    {
        private IDriversRepository Repository { get; }
        private IEnumerable<Control> ValidationFields { get;}

        public DriversForm(IDriversRepository driversRepository)
        {
            InitializeComponent();
            Repository = driversRepository;
            ValidationFields = new List<Control>()
            {
                tbName, tbSurname, tbPhoneNumber, tbDriversLicense
            };
        }

        private void DriversForm_Load(object sender, EventArgs e)
        {
            try
            {
                lbDrivers.DataSource = Repository.GetDrivers().ToList();
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
                Driver driver = lbDrivers.SelectedItem as Driver;
                var confirmResult = MessageBox.Show($"Are you sure to delete {driver}, soft delete",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    if (Repository.DeleteDriver(driver.IDDriver))
                    {
                        lblMessage.Text = $"{driver} has been deleted";
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
                Driver driver = new Driver()
                {
                    Name = tbName.Text.Trim(),
                    Surname = tbSurname.Text.Trim(),
                    PhoneNumber = tbPhoneNumber.Text.Trim(),
                    DriversLicenseNumber = tbDriversLicense.Text.Trim()
                };

                if (Repository.CreateDriver(driver))
                {
                    lblMessage.Text = $"{driver} created";
                    RefreshForm();
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException sqlEx)
                {
                    if (sqlEx.Number == 2627)
                    {
                        lblMessage.Text = "Driver with that trivers licence already exists";
                    }
                }
                else
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
                Driver driver = lbDrivers.SelectedItem as Driver;
                driver.Name = tbName.Text.Trim();
                driver.Surname = tbSurname.Text.Trim();
                driver.PhoneNumber = tbPhoneNumber.Text.Trim();
                driver.DriversLicenseNumber = tbDriversLicense.Text.Trim();

                if (Repository.UpdateDriver(driver))
                {
                    lblMessage.Text = $"{driver} has been updated";
                    RefreshForm();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void lbDrivers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Driver driver = lbDrivers.SelectedItem as Driver;
            tbName.Text = driver.Name;
            tbSurname.Text = driver.Surname;
            tbPhoneNumber.Text = driver.PhoneNumber;
            tbDriversLicense.Text = driver.DriversLicenseNumber;
        }

        private void RefreshForm()
        {
            lbDrivers.DataSource = Repository.GetDrivers().ToList();
            tbName.Text = string.Empty;
            tbSurname.Text = string.Empty;
            tbPhoneNumber.Text = string.Empty;
            tbDriversLicense.Text = string.Empty;
        }

        private bool FormValid()
        {
            foreach (var field in ValidationFields)
            {
                if (string.IsNullOrWhiteSpace(field.Text))
                {
                    return false;
                }
            }
            return true;
        }

    }
}

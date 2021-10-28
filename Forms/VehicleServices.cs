using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vehicle_Fleet_Management.Repositoryes.entity;

namespace Vehicle_Fleet_Management.Forms
{
    public partial class VehicleServices : Form
    {
        public Models.Vehicle Vehicle { get; set; }

        public VehicleFleetManagementEntities db { get; } = new VehicleFleetManagementEntities();

        public VehicleServices(Models.Vehicle vehicle)
        {
            InitializeComponent();
            Vehicle = vehicle;
        }

        private void VehicleServices_Load(object sender, EventArgs e)
        {
            this.FormClosing += (_, a) => db.Dispose();
            lblVehicle.Text += $"  {Vehicle}";
            lbVehicleServices.DataSource = db.VehicleServices.ToList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!formValid())
            {
                MessageBox.Show("invalid price format");
                return;
            }
            db.VehicleServices.Add(new VehicleService()
            {
                Description = txtDecription.Text,
                Date = dtDate.Value,
                Price = Decimal.Parse(txtPrice.Text),
                FK_Vehicles = Vehicle.IDVehicle
            });
            db.SaveChanges();
            RefreshForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!formValid())
            {
                MessageBox.Show("invalid price format");
                return;
            }
            var id = (lbVehicleServices.SelectedItem as VehicleService).IDVehicleService;
            VehicleService service = db.VehicleServices.Find(id);

            service.Price = Decimal.Parse(txtPrice.Text);
            service.Date = dtDate.Value;
            service.Description = txtDecription.Text;

            db.SaveChanges();
            RefreshForm();
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            var service = lbVehicleServices.SelectedItem as VehicleService;
            db.VehicleServices.Remove(service);
            db.SaveChanges();
            RefreshForm();
        }

        private void lbVehicleServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            VehicleService service = lbVehicleServices.SelectedItem as VehicleService;
            dtDate.Value = service.Date;
            txtDecription.Text = service.Description;
            txtPrice.Text = service.Price.ToString();
        }

        private void RefreshForm()
        {
            lbVehicleServices.DataSource = db.VehicleServices.ToList();
            if (db.VehicleServices.Count() == 0)
            {
                ClearForm();
            }
        }
        private void ClearForm()
        {
            dtDate.Value = DateTime.Now;
            txtDecription.Text = string.Empty;
            txtPrice.Text = string.Empty;
        }

        private bool formValid()
        {
            return Decimal.TryParse(txtPrice.Text, out var o);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Vehicle_Fleet_Management.Extensions;
using Vehicle_Fleet_Management.Models;
using Vehicle_Fleet_Management.Repositoryes;

namespace Vehicle_Fleet_Management.Forms
{
    public partial class RoutesForm : Form
    {
        private IRoutesRepository Repository { get; set; }
        private IList<Route> Routes { get; set; }
        private TravelWarrent Warrent { get; set; }
        public RoutesForm(TravelWarrent warrent)
        {
            InitializeComponent();
            Warrent = warrent;
            Repository = Factories.RepositoryFactory.GetRoutesRepository(
                ConfigurationManager.ConnectionStrings["cs"].ConnectionString);
        }

        private void RoutesForm_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Route route = lbRoutes.SelectedItem as Route;
                var confirmResult = MessageBox.Show($"Are you sure to delete {route}",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    Repository.DeleteRoute(route.IDRoute);
                    RefreshForm();
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
                return;
            try
            {
                Route route = new Route()
                {
                    StartDate = DateTime.Parse(dtStart.Value.ToString()),
                    EndDate = DateTime.Parse(dtEnd.Value.ToString()),
                    StartLocation = tbStartLocation.Text,
                    EndLocation = tbEndLocation.Text,
                    Distance = int.Parse(tbDistance.Text),
                    FuelSpent = double.Parse(tbFuel.Text),
                    FK_TravelWarrents = Warrent.IDTravelWarrent
                };
                if (Repository.CreateRoute(route))
                {
                    lblMessage.Text = "Rote created";
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
                return;
            try
            {
                Route route = new Route()
                {
                    IDRoute = (lbRoutes.SelectedItem as Route).IDRoute,
                    StartDate = DateTime.Parse(dtStart.Value.ToString()),
                    EndDate = DateTime.Parse(dtEnd.Value.ToString()),
                    StartLocation = tbStartLocation.Text,
                    EndLocation = tbEndLocation.Text,
                    Distance = int.Parse(tbDistance.Text),
                    FuelSpent = double.Parse(tbFuel.Text),
                    FK_TravelWarrents = Warrent.IDTravelWarrent
                };
                if (Repository.UpdateRoute(route))
                {
                    lblMessage.Text = "route updated";
                    RefreshForm();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void lbRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Route route = lbRoutes.SelectedItem as Route;
            dtStart.Value = route.StartDate;
            dtEnd.Value = route.StartDate;
            tbStartLocation.Text = route.StartLocation;
            tbEndLocation.Text = route.EndLocation;
            tbDistance.Text = route.Distance.ToString();
            tbFuel.Text = route.FuelSpent.ToString();
        }
        private void btnXmlImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "xml files (*.xml)|*.xml";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Repository.InsertRoutesXml(ofd.FileName);
                    RefreshForm();
                }
            }
        }

        private void btnXmlExport_Click(object sender, EventArgs e)
        {
            string xml = Repository.GetRoutesXml(Warrent.IDTravelWarrent);
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = "Routs";
                sfd.Filter = "xml files (*.xml)|*.xml";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, xml);
                }
            }
        }

        private void RefreshForm()
        {
            Routes = Repository.GetRoutes(Warrent.IDTravelWarrent)?.ToList();
            lbRoutes.DataSource = Routes;
        }

        private bool FormValid()
        {
            return true;
        }
    }
}

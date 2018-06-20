using Newtonsoft.Json.Linq;
using RESTUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P3starter
{
    public partial class People_Box : Form
    {
        RESTapi rest = new RESTapi("http://ist.rit.edu/api");

        public People_Box(string peoType, string uName)
        {
            InitializeComponent();

            Main f = new Main();

            string jsonPeople = rest.getRESTData("/people/");
            People people = JToken.Parse(jsonPeople).ToObject<People>();

            // to separate the peoType into faculty and staff
            if (peoType == "faculty")
            {
                // get the /faculty/ data from api
               

                // get the data for rtb_peo
                rtb_peo.Text = " ";
                rtb_peo.AppendText(people.faculty.Find(x => x.name.Equals(uName)).name + Environment.NewLine);
                rtb_peo.AppendText(people.faculty.Find(x => x.name.Equals(uName)).title + Environment.NewLine);
                rtb_peo.AppendText(people.faculty.Find(x => x.name.Equals(uName)).office + Environment.NewLine);
                rtb_peo.AppendText(people.faculty.Find(x => x.name.Equals(uName)).phone + Environment.NewLine);
                rtb_peo.AppendText(people.faculty.Find(x => x.name.Equals(uName)).email + Environment.NewLine);

                // get the image for each people
                pictureBox_peo.Load(people.faculty.Find(x => x.name.Equals(uName)).imagePath);
            }
            else
            {
    
                // get the data for rtb_peo
                rtb_peo.Text = " ";
                rtb_peo.AppendText(people.staff.Find(x => x.name.Equals(uName)).name + Environment.NewLine);
                rtb_peo.AppendText(people.staff.Find(x => x.name.Equals(uName)).title + Environment.NewLine);
                rtb_peo.AppendText(people.staff.Find(x => x.name.Equals(uName)).email + Environment.NewLine);

                // get the image for each staff
                pictureBox_peo.Load(people.staff.Find(x => x.name.Equals(uName)).imagePath);
            }
        }
    }
}

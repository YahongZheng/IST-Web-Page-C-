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
    public partial class Minors_Box : Form
    {
        RESTapi rest = new RESTapi("http://ist.rit.edu/api");

        Main f = new Main();

        public Minors_Box(Main m)
        {
            InitializeComponent();
            f = m;

            // Get the /minors/ information from the API
            string jsonMinor = rest.getRESTData("/minors/");
            minor minor = JToken.Parse(jsonMinor).ToObject<minor>();

            string[] minorCourses = new string[8];  // 8 is the longest courses number

            rtb_minors.AppendText(minor.UgMinors.Find(x => x.title.Equals(f.selected_name)).title + Environment.NewLine);
            rtb_minors.AppendText(minor.UgMinors.Find(x => x.title.Equals(f.selected_name)).description + Environment.NewLine);
            rtb_minors.AppendText(Environment.NewLine + "Courses:" + Environment.NewLine);

            int count = 0;
            foreach (String course in minor.UgMinors.Find(x => x.title.Equals(f.selected_name)).courses)
            {
                minorCourses[count] = minor.UgMinors.Find(x => x.title.Equals(f.selected_name)).courses[count];
                count++;
            }
            count = 0;
            while (count < minorCourses.Length)
            {
                rtb_minors.AppendText(minorCourses[count] + Environment.NewLine);
                count++;
            }
        }

    }
}


using Newtonsoft.Json.Linq;
using RESTUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P3starter
{
    public partial class Main : Form
    {
        RESTapi rest = new RESTapi("http://ist.rit.edu/api");

        // for minors page
        public String selected_name { get; set; }
        public string selectedPeopleTab;

        public Main()
        {
            InitializeComponent();
            Populate();
        }

        //---------------------About Page---------------------------------//
        public void Populate()
        {
            // Get the /about/ information from the API
            string jsonAbout = rest.getRESTData("/about/");

            // need to get the data out of the JSON string 
            // into an object form that we can use
            About about = JToken.Parse(jsonAbout).ToObject<About>();

            // About title
            lbl_aboutTitle.Text = about.title;
            rtb_desc.Text = about.description;
            lbl_about_quoteAuthor.Text = about.quoteAuthor;
            tb_quote.Text = about.quote;

            // get resources, a link to click on 
            string jsonRes = rest.getRESTData("/resources/");

            // Get information out of the resources object
            Resources resources = JToken.Parse(jsonRes).ToObject<Resources>();
            lblLink_istLabs.Text = resources.tutorsAndLabInformation.tutoringLabHoursLink;
        }

        private void lblLink_istLabs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(lblLink_istLabs.Text);
            lblLink_istLabs.LinkVisited = true;
        }

        //-------------------------Degrees Page----------------------------//
        //undergraduate degrees
        private void btn_undergrad_Click(object sender, EventArgs e)
        {
            // get the degrees information from API
            string jsonDegrees = rest.getRESTData("/degrees/");
            Degrees degrees = JToken.Parse(jsonDegrees).ToObject<Degrees>();

            //initialize varibles
            int i = 0;
            string[] underGrad = new string[3];
            string[] degreeDesc = new string[3];
            rtb_description.Text = " ";

            foreach (Undergraduate ug in degrees.undergraduate)
            {
                underGrad[i] = ug.title;
                degreeDesc[i] = ug.description;
                i++;
            }

            i = gb_degrees.Controls.Count - 1;
            foreach (Button b in gb_degrees.Controls)
            {
                b.Text = underGrad[i];  // display three undergraduate degrees' title
                b.Tag = degreeDesc[i];  // display each degrees' description
                b.Enabled = true;
                i--;
            }
        } // end btn_undergrad_Click

        // graduate degree
        private void btn_graduate_Click(object sender, EventArgs e)
        {
            // get the degrees information from API
            string jsonDegrees = rest.getRESTData("/degrees/");
            Degrees degrees = JToken.Parse(jsonDegrees).ToObject<Degrees>();

            //initialize varibles
            int i = 0;
            int j = 0;
            string[] grad = new string[3];
            string[] gradDesc = new string[3];
            rtb_description.Text = " ";

            foreach (Graduate gr in degrees.graduate)
            {
                if (gr.title != null)
                {
                    grad[i] = gr.title;
                    gradDesc[i] = gr.description;
                    i++;
                    j = 0;
                }
            }

            i = gb_degrees.Controls.Count - 1;
            foreach (Button b in gb_degrees.Controls)
            {
                b.Text = grad[i];  // display three undergraduate degrees' title
                b.Tag = gradDesc[i];  // display each degrees' description
                b.Enabled = true;
                i--;
            }
        } // end btn_graduate_Clisk

        // for three different buttons of Undergraduate and Graduate
        // when each button is click, richTextBox will display the description of each degree
        private void button3_Click(object sender, EventArgs e)
        {
            rtb_description.Text = " ";
            rtb_description.AppendText((string)button3.Tag);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rtb_description.Text = " ";
            rtb_description.AppendText((string)button4.Tag);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            rtb_description.Text = " ";
            rtb_description.AppendText((string)button5.Tag);
        }

        //-------------------Minors page-----------------------------//
        // for DBDDI button
        private void btn_DBDDI_Click(object sender, EventArgs e)
        {
            selected_name = btn_DBDDI.Text;
            Minors_Box mb = new Minors_Box(this);
            mb.ShowDialog();
        }
        // for GIS button
        private void btn_GIS_Click(object sender, EventArgs e)
        {
            selected_name = btn_GIS.Text;
            Minors_Box mb = new Minors_Box(this);
            mb.ShowDialog();
        }
        // for MDDEV button
        private void btn_MDDEV_Click(object sender, EventArgs e)
        {
            selected_name = btn_MDDEV.Text;
            Minors_Box mb = new Minors_Box(this);
            mb.ShowDialog();
        }
        // for MDEV button
        private void btn_MDEV_Click(object sender, EventArgs e)
        {
            selected_name = btn_MDEV.Text;
            Minors_Box mb = new Minors_Box(this);
            mb.ShowDialog();
        }
        // for NETSYS button
        private void btn_NETSYS_Click(object sender, EventArgs e)
        {
            selected_name = btn_NETSYS.Text;
            Minors_Box mb = new Minors_Box(this);
            mb.ShowDialog();
        }
        // for WEBDD button
        private void btn_WEBDD_Click(object sender, EventArgs e)
        {
            selected_name = btn_WEBDD.Text;
            Minors_Box mb = new Minors_Box(this);
            mb.ShowDialog();
        }
        // for WEBD button
        private void btn_WEBD_Click(object sender, EventArgs e)
        {
            selected_name = btn_WEBD.Text;
            Minors_Box mb = new Minors_Box(this);
            mb.ShowDialog();
        }

        //------------------Employment Page------------------------//
        private void tab_employment_Enter(object sender, EventArgs e)
        {
            //get the /employment/ data from api
            string jsonEmp = rest.getRESTData("/employment");
            Employment emp = JToken.Parse(jsonEmp).ToObject<Employment>();

            // get the title for emp_label1
            emp_label1.Text = emp.introduction.title;

            // get the description for rtb_employment
            rtb_employment.Text = " ";
            rtb_employment.AppendText(emp.introduction.content[0].title + Environment.NewLine);
            rtb_employment.AppendText(Environment.NewLine + emp.introduction.content[0].description);

            // get the data for four degree statistics
            gb_stat.Text = emp.degreeStatistics.title; //get the title
            int i = gb_stat.Controls.Count - 1;
            foreach(RichTextBox rtb in gb_stat.Controls)
            {
                rtb.Text = " ";
                rtb.AppendText(emp.degreeStatistics.statistics[i].value + Environment.NewLine);
                rtb.AppendText(emp.degreeStatistics.statistics[i].description);
                i--;
            }

            // get the cooperative education data in rtb_coop
            rtb_coop.Text = " ";
            rtb_coop.AppendText(emp.introduction.content[1].title + Environment.NewLine);
            rtb_coop.AppendText(Environment.NewLine + emp.introduction.content[1].description);

            // get the employer data in rtb_employers
            rtb_employers.Text = " ";
            rtb_employers.AppendText(emp.employers.title + Environment.NewLine);
            foreach(string str in emp.employers.employerNames)
            {
                rtb_employers.AppendText(str + Environment.NewLine);
            }

            // get the carees data in rtb_carees
            rtb_carees.Text = " ";
            rtb_carees.AppendText(emp.careers.title + Environment.NewLine);
            foreach(string str in emp.careers.careerNames)
            {
                rtb_carees.AppendText(str + Environment.NewLine);
            }
        }


        //----------------------Employment Table Page--------------//
        private Employment emp = null;

        private void loadEmploymentData()
        {
            // Have we loaded the data before?
            if (emp == null)
            {
                // get employment data from api
                string jsonEmp = rest.getRESTData("/employment/");

                // cast the object to an employee
                emp = JToken.Parse(jsonEmp).ToObject<Employment>();
            }

        }
        // for employment table
        private void btn_emp_Click(object sender, EventArgs e)
        {
            loadEmploymentData();
            // Now handle the list view component
            listView_emp.Clear();

            listView_emp.View = View.Details; // each item appears on a separate line
            
            listView_emp.Columns.Add("Degree", 80);
            listView_emp.Columns.Add("Employer", 100);
            listView_emp.Columns.Add("Location", 90);
            listView_emp.Columns.Add("Title", 120);
            listView_emp.Columns.Add("Date", 80);

            // add information from the emp object
            ListViewItem item;

            for (var i = 0; i < emp.employmentTable.professionalEmploymentInformation.Count; i++)
            {
                item = new ListViewItem(new string[]
                {
                    emp.employmentTable.professionalEmploymentInformation[i].degree,
                    emp.employmentTable.professionalEmploymentInformation[i].employer,
                    emp.employmentTable.professionalEmploymentInformation[i].city,
                    emp.employmentTable.professionalEmploymentInformation[i].title,
                    emp.employmentTable.professionalEmploymentInformation[i].startDate
                });

                // append the row to the list view
                listView_emp.Items.Add(item);

            } // end for
        }

        // for coop table
        private void btn_coop_Click(object sender, EventArgs e)
        {
            loadEmploymentData();
            // Now handle the list view component
            listView_coop.Clear();

            listView_coop.View = View.Details; // each item appears on a separate line
            
            listView_coop.Columns.Add("Employer", 100);
            listView_coop.Columns.Add("Degree", 80);
            listView_coop.Columns.Add("City", 100);
            listView_coop.Columns.Add("Term", 80);

            // add information from the emp object
            ListViewItem item;

            for (var i = 0; i < emp.coopTable.coopInformation.Count; i++)
            {
                item = new ListViewItem(new string[]
                {
                    emp.coopTable.coopInformation[i].employer,
                    emp.coopTable.coopInformation[i].degree,
                    emp.coopTable.coopInformation[i].city,
                    emp.coopTable.coopInformation[i].term
                });

                // append the row to the list view
                listView_coop.Items.Add(item);

            } // end for
        }


        //---------------------People Page-----------------------//
        // get the /people/ data from api
        private People peo = null;

        private void loadPeople()
        {
            // Have we loaded the data before?
            if (peo == null)
            {
                // get employment data from api
                string jsonPeo = rest.getRESTData("/people/");

                // cast the object to an employee
                peo = JToken.Parse(jsonPeo).ToObject<People>();
            }

        }
        // for faculty
        private void tab_People_Enter(object sender, EventArgs e)
        {
            loadPeople();

            // get the faculty name for each button
            string[] facName = new string[35];

            int i = 0;
            foreach (Faculty facu in peo.faculty)
            {
                facName[i] = facu.name;
                i++;
            }

            i = tab_faculty.Controls.Count - 1;
            foreach (Button btn in tab_faculty.Controls)
            {
                btn.Text = facName[i];
                i--;
            }
        }
        private void tab_faculty_Enter(object sender, EventArgs e)
        {
            selectedPeopleTab = "faculty";
        }

        // for staff
        private void tab_staff_Enter(object sender, EventArgs e)
        {
            loadPeople();

            // get the staff name for each button
            string[] staffName = new string[20];

            int i = 0;
            foreach(Staff sta in peo.staff)
            {
                staffName[i] = sta.name;
                i++;
            }

            i = tab_staff.Controls.Count - 1;
            foreach(Button btn in tab_staff.Controls)
            {
                btn.Text = staffName[i];
                i--;
            }
        }
        // by faculty
        String f = "faculty";
        private void button1_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button1.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button2.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button6.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button7.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button8.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button9.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button10.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button11.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button12.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button13.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button14.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button15.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button16.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button17.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button18.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button19.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button20.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button21.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button22.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button23.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button24.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button25.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button26.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button27.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button28.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button29.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button30.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button31.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button32.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button33.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button34.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button35.Text;
            People_Box pb = new People_Box(f, selectedPeopleTab);
            pb.ShowDialog();
        }

        // by staff

        string s = "staff";
        private void button36_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button36.Text;
            People_Box pb = new People_Box(s, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button37.Text;
            People_Box pb = new People_Box(s, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button38.Text;
            People_Box pb = new People_Box(s, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button39.Text;
            People_Box pb = new People_Box(s, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button40.Text;
            People_Box pb = new People_Box(s, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button41.Text;
            People_Box pb = new People_Box(s, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button42.Text;
            People_Box pb = new People_Box(s, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button43.Text;
            People_Box pb = new People_Box(s, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button44.Text;
            People_Box pb = new People_Box(s, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button45.Text;
            People_Box pb = new People_Box(s, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button46.Text;
            People_Box pb = new People_Box(s, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button47_Click(object sender, EventArgs e)
        {

            selectedPeopleTab = button47.Text;
            People_Box pb = new People_Box(s, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button48.Text;
            People_Box pb = new People_Box(s, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button49.Text;
            People_Box pb = new People_Box(s, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button50.Text;
            People_Box pb = new People_Box(s, selectedPeopleTab);
            pb.ShowDialog();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            selectedPeopleTab = button51.Text;
            People_Box pb = new People_Box(s, selectedPeopleTab);
            pb.ShowDialog();
        }


        //-----------------------Research Page--------------------//
        private void tab_research_Enter(object sender, EventArgs e)
        {
            // get the /research/ data from api
            string jsonResearch = rest.getRESTData("/research/");
            Research research = JToken.Parse(jsonResearch).ToObject<Research>();

            // get the information of research by interese area
            rtb_rese_area.Text = " ";
            foreach (ByInterestArea area in research.byInterestArea)
            {
                rtb_rese_area.AppendText(Environment.NewLine + area.areaName + Environment.NewLine);
                foreach (string s in area.citations) {
                    rtb_rese_area.AppendText(s + Environment.NewLine);
                }
                //rtb_rese_area.AppendText(area.citations + Environment.NewLine);
            }

            // get the information of research by faculty
            rtb_rese_faculty.Text = " ";
            foreach(ByFaculty fac in research.byFaculty)
            {
                rtb_rese_faculty.AppendText(Environment.NewLine + fac.facultyName + Environment.NewLine);
                foreach (string s in fac.citations)
                {
                    rtb_rese_faculty.AppendText(s + Environment.NewLine);
                }
              
            }
            
        }



        //----------------------Resources Page--------------------//
        private void tab_Resources_Enter(object sender, EventArgs e)
        {
            // get the /resources/ data from api
            string jsonResources = rest.getRESTData("/resources/");
            Resources resources = JToken.Parse(jsonResources).ToObject<Resources>();

            // get the information of co-op enrollment
            rtb_coop_res.Text = " ";
            foreach (EnrollmentInformationContent en in resources.coopEnrollment.enrollmentInformationContent)
            {
                rtb_coop_res.AppendText(Environment.NewLine + en.title + Environment.NewLine);
                rtb_coop_res.AppendText(Environment.NewLine + en.description + Environment.NewLine);
            }

            rtb_coop_res.AppendText(resources.coopEnrollment.RITJobZoneGuidelink);

            // get the information for tutor/lab information
            rtb_tutor_res.Text = " ";
            rtb_tutor_res.AppendText(resources.tutorsAndLabInformation.title + Environment.NewLine);
            rtb_tutor_res.AppendText(resources.tutorsAndLabInformation.description + Environment.NewLine);
            rtb_tutor_res.AppendText(resources.tutorsAndLabInformation.tutoringLabHoursLink + Environment.NewLine);

            // get the information of student advising service
            rtb_advising.Text = " ";
            // academic advisors
            rtb_advising.AppendText(resources.studentServices.academicAdvisors.title + Environment.NewLine);
            rtb_advising.AppendText(resources.studentServices.academicAdvisors.description + Environment.NewLine);
            // professonal advisors
            rtb_advising.AppendText(Environment.NewLine + resources.studentServices.professonalAdvisors.title + Environment.NewLine);
            foreach (AdvisorInformation ad in resources.studentServices.professonalAdvisors.advisorInformation)
            {
                rtb_advising.AppendText(Environment.NewLine + ad.name + Environment.NewLine);
                rtb_advising.AppendText(ad.department + Environment.NewLine);
                rtb_advising.AppendText(ad.email + Environment.NewLine);
            }
            // faculty advisors
            rtb_advising.AppendText(Environment.NewLine + resources.studentServices.facultyAdvisors.title + Environment.NewLine);
            rtb_advising.AppendText(Environment.NewLine + resources.studentServices.facultyAdvisors.description + Environment.NewLine);

            // get the information of student ambassadors
            rtb_amba.Text = " ";
            rtb_amba.AppendText(resources.studentAmbassadors.title + Environment.NewLine);
            foreach (SubSectionContent su in resources.studentAmbassadors.subSectionContent)
            {
                rtb_amba.AppendText(Environment.NewLine + su.title + Environment.NewLine);
                rtb_amba.AppendText(su.description + Environment.NewLine);
            }
            
        } // end tab_resources_enter



        //------------------------Footer Page---------------------//
        private void tab_footer_Enter(object sender, EventArgs e)
        {
            // get the /footer/ data from api
            string jsonFooter = rest.getRESTData("/footer");
            Footer footer = JToken.Parse(jsonFooter).ToObject<Footer>();

            // social
            link_social_twitter.Text = footer.social.twitter;
            link_social_facebook.Text = footer.social.facebook;

            // news
            link_news.Text = footer.news;
        }

        private void link_social_twitter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(link_social_twitter.Text);
            link_social_twitter.LinkVisited = true;
        }

        private void link_social_facebook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(link_social_facebook.Text);
            link_social_facebook.LinkVisited = true;
        }

        private void link_news_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(link_news.Text);
            link_news.LinkVisited = true;
        }

        
    } // main : form
} //end namespace

using System;
using System.Drawing;
using System.Windows.Forms;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            string exeFile = (new Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
            string exeDir = Path.GetDirectoryName(exeFile);


            //string fullPath = Path.Combine(exeDir, "..\\..\\favicon.ico");
            //this.Icon = new Icon(fullPath);
            InitializeComponent();
            this.Text = "Adarsh Eye Hospital";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Document document = new Document();
                string text_date = DateTime.Now.ToString("MM/dd/yyyy") + "-Adarsh-"
                     + DateTime.Now.ToString("H.mm");

                PdfWriter.GetInstance(document, new FileStream("D:/" + text_date + ".pdf", FileMode.Create));
                document.Open();
                Paragraph p = new Paragraph("new भारत ");

                string exeFile = (new Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
                string exeDir = Path.GetDirectoryName(exeFile);

                //string fullPath = Path.Combine(exeDir, "..\\..\\header.jpg");
                string fullPath = Path.Combine(exeDir, "header.jpg");
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(fullPath);
                jpg.ScalePercent(21f);
                document.Add(jpg);

                String sex = "";

                if (male.Checked)
                {
                    sex = male.Text;
                }
                else if(female.Checked)
                {
                    sex = female.Text;
                }

                iTextSharp.text.Font myFont = FontFactory.GetFont("Times New Roman", 12, iTextSharp.text.Font.BOLD);
                Paragraph patient = new Paragraph("Patient Details", myFont);

                document.Add(patient);

                Paragraph basic = new Paragraph(
                    "Name : " + name.Text + "\n" + 
                    "Age : " + age.Text + "\n" + 
                    "Sex : " + sex + "\n" + 
                    "Address : " + address.Text + "\n" +
                    "Appointment : " + dateTimePicker1.Text + "\n\n");
                
                document.Add(basic);

                if(!(history.Text.Equals("")))
                {
                    Paragraph chief_history = new Paragraph(
                    "Chief Complaint History :" + "\n", myFont);
                    document.Add(chief_history);

                    Paragraph history_details = new Paragraph(history.Text + "\n\n");
                    document.Add(history_details);
                }


                if (!(rx.Text.Equals("")))
                {
                    Paragraph text_rx = new Paragraph("Rx", myFont);
                    document.Add(text_rx);

                    Paragraph rx_details = new Paragraph(rx.Text + "\n\n");
                    document.Add(rx_details);
                }

                Paragraph text_glasses = new Paragraph("Glasses \n\n", myFont);
                document.Add(text_glasses);

                //Glasses
                PdfPTable table = new PdfPTable(7);
                table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                PdfPCell cell = new PdfPCell();
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell("");
                cell = new PdfPCell(new Phrase("Right", myFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Colspan = 3;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Left", myFont));
                cell.Colspan = 3;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);

                table.AddCell("");
                table.AddCell("Sph");
                table.AddCell("Cyl");
                table.AddCell("Axis");

                table.AddCell("Sph");
                table.AddCell("Cyl");
                table.AddCell("Axis");


                cell = new PdfPCell(new Phrase("Distance"));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(cell);
                
                table.AddCell(re_d_s.Text);
                table.AddCell(re_d_c.Text);
                table.AddCell(re_d_a.Text);

                table.AddCell(le_d_s.Text);
                table.AddCell(le_d_c.Text);
                table.AddCell(le_d_a.Text);


                cell = new PdfPCell(new Phrase("Near"));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(cell);
                table.AddCell(re_n_s.Text);
                table.AddCell(re_n_c.Text);
                table.AddCell(re_n_a.Text);

                table.AddCell(le_n_s.Text);
                table.AddCell(le_n_c.Text);
                table.AddCell(le_n_a.Text);

                document.Add(table);

                Paragraph diagnosis_text = new Paragraph("\n Diagnosis \n\n", myFont);
                document.Add(diagnosis_text);

                PdfPTable diagnosis_table = new PdfPTable(3);
                diagnosis_table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                diagnosis_table.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                PdfPCell diagnosis_cell = new PdfPCell();

                diagnosis_table.AddCell("");

                diagnosis_cell = new PdfPCell(new Phrase("R/E", myFont));
                diagnosis_cell.HorizontalAlignment = Element.ALIGN_CENTER;
                diagnosis_table.AddCell(diagnosis_cell);

                diagnosis_cell = new PdfPCell(new Phrase("L/E", myFont));
                diagnosis_cell.HorizontalAlignment = Element.ALIGN_CENTER;
                diagnosis_table.AddCell(diagnosis_cell);

                diagnosis_cell = new PdfPCell(new Phrase("Vision"));
                diagnosis_cell.HorizontalAlignment = Element.ALIGN_LEFT;
                diagnosis_table.AddCell(diagnosis_cell);
                diagnosis_table.AddCell(d_v_r.Text);
                diagnosis_table.AddCell(d_v_l.Text);

                diagnosis_cell = new PdfPCell(new Phrase("Tension"));
                diagnosis_cell.HorizontalAlignment = Element.ALIGN_LEFT;
                diagnosis_table.AddCell(diagnosis_cell);
                diagnosis_table.AddCell(d_t_r.Text);
                diagnosis_table.AddCell(d_t_l.Text);

                diagnosis_cell = new PdfPCell(new Phrase("SAC"));
                diagnosis_cell.HorizontalAlignment = Element.ALIGN_LEFT;
                diagnosis_table.AddCell(diagnosis_cell);
                diagnosis_table.AddCell(d_s_r.Text);
                diagnosis_table.AddCell(d_s_l.Text);

                document.Add(diagnosis_table);


                if (!(diagnosis.Text.Equals("")))
                {
                    Paragraph diagnosis2 = new Paragraph("\nDiagnosis \n", myFont);
                    document.Add(diagnosis2);

                    Paragraph text_diagnosis = new Paragraph(diagnosis.Text);
                    document.Add(text_diagnosis);
                }

                PdfPTable medicine_table = new PdfPTable(4);
                PdfPCell medicine_cell = new PdfPCell();
                

                if (!(p_m_n1.Text.Equals("")))
                {
                    Paragraph medicine_text = new Paragraph("\n Medicine \n\n", myFont);
                    document.Add(medicine_text);
                    
                    medicine_table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    medicine_table.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                    medicine_cell = new PdfPCell(new Phrase("Name", myFont));
                    medicine_cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    medicine_table.AddCell(medicine_cell);

                    medicine_cell = new PdfPCell(new Phrase("Time", myFont));
                    medicine_cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    medicine_table.AddCell(medicine_cell);

                    medicine_cell = new PdfPCell(new Phrase("Duration", myFont));
                    medicine_cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    medicine_table.AddCell(medicine_cell);

                    medicine_cell = new PdfPCell(new Phrase("Pills", myFont));
                    medicine_cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    medicine_table.AddCell(medicine_cell);

                    medicine_cell = new PdfPCell(new Phrase(p_m_n1.Text));
                    medicine_cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    medicine_table.AddCell(medicine_cell);
                    medicine_table.AddCell(p_m_t1.Text);
                    medicine_table.AddCell(p_m_d1.Text);
                    medicine_table.AddCell(p_m_p1.Text);
                }

                if (!(p_m_n2.Text.Equals("")))
                {
                    medicine_cell = new PdfPCell(new Phrase(p_m_n2.Text));
                    medicine_cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    medicine_table.AddCell(medicine_cell);
                    medicine_table.AddCell(p_m_t2.Text);
                    medicine_table.AddCell(p_m_d2.Text);
                    medicine_table.AddCell(p_m_p2.Text);
                }

                if (!(p_m_n3.Text.Equals("")))
                {
                    medicine_cell = new PdfPCell(new Phrase(p_m_n3.Text));
                    medicine_cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    medicine_table.AddCell(medicine_cell);
                    medicine_table.AddCell(p_m_t3.Text);
                    medicine_table.AddCell(p_m_d3.Text);
                    medicine_table.AddCell(p_m_p3.Text);
                }
                if (!(p_m_n4.Text.Equals("")))
                {
                    medicine_cell = new PdfPCell(new Phrase(p_m_n4.Text));
                    medicine_cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    medicine_table.AddCell(medicine_cell);
                    medicine_table.AddCell(p_m_t4.Text);
                    medicine_table.AddCell(p_m_d4.Text);
                    medicine_table.AddCell(p_m_p4.Text);
                }
                if (!(p_m_n5.Text.Equals("")))
                {
                    medicine_cell = new PdfPCell(new Phrase(p_m_n5.Text));
                    medicine_cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    medicine_table.AddCell(medicine_cell);
                    medicine_table.AddCell(p_m_t5.Text);
                    medicine_table.AddCell(p_m_d5.Text);
                    medicine_table.AddCell(p_m_p5.Text);
                }
                
                document.Add(medicine_table);


                PdfPTable eye_table = new PdfPTable(4);
                PdfPCell eye_cell = new PdfPCell();

                if (!(p_e_n1.Text.Equals("")))
                {
                    Paragraph eye_text = new Paragraph("\n Eye Drops \n\n", myFont);
                    document.Add(eye_text);
                    
                    eye_table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    eye_table.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                    eye_cell = new PdfPCell(new Phrase("Name", myFont));
                    eye_cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    eye_table.AddCell(eye_cell);

                    eye_cell = new PdfPCell(new Phrase("Time", myFont));
                    eye_cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    eye_table.AddCell(eye_cell);

                    eye_cell = new PdfPCell(new Phrase("Duration", myFont));
                    eye_cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    eye_table.AddCell(eye_cell);

                    eye_cell = new PdfPCell(new Phrase("Drops", myFont));
                    eye_cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    eye_table.AddCell(eye_cell);

                    eye_cell = new PdfPCell(new Phrase(p_e_n1.Text));
                    eye_cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    eye_table.AddCell(eye_cell);
                    eye_table.AddCell(p_e_t1.Text);
                    eye_table.AddCell(p_e_du1.Text);
                    eye_table.AddCell(p_e_dr1.Text);
                }
                if (!(p_e_n2.Text.Equals("")))
                {
                    eye_cell = new PdfPCell(new Phrase(p_e_n2.Text));
                    eye_cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    eye_table.AddCell(eye_cell);
                    eye_table.AddCell(p_e_t2.Text);
                    eye_table.AddCell(p_e_du2.Text);
                    eye_table.AddCell(p_e_dr2.Text);
                }
                if (!(p_e_n3.Text.Equals("")))
                {
                    eye_cell = new PdfPCell(new Phrase(p_e_n3.Text));
                    eye_cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    eye_table.AddCell(eye_cell);
                    eye_table.AddCell(p_e_t3.Text);
                    eye_table.AddCell(p_e_du3.Text);
                    eye_table.AddCell(p_e_dr3.Text);
                }
                if (!(p_e_n4.Text.Equals("")))
                {
                    eye_cell = new PdfPCell(new Phrase(p_e_n4.Text));
                    eye_cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    eye_table.AddCell(eye_cell);
                    eye_table.AddCell(p_e_t4.Text);
                    eye_table.AddCell(p_e_du4.Text);
                    eye_table.AddCell(p_e_dr4.Text);
                }
                if (!(p_e_n5.Text.Equals("")))
                {
                    eye_cell = new PdfPCell(new Phrase(p_e_n5.Text));
                    eye_cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    eye_table.AddCell(eye_cell);
                    eye_table.AddCell(p_e_t5.Text);
                    eye_table.AddCell(p_e_du5.Text);
                    eye_table.AddCell(p_e_dr5.Text);
                }
               
                document.Add(eye_table);

                if(checkBox1.Checked)
                {
                    Paragraph operation_text = new Paragraph("\n Operation Details \n\n", myFont);
                    document.Add(operation_text);

                    PdfPTable ot_table = new PdfPTable(2);
                    ot_table.WidthPercentage = 50;
                    ot_table.HorizontalAlignment = 0;
                    ot_table.DefaultCell.BorderWidth = 0;

                    PdfPCell ot_cell = new PdfPCell();
                    ot_cell.HorizontalAlignment = Element.ALIGN_CENTER;

                    ot_table.AddCell("Blood Sugar");
                    ot_table.AddCell(blood_sugar.Text);

                    ot_table.AddCell("Blood Pressure");
                    ot_table.AddCell(blood_pressure.Text);

                    ot_table.AddCell("K1");
                    ot_table.AddCell(k1.Text);

                    ot_table.AddCell("K2");
                    ot_table.AddCell(k2.Text);

                    ot_table.AddCell("Axial Length");
                    ot_table.AddCell(axial_length.Text);

                    ot_table.AddCell("IoL1");
                    ot_table.AddCell(iol1.Text);

                    document.Add(ot_table);
                }

                Paragraph signature = new Paragraph("......................\n Signature");
                signature.Alignment = 2;
                signature.SpacingBefore = 50;
                document.Add(signature);

                document.Close();

                ProcessStartInfo startInfo = new ProcessStartInfo("D:/" + text_date + ".pdf");
                Process.Start(startInfo);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField5_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField15_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(panel5.Enabled)
            {
                label11.Enabled = false;
                panel5.Enabled= false;
            }
            else
            {
                label11.Enabled = true;
                panel5.Enabled = true;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, System.Drawing.Color.Black, ButtonBorderStyle.Solid);

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel2.ClientRectangle, System.Drawing.Color.Black, ButtonBorderStyle.Solid);
        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel3.ClientRectangle, System.Drawing.Color.Black, ButtonBorderStyle.Solid);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel5.ClientRectangle, System.Drawing.Color.Black, ButtonBorderStyle.Solid);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel4.ClientRectangle, System.Drawing.Color.Black, ButtonBorderStyle.Solid);
        }

        private void label8_Click_2(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel6.ClientRectangle, System.Drawing.Color.Black, ButtonBorderStyle.Solid);
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel8.ClientRectangle, System.Drawing.Color.Black, ButtonBorderStyle.Solid);
        }


        private void materialSingleLineTextField20_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel7.ClientRectangle, System.Drawing.Color.Black, ButtonBorderStyle.Solid);
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel10.ClientRectangle, System.Drawing.Color.Black, ButtonBorderStyle.Solid);
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel11.ClientRectangle, System.Drawing.Color.Black, ButtonBorderStyle.Solid);
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel12.ClientRectangle, System.Drawing.Color.Black, ButtonBorderStyle.Solid);
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel13.ClientRectangle, System.Drawing.Color.Black, ButtonBorderStyle.Solid);
        }

        private void p_m_n1_Click(object sender, EventArgs e)
        {

        }
    }
}

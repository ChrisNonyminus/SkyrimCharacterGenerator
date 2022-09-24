using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyrimCharacterGenerator.UI.App
{
    public partial class Form1 : Form
    {
        Common.Character character;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            character = Common.Character.Generate(new Common.Character.Options()
            {
                UsingCCO = cbOptions.GetItemChecked(0),
                UsingLorkhan = cbOptions.GetItemChecked(1),
                UsingFactionReps = cbOptions.GetItemChecked(2),
                UsingDWB = cbOptions.GetItemChecked(3),
                UseTemplate = false
            });
            if (!LockGender.Checked) cbGender.SelectedIndex = (int)character.Gender;
            if (!LockRace.Checked) cbRace.SelectedIndex = (int)character.Race;

            if (cbOptions.GetItemChecked(0))
            {
                if (!LockCCOSign.Checked) cbCCO_Sign.SelectedIndex = (int)character.CCOStats.Sign;
                if (!LockCCOClass.Checked) cbCCO_Class.SelectedIndex = (int)character.CCOStats.PresetClass;
            }


            if (cbOptions.GetItemChecked(1))
            {
                if (!LockLorkhanSign.Checked) cbLorkhan_Sign.SelectedIndex = (int)character.LorkhanStats.Sign;
                
                if (!LockLorkhanClasses.Checked)
                {
                    dgvLorkhan_Classes.Rows.Clear();
                    dgvLorkhan_Classes.AutoGenerateColumns = true;
                    (dgvLorkhan_Classes.Columns[0] as DataGridViewComboBoxColumn).DataSource = Enum.GetValues(typeof(Common.Character.Lorkhan.CharacterClass));
                    foreach (var c in character.LorkhanStats.Classes)
                    {
                        int idx = dgvLorkhan_Classes.Rows.Add();
                        dgvLorkhan_Classes.Rows[idx].Cells[0].Value = c;
                    }
                }

                if (!LockLorkhanCurses.Checked)
                {
                    dgvLorkhan_Curses.Rows.Clear();
                    dgvLorkhan_Curses.AutoGenerateColumns = true;
                    dgvLorkhan_Curses.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    (dgvLorkhan_Curses.Columns[0] as DataGridViewComboBoxColumn).DataSource = Enum.GetValues(typeof(Common.Character.Lorkhan.Curse));
                    foreach (var c in character.LorkhanStats.Curses)
                    {
                        int idx = dgvLorkhan_Curses.Rows.Add();
                        dgvLorkhan_Curses.Rows[idx].Cells[0].Value = c;
                    }
                }
                
                if (!LockLorkhanGem.Checked)
                {
                    cbLorkhan_StartingLocation.SelectedIndex = (int)character.LorkhanStats.StartingLocation;
                }
            }

            if (cbOptions.GetItemChecked(2) && !cbLockFactions.Checked)
            {
                dgvFactionReputations.Rows.Clear();
                clmnFaction.DataSource = Enum.GetValues(typeof(Common.Character.Faction));
                clmnReputation.DataSource = Enum.GetValues(typeof(Common.Character.Reputation));
                foreach (var reputation in character.DefaultReputations)
                {
                    int idx = dgvFactionReputations.Rows.Add();
                    dgvFactionReputations.Rows[idx].Cells[0].Value = reputation.Key;
                    dgvFactionReputations.Rows[idx].Cells[1].Value = reputation.Value;
                }
            }

            if (cbOptions.GetItemChecked(3))
            {
                if (!LockDWBSign.Checked) cbDWB_Sign.SelectedIndex = (int)character.DWBStats.Sign;
                if (!LockDWB_FinancialStatus.Checked) cbDWB_FinancialStatus.SelectedIndex = (int)character.DWBStats.FinancialStatus;
                if (!LockDWB_Siblings.Checked) cbDWB_Siblings.SelectedIndex = (int)character.DWBStats.Siblings;

                if (!LockDWB_Childhood.Checked)
                {
                    dgvDWB_Childhood.Rows.Clear();
                    dgvDWB_Childhood.AutoGenerateColumns = true;
                    dgvDWB_Childhood.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    (dgvDWB_Childhood.Columns[0] as DataGridViewComboBoxColumn).DataSource = Enum.GetValues(typeof(Common.Character.DealingWithBackstories.ChildhoodModifiers));
                    foreach (var c in character.DWBStats.Childhood)
                    {
                        int idx = dgvDWB_Childhood.Rows.Add();
                        dgvDWB_Childhood.Rows[idx].Cells[0].Value = c;
                    }
                }

                if (!LockDWB_Interests.Checked)
                {
                    dgvDWB_Adolescence.Rows.Clear();
                    dgvDWB_Adolescence.AutoGenerateColumns = true;
                    dgvDWB_Adolescence.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    (dgvDWB_Adolescence.Columns[0] as DataGridViewComboBoxColumn).DataSource = Enum.GetValues(typeof(Common.Character.DealingWithBackstories.TalentType));
                    foreach (var c in character.DWBStats.Adolescence)
                    {
                        int idx = dgvDWB_Adolescence.Rows.Add();
                        dgvDWB_Adolescence.Rows[idx].Cells[0].Value = c;
                    }
                }

                if (!LockDWB_PastCareers.Checked)
                {
                    dgvDWB_PastCareers.Rows.Clear();
                    dgvDWB_PastCareers.AutoGenerateColumns = true;
                    dgvDWB_PastCareers.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    (dgvDWB_PastCareers.Columns[0] as DataGridViewComboBoxColumn).DataSource = Enum.GetValues(typeof(Common.Character.DealingWithBackstories.CareerModifiers));
                    foreach (var c in character.DWBStats.PastCareers)
                    {
                        int idx = dgvDWB_PastCareers.Rows.Add();
                        dgvDWB_PastCareers.Rows[idx].Cells[0].Value = c;
                    }
                }

                if (!LockDWB_Age.Checked) cbDWB_Age.SelectedIndex = (int)character.DWBStats.Age;
                if (!LockDWB_Parents.Checked) cbDWB_Parents.SelectedIndex = (int)character.DWBStats.ParentsJob;


                if (!LockDWB_Genetics.Checked)
                {
                    dgvDWB_Genetics.Rows.Clear();
                    dgvDWB_Genetics.AutoGenerateColumns = true;
                    (dgvDWB_Genetics.Columns[0] as DataGridViewComboBoxColumn).DataSource = Enum.GetValues(typeof(Common.Character.DealingWithBackstories.GeneticsType));
                    (dgvDWB_Genetics.Columns[1] as DataGridViewComboBoxColumn).DataSource = Enum.GetValues(typeof(Common.Character.DealingWithBackstories.QualityType));
                    foreach (var kv in character.DWBStats.Genetics)
                    {
                        int idx = dgvDWB_Genetics.Rows.Add();
                        dgvDWB_Genetics.Rows[idx].Cells[0].Value = kv.Key;
                        dgvDWB_Genetics.Rows[idx].Cells[1].Value = kv.Value;
                    }
                }

                if (!LockDWB_Vice.Checked) dgbDWB_Vice.SelectedIndex = (int)character.DWBStats.Vice;

                if (!LockDWB_Talent.Checked)
                {
                    cbDWB_Talent.DataSource = Enum.GetValues(typeof(Common.Character.DealingWithBackstories.TalentType));
                    cbDWB_Talent.SelectedIndex = (int)character.DWBStats.Talent;
                }


                if (!LockDWB_Fates.Checked)
                {
                    dgbDWB_Fates.Rows.Clear();
                    dgbDWB_Fates.AutoGenerateColumns = true;
                    (dgbDWB_Fates.Columns[0] as DataGridViewComboBoxColumn).DataSource = Enum.GetValues(typeof(Common.Character.DealingWithBackstories.FateType));
                    foreach (var v in character.DWBStats.Fates)
                    {
                        int idx = dgbDWB_Fates.Rows.Add();
                        dgbDWB_Fates.Rows[idx].Cells[0].Value = v;
                    }
                }


                if (!LockDWB_Focuses.Checked)
                {
                    dgvDWB_Focuses.Rows.Clear();
                    dgvDWB_Focuses.AutoGenerateColumns = true;
                    (dgvDWB_Focuses.Columns[0] as DataGridViewComboBoxColumn).DataSource = Enum.GetValues(typeof(Common.Character.DealingWithBackstories.AspirationType));
                    foreach (var v in character.DWBStats.Focuses)
                    {
                        int idx = dgvDWB_Focuses.Rows.Add();
                        dgvDWB_Focuses.Rows[idx].Cells[0].Value = v;
                    }
                }


                if (!LockDWB_Neglects.Checked)
                {
                    dgvDWB_Neglects.Rows.Clear();
                    dgvDWB_Neglects.AutoGenerateColumns = true;
                    (dgvDWB_Neglects.Columns[0] as DataGridViewComboBoxColumn).DataSource = Enum.GetValues(typeof(Common.Character.DealingWithBackstories.AspirationType));
                    foreach (var v in character.DWBStats.Neglects)
                    {
                        int idx = dgvDWB_Neglects.Rows.Add();
                        dgvDWB_Neglects.Rows[idx].Cells[0].Value = v;
                    }
                }


                if (!LockDWB_Desires.Checked)
                {
                    dgvDWB_Desires.Rows.Clear();
                    dgvDWB_Desires.AutoGenerateColumns = true;
                    (dgvDWB_Desires.Columns[0] as DataGridViewComboBoxColumn).DataSource = Enum.GetValues(typeof(Common.Character.DealingWithBackstories.DesireType));
                    foreach (var v in character.DWBStats.Desires)
                    {
                        int idx = dgvDWB_Desires.Rows.Add();
                        dgvDWB_Desires.Rows[idx].Cells[0].Value = v;
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvLorkhan_Curses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRerollGender_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Rerolling not yet implemented.\nSorry");
        }

        private void btnRerollRace_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Rerolling not yet implemented.\nSorry");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Rerolling not yet implemented.\nSorry");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Rerolling not yet implemented.\nSorry");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Rerolling not yet implemented.\nSorry");
        }

        private void button5_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Rerolling not yet implemented.\nSorry");
        }

        private void button6_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Rerolling not yet implemented.\nSorry");
        }

        private void button7_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Rerolling not yet implemented.\nSorry");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Rerolling not yet implemented.\nSorry");
        }
    }
}

using System;
using System.Windows.Forms;
using _4RTools.Utils;
using _4RTools.Model;
using System.Windows.Input;
namespace _4RTools.Forms
{
    public partial class SkillTimerForm : Form, IObserver
    {
        public SkillTimerForm(Subject subject)
        {
            InitializeComponent();
            subject.Attach(this);


            // Default values skill timer 1
            this.txtSkillTimerKey.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.txtSkillTimerKey.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.txtSkillTimerKey.TextChanged += new EventHandler(this.onSkillTimerKey1Change);
            this.txtAutoRefreshDelay.ValueChanged += new EventHandler(this.txthDelay1TextChanged);
            this.chkClickGround1.CheckedChanged += new EventHandler(this.chkClickGround1Changed);

            // Default values skill timer 2
            this.txtSkillTimerKey2.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.txtSkillTimerKey2.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.txtSkillTimerKey2.TextChanged += new EventHandler(this.onSkillTimerKey2Change);
            this.txtAutoRefreshDelay2.ValueChanged += new EventHandler(this.txthDelay2TextChanged);
            this.chkClickGround2.CheckedChanged += new EventHandler(this.chkClickGround2Changed);

            // Default values skill timer 3
            this.txtSkillTimerKey3.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.txtSkillTimerKey3.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.txtSkillTimerKey3.TextChanged += new EventHandler(this.onSkillTimerKey3Change);
            this.txtAutoRefreshDelay3.ValueChanged += new EventHandler(this.txthDelay3TextChanged);
            this.chkClickGround3.CheckedChanged += new EventHandler(this.chkClickGround3Changed);

            // Ajuste do clique no chão (compartilhado entre os 3 timers)
            GroundClickConfig groundClickConfig = GroundClickConfig.GetCurrent();
            this.numOffsetX.Value = groundClickConfig.OffsetX;
            this.numOffsetY.Value = groundClickConfig.OffsetY;
            this.numClickDelay.Value = groundClickConfig.DelayMs;

            this.numOffsetX.ValueChanged += new EventHandler(this.numOffsetXChanged);
            this.numOffsetY.ValueChanged += new EventHandler(this.numOffsetYChanged);
            this.numClickDelay.ValueChanged += new EventHandler(this.numClickDelayChanged);
            this.btnTestClick.Click += new EventHandler(this.btnTestClickClicked);
        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.code)
            {
                case MessageCode.PROFILE_CHANGED:
                    string skillTimerKey1 = ProfileSingleton.GetCurrent().AutoRefreshSpammer1.RefreshKey.ToString();
                    string autoRefreshDelay1 = ProfileSingleton.GetCurrent().AutoRefreshSpammer1.RefreshDelay.ToString();

                    string skillTimerKey2 = ProfileSingleton.GetCurrent().AutoRefreshSpammer2.RefreshKey.ToString();
                    string autoRefreshDelay2 = ProfileSingleton.GetCurrent().AutoRefreshSpammer2.RefreshDelay.ToString();

                    string skillTimerKey3 = ProfileSingleton.GetCurrent().AutoRefreshSpammer3.RefreshKey.ToString();
                    string autoRefreshDelay3 = ProfileSingleton.GetCurrent().AutoRefreshSpammer3.RefreshDelay.ToString();

                    FormUtils.ResetForm(this);

                    this.txtSkillTimerKey.Text = skillTimerKey1;
                    this.txtAutoRefreshDelay.Text = autoRefreshDelay1;
                    this.chkClickGround1.Checked = ProfileSingleton.GetCurrent().AutoRefreshSpammer1.ClickOnGround;

                    this.txtSkillTimerKey2.Text = skillTimerKey2;
                    this.txtAutoRefreshDelay2.Text = autoRefreshDelay2;
                    this.chkClickGround2.Checked = ProfileSingleton.GetCurrent().AutoRefreshSpammer2.ClickOnGround;

                    this.txtSkillTimerKey3.Text = skillTimerKey3;
                    this.txtAutoRefreshDelay3.Text = autoRefreshDelay3;
                    this.chkClickGround3.Checked = ProfileSingleton.GetCurrent().AutoRefreshSpammer3.ClickOnGround;
                    break;
                case MessageCode.TURN_ON:
                    ProfileSingleton.GetCurrent().AutoRefreshSpammer1.Start();
                    ProfileSingleton.GetCurrent().AutoRefreshSpammer2.Start();
                    ProfileSingleton.GetCurrent().AutoRefreshSpammer3.Start();
                    break;
                case MessageCode.TURN_OFF:
                    ProfileSingleton.GetCurrent().AutoRefreshSpammer1.Stop();
                    ProfileSingleton.GetCurrent().AutoRefreshSpammer2.Stop();
                    ProfileSingleton.GetCurrent().AutoRefreshSpammer3.Stop();
                    break;
            }
        }


        private void onSkillTimerKey1Change(object sender, EventArgs e)
        {
            Key key = (Key)Enum.Parse(typeof(Key), this.txtSkillTimerKey.Text.ToString());
            ProfileSingleton.GetCurrent().AutoRefreshSpammer1.RefreshKey = key;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutoRefreshSpammer1);
        }

        private void onSkillTimerKey2Change(object sender, EventArgs e)
        {
            Key key = (Key)Enum.Parse(typeof(Key), this.txtSkillTimerKey2.Text.ToString());
            ProfileSingleton.GetCurrent().AutoRefreshSpammer2.RefreshKey = key;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutoRefreshSpammer2);
        }

        private void onSkillTimerKey3Change(object sender, EventArgs e)
        {
            Key key = (Key)Enum.Parse(typeof(Key), this.txtSkillTimerKey3.Text.ToString());
            ProfileSingleton.GetCurrent().AutoRefreshSpammer3.RefreshKey = key;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutoRefreshSpammer3);
        }

        private void txthDelay1TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            try
            {
                ProfileSingleton.GetCurrent().AutoRefreshSpammer1.RefreshDelay = Int16.Parse(this.txtAutoRefreshDelay.Text);
                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutoRefreshSpammer1);
            }
            catch(Exception ex) {
                MessageBox.Show($"[SkillTimer] {ex.Message}", "Please share this print screen on 4RTools discord.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txthDelay2TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            try
            {
                ProfileSingleton.GetCurrent().AutoRefreshSpammer2.RefreshDelay = Int16.Parse(this.txtAutoRefreshDelay2.Text);
                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutoRefreshSpammer2);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[SkillTimer] {ex.Message}", "Please share this print screen on 4RTools discord.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txthDelay3TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            try
            {
                ProfileSingleton.GetCurrent().AutoRefreshSpammer3.RefreshDelay = Int16.Parse(this.txtAutoRefreshDelay3.Text);
                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutoRefreshSpammer3);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[SkillTimer] Error Message: {ex.Message}", "Please share this print screen on 4RTools discord.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void chkClickGround1Changed(object sender, EventArgs e)
        {
            ProfileSingleton.GetCurrent().AutoRefreshSpammer1.ClickOnGround = this.chkClickGround1.Checked;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutoRefreshSpammer1);
        }

        private void chkClickGround2Changed(object sender, EventArgs e)
        {
            ProfileSingleton.GetCurrent().AutoRefreshSpammer2.ClickOnGround = this.chkClickGround2.Checked;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutoRefreshSpammer2);
        }

        private void chkClickGround3Changed(object sender, EventArgs e)
        {
            ProfileSingleton.GetCurrent().AutoRefreshSpammer3.ClickOnGround = this.chkClickGround3.Checked;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutoRefreshSpammer3);
        }

        private void numOffsetXChanged(object sender, EventArgs e)
        {
            GroundClickConfig cfg = GroundClickConfig.GetCurrent();
            cfg.OffsetX = (int)this.numOffsetX.Value;
            cfg.Save();
        }

        private void numOffsetYChanged(object sender, EventArgs e)
        {
            GroundClickConfig cfg = GroundClickConfig.GetCurrent();
            cfg.OffsetY = (int)this.numOffsetY.Value;
            cfg.Save();
        }

        private void numClickDelayChanged(object sender, EventArgs e)
        {
            GroundClickConfig cfg = GroundClickConfig.GetCurrent();
            cfg.DelayMs = (int)this.numClickDelay.Value;
            cfg.Save();
        }

        private void btnTestClickClicked(object sender, EventArgs e)
        {
            Client client = ClientSingleton.GetClient();
            if (client == null)
            {
                MessageBox.Show("Selecione um cliente do Ragnarok no topo da tela primeiro.", "4RTools", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GroundClickHelper.ClickGroundInFrontOfWindow(client);
        }
    }
}

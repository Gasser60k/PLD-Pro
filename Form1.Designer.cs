
namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Rtb_code = new RichTextBox();
            Rtb_debugger = new RichTextBox();
            btn_debug = new Button();
            SuspendLayout();
            // 
            // Rtb_code
            // 
            Rtb_code.AcceptsTab = true;
            Rtb_code.BackColor = Color.FromArgb(80, 80, 80);
            Rtb_code.BorderStyle = BorderStyle.None;
            Rtb_code.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Regular, GraphicsUnit.Pixel);
            Rtb_code.ForeColor = Color.White;
            Rtb_code.Location = new Point(66, 95);
            Rtb_code.MaxLength = 5000;
            Rtb_code.Name = "Rtb_code";
            Rtb_code.Size = new Size(1121, 498);
            Rtb_code.TabIndex = 0;
            Rtb_code.Text = "";
            Rtb_code.TextChanged += Rtb_code_TextChanged;
            // 
            // Rtb_debugger
            // 
            Rtb_debugger.BackColor = Color.FromArgb(80, 80, 80);
            Rtb_debugger.BorderStyle = BorderStyle.None;
            Rtb_debugger.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Regular, GraphicsUnit.Pixel);
            Rtb_debugger.ForeColor = Color.White;
            Rtb_debugger.Location = new Point(66, 764);
            Rtb_debugger.MaxLength = 5000;
            Rtb_debugger.Name = "Rtb_debugger";
            Rtb_debugger.ReadOnly = true;
            Rtb_debugger.Size = new Size(1121, 244);
            Rtb_debugger.TabIndex = 1;
            Rtb_debugger.Text = "";
            // 
            // btn_debug
            // 
            btn_debug.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_debug.BackColor = Color.FromArgb(50, 50, 50);
            btn_debug.Font = new Font("Microsoft Sans Serif", 15.8571434F, FontStyle.Regular, GraphicsUnit.Point);
            btn_debug.Location = new Point(445, 625);
            btn_debug.Margin = new Padding(4, 6, 4, 6);
            btn_debug.Name = "btn_debug";
            btn_debug.Size = new Size(321, 90);
            btn_debug.TabIndex = 2;
            btn_debug.Text = "Debug";
            btn_debug.UseVisualStyleBackColor = true;
            btn_debug.Click += btn_debug_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(23F, 48F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 50);
            ClientSize = new Size(1245, 1079);
            Controls.Add(btn_debug);
            Controls.Add(Rtb_debugger);
            Controls.Add(Rtb_code);
            Font = new Font("Segoe UI Black", 36F, FontStyle.Bold, GraphicsUnit.Pixel);
            Name = "Form1";
            Text = "PrincePL";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox Rtb_code;
        private RichTextBox Rtb_debugger;
        private Button btn_debug;
    }
}
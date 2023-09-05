namespace FlowActivationOrder
{
    partial class MainControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.solutionsToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.generateToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowsDataGridView = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.almAcceleratorConfigsTextBox = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.flowsOrderedListTextBox = new System.Windows.Forms.TextBox();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flowsDataGridView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.solutionsToolStripDropDownButton,
            this.generateToolStripButton});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1157, 34);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(129, 29);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // solutionsToolStripDropDownButton
            // 
            this.solutionsToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.solutionsToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.solutionsToolStripDropDownButton.Name = "solutionsToolStripDropDownButton";
            this.solutionsToolStripDropDownButton.Size = new System.Drawing.Size(104, 29);
            this.solutionsToolStripDropDownButton.Text = "Solutions";
            this.solutionsToolStripDropDownButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.solutionsToolStripDropDownButton_DropDownItemClicked);
            // 
            // generateToolStripButton
            // 
            this.generateToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.generateToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.generateToolStripButton.Name = "generateToolStripButton";
            this.generateToolStripButton.Size = new System.Drawing.Size(86, 29);
            this.generateToolStripButton.Text = "Generate";
            this.generateToolStripButton.Click += new System.EventHandler(this.generateToolStripButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 34);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowsDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1157, 562);
            this.splitContainer1.SplitterDistance = 555;
            this.splitContainer1.TabIndex = 5;
            // 
            // flowsDataGridView
            // 
            this.flowsDataGridView.AllowUserToAddRows = false;
            this.flowsDataGridView.AllowUserToDeleteRows = false;
            this.flowsDataGridView.AllowUserToResizeRows = false;
            this.flowsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.flowsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.flowsDataGridView.Name = "flowsDataGridView";
            this.flowsDataGridView.ReadOnly = true;
            this.flowsDataGridView.RowHeadersVisible = false;
            this.flowsDataGridView.RowHeadersWidth = 62;
            this.flowsDataGridView.RowTemplate.Height = 28;
            this.flowsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.flowsDataGridView.Size = new System.Drawing.Size(555, 562);
            this.flowsDataGridView.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(598, 562);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.almAcceleratorConfigsTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(590, 529);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ALM Accelerator Configuration";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // almAcceleratorConfigsTextBox
            // 
            this.almAcceleratorConfigsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.almAcceleratorConfigsTextBox.Location = new System.Drawing.Point(3, 3);
            this.almAcceleratorConfigsTextBox.Multiline = true;
            this.almAcceleratorConfigsTextBox.Name = "almAcceleratorConfigsTextBox";
            this.almAcceleratorConfigsTextBox.ReadOnly = true;
            this.almAcceleratorConfigsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.almAcceleratorConfigsTextBox.Size = new System.Drawing.Size(584, 523);
            this.almAcceleratorConfigsTextBox.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer2);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(590, 529);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Visual";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.flowsOrderedListTextBox);
            this.splitContainer2.Size = new System.Drawing.Size(590, 529);
            this.splitContainer2.SplitterDistance = 196;
            this.splitContainer2.TabIndex = 0;
            // 
            // flowsOrderedListTextBox
            // 
            this.flowsOrderedListTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowsOrderedListTextBox.Location = new System.Drawing.Point(0, 0);
            this.flowsOrderedListTextBox.Multiline = true;
            this.flowsOrderedListTextBox.Name = "flowsOrderedListTextBox";
            this.flowsOrderedListTextBox.ReadOnly = true;
            this.flowsOrderedListTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.flowsOrderedListTextBox.Size = new System.Drawing.Size(196, 529);
            this.flowsOrderedListTextBox.TabIndex = 2;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(1157, 596);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flowsDataGridView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton solutionsToolStripDropDownButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox almAcceleratorConfigsTextBox;
        private System.Windows.Forms.ToolStripButton generateToolStripButton;
        private System.Windows.Forms.DataGridView flowsDataGridView;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox flowsOrderedListTextBox;
    }
}

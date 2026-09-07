namespace 自动测试
{
    partial class 运动控制控件
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            主运组 = new GroupBox();
            回零慢速框 = new NumericUpDown();
            最小脉冲框 = new NumericUpDown();
            单圈脉冲框 = new NumericUpDown();
            Y轴最小行程标签 = new Label();
            Z轴最小行程标签 = new Label();
            Y轴导程标签 = new Label();
            最大脉冲框 = new NumericUpDown();
            回零快速框 = new NumericUpDown();
            Z最大行程标签 = new Label();
            Y轴最大行程标签 = new Label();
            导程框 = new NumericUpDown();
            Z轴导程标签 = new Label();
            numericUpDown13 = new NumericUpDown();
            numericUpDown12 = new NumericUpDown();
            Y轴加减速时间 = new Label();
            numericUpDown17 = new NumericUpDown();
            numericUpDown11 = new NumericUpDown();
            Z轴加减速时间标签 = new Label();
            Y轴手动速度标签 = new Label();
            Y轴回零慢速标签 = new Label();
            numericUpDown16 = new NumericUpDown();
            numericUpDown10 = new NumericUpDown();
            Z轴手动速度标签 = new Label();
            Y轴回零快速 = new Label();
            numericUpDown15 = new NumericUpDown();
            numericUpDown9 = new NumericUpDown();
            Y轴自动速度标签 = new Label();
            Z轴回零慢速标签 = new Label();
            numericUpDown14 = new NumericUpDown();
            Z轴自动速度标签 = new Label();
            numericUpDown8 = new NumericUpDown();
            Z轴回零快速标签 = new Label();
            主运组.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)回零慢速框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)最小脉冲框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)单圈脉冲框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)最大脉冲框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)回零快速框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)导程框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown13).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown17).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown16).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown15).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown14).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).BeginInit();
            SuspendLayout();
            // 
            // 主运组
            // 
            主运组.Controls.Add(numericUpDown13);
            主运组.Controls.Add(numericUpDown17);
            主运组.Controls.Add(回零慢速框);
            主运组.Controls.Add(Y轴手动速度标签);
            主运组.Controls.Add(numericUpDown12);
            主运组.Controls.Add(numericUpDown16);
            主运组.Controls.Add(最小脉冲框);
            主运组.Controls.Add(Z轴手动速度标签);
            主运组.Controls.Add(Y轴加减速时间);
            主运组.Controls.Add(numericUpDown15);
            主运组.Controls.Add(Y轴自动速度标签);
            主运组.Controls.Add(单圈脉冲框);
            主运组.Controls.Add(numericUpDown14);
            主运组.Controls.Add(numericUpDown11);
            主运组.Controls.Add(Z轴自动速度标签);
            主运组.Controls.Add(Y轴最小行程标签);
            主运组.Controls.Add(Z轴最小行程标签);
            主运组.Controls.Add(Z轴加减速时间标签);
            主运组.Controls.Add(Y轴导程标签);
            主运组.Controls.Add(Y轴回零慢速标签);
            主运组.Controls.Add(最大脉冲框);
            主运组.Controls.Add(numericUpDown10);
            主运组.Controls.Add(回零快速框);
            主运组.Controls.Add(Z最大行程标签);
            主运组.Controls.Add(Y轴回零快速);
            主运组.Controls.Add(Y轴最大行程标签);
            主运组.Controls.Add(导程框);
            主运组.Controls.Add(numericUpDown9);
            主运组.Controls.Add(Z轴导程标签);
            主运组.Controls.Add(Z轴回零快速标签);
            主运组.Controls.Add(Z轴回零慢速标签);
            主运组.Controls.Add(numericUpDown8);
            主运组.Location = new Point(20, 20);
            主运组.Name = "主运组";
            主运组.Size = new Size(1157, 460);
            主运组.TabIndex = 0;
            主运组.TabStop = false;
            主运组.Text = "伺服设置";
            // 
            // 回零慢速框
            // 
            回零慢速框.DecimalPlaces = 3;
            回零慢速框.Location = new Point(117, 328);
            回零慢速框.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            回零慢速框.Name = "回零慢速框";
            回零慢速框.Size = new Size(80, 23);
            回零慢速框.TabIndex = 16;
            回零慢速框.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // 最小脉冲框
            // 
            最小脉冲框.DecimalPlaces = 3;
            最小脉冲框.Location = new Point(117, 210);
            最小脉冲框.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            最小脉冲框.Name = "最小脉冲框";
            最小脉冲框.Size = new Size(80, 23);
            最小脉冲框.TabIndex = 16;
            最小脉冲框.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // 单圈脉冲框
            // 
            单圈脉冲框.DecimalPlaces = 3;
            单圈脉冲框.Location = new Point(117, 92);
            单圈脉冲框.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            单圈脉冲框.Name = "单圈脉冲框";
            单圈脉冲框.Size = new Size(80, 23);
            单圈脉冲框.TabIndex = 16;
            单圈脉冲框.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // Y轴最小行程标签
            // 
            Y轴最小行程标签.Location = new Point(16, 328);
            Y轴最小行程标签.Name = "Y轴最小行程标签";
            Y轴最小行程标签.Size = new Size(95, 23);
            Y轴最小行程标签.TabIndex = 15;
            Y轴最小行程标签.Text = "Y轴最小行程：";
            Y轴最小行程标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Z轴最小行程标签
            // 
            Z轴最小行程标签.Location = new Point(16, 210);
            Z轴最小行程标签.Name = "Z轴最小行程标签";
            Z轴最小行程标签.Size = new Size(95, 23);
            Z轴最小行程标签.TabIndex = 15;
            Z轴最小行程标签.Text = "Z轴最小行程：";
            Z轴最小行程标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Y轴导程标签
            // 
            Y轴导程标签.Location = new Point(16, 92);
            Y轴导程标签.Name = "Y轴导程标签";
            Y轴导程标签.Size = new Size(95, 23);
            Y轴导程标签.TabIndex = 15;
            Y轴导程标签.Text = "Y轴导程：";
            Y轴导程标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // 最大脉冲框
            // 
            最大脉冲框.DecimalPlaces = 3;
            最大脉冲框.Location = new Point(117, 151);
            最大脉冲框.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            最大脉冲框.Name = "最大脉冲框";
            最大脉冲框.Size = new Size(80, 23);
            最大脉冲框.TabIndex = 14;
            最大脉冲框.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // 回零快速框
            // 
            回零快速框.DecimalPlaces = 3;
            回零快速框.Location = new Point(117, 269);
            回零快速框.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            回零快速框.Name = "回零快速框";
            回零快速框.Size = new Size(80, 23);
            回零快速框.TabIndex = 14;
            回零快速框.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // Z最大行程标签
            // 
            Z最大行程标签.Location = new Point(16, 151);
            Z最大行程标签.Name = "Z最大行程标签";
            Z最大行程标签.Size = new Size(95, 23);
            Z最大行程标签.TabIndex = 13;
            Z最大行程标签.Text = "Z轴最大行程：";
            Z最大行程标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Y轴最大行程标签
            // 
            Y轴最大行程标签.Location = new Point(16, 269);
            Y轴最大行程标签.Name = "Y轴最大行程标签";
            Y轴最大行程标签.Size = new Size(95, 23);
            Y轴最大行程标签.TabIndex = 13;
            Y轴最大行程标签.Text = "Y轴最大行程：";
            Y轴最大行程标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // 导程框
            // 
            导程框.DecimalPlaces = 3;
            导程框.Location = new Point(117, 33);
            导程框.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            导程框.Name = "导程框";
            导程框.Size = new Size(80, 23);
            导程框.TabIndex = 14;
            导程框.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // Z轴导程标签
            // 
            Z轴导程标签.Location = new Point(16, 33);
            Z轴导程标签.Name = "Z轴导程标签";
            Z轴导程标签.Size = new Size(95, 23);
            Z轴导程标签.TabIndex = 13;
            Z轴导程标签.Text = "Z轴导程：";
            Z轴导程标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numericUpDown13
            // 
            numericUpDown13.DecimalPlaces = 3;
            numericUpDown13.Location = new Point(357, 328);
            numericUpDown13.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown13.Name = "numericUpDown13";
            numericUpDown13.Size = new Size(80, 23);
            numericUpDown13.TabIndex = 14;
            numericUpDown13.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // numericUpDown12
            // 
            numericUpDown12.DecimalPlaces = 3;
            numericUpDown12.Location = new Point(357, 269);
            numericUpDown12.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown12.Name = "numericUpDown12";
            numericUpDown12.Size = new Size(80, 23);
            numericUpDown12.TabIndex = 14;
            numericUpDown12.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // Y轴加减速时间
            // 
            Y轴加减速时间.Location = new Point(244, 328);
            Y轴加减速时间.Name = "Y轴加减速时间";
            Y轴加减速时间.Size = new Size(108, 23);
            Y轴加减速时间.TabIndex = 13;
            Y轴加减速时间.Text = "Y轴加减速时间：";
            Y轴加减速时间.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numericUpDown17
            // 
            numericUpDown17.DecimalPlaces = 3;
            numericUpDown17.Location = new Point(596, 210);
            numericUpDown17.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown17.Name = "numericUpDown17";
            numericUpDown17.Size = new Size(80, 23);
            numericUpDown17.TabIndex = 14;
            numericUpDown17.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // numericUpDown11
            // 
            numericUpDown11.DecimalPlaces = 3;
            numericUpDown11.Location = new Point(357, 210);
            numericUpDown11.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown11.Name = "numericUpDown11";
            numericUpDown11.Size = new Size(80, 23);
            numericUpDown11.TabIndex = 14;
            numericUpDown11.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // Z轴加减速时间标签
            // 
            Z轴加减速时间标签.Location = new Point(244, 269);
            Z轴加减速时间标签.Name = "Z轴加减速时间标签";
            Z轴加减速时间标签.Size = new Size(108, 23);
            Z轴加减速时间标签.TabIndex = 13;
            Z轴加减速时间标签.Text = "Z轴加减速时间：";
            Z轴加减速时间标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Y轴手动速度标签
            // 
            Y轴手动速度标签.Location = new Point(489, 210);
            Y轴手动速度标签.Name = "Y轴手动速度标签";
            Y轴手动速度标签.Size = new Size(95, 23);
            Y轴手动速度标签.TabIndex = 13;
            Y轴手动速度标签.Text = "Y轴手动速度：";
            Y轴手动速度标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Y轴回零慢速标签
            // 
            Y轴回零慢速标签.Location = new Point(251, 210);
            Y轴回零慢速标签.Name = "Y轴回零慢速标签";
            Y轴回零慢速标签.Size = new Size(95, 23);
            Y轴回零慢速标签.TabIndex = 13;
            Y轴回零慢速标签.Text = "Y轴回零慢速：";
            Y轴回零慢速标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numericUpDown16
            // 
            numericUpDown16.DecimalPlaces = 3;
            numericUpDown16.Location = new Point(596, 151);
            numericUpDown16.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown16.Name = "numericUpDown16";
            numericUpDown16.Size = new Size(80, 23);
            numericUpDown16.TabIndex = 14;
            numericUpDown16.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // numericUpDown10
            // 
            numericUpDown10.DecimalPlaces = 3;
            numericUpDown10.Location = new Point(357, 151);
            numericUpDown10.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown10.Name = "numericUpDown10";
            numericUpDown10.Size = new Size(80, 23);
            numericUpDown10.TabIndex = 14;
            numericUpDown10.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // Z轴手动速度标签
            // 
            Z轴手动速度标签.Location = new Point(489, 151);
            Z轴手动速度标签.Name = "Z轴手动速度标签";
            Z轴手动速度标签.Size = new Size(95, 23);
            Z轴手动速度标签.TabIndex = 13;
            Z轴手动速度标签.Text = "Z轴手动速度：";
            Z轴手动速度标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Y轴回零快速
            // 
            Y轴回零快速.Location = new Point(251, 151);
            Y轴回零快速.Name = "Y轴回零快速";
            Y轴回零快速.Size = new Size(95, 23);
            Y轴回零快速.TabIndex = 13;
            Y轴回零快速.Text = "Y轴回零快速：";
            Y轴回零快速.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numericUpDown15
            // 
            numericUpDown15.DecimalPlaces = 3;
            numericUpDown15.Location = new Point(596, 92);
            numericUpDown15.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown15.Name = "numericUpDown15";
            numericUpDown15.Size = new Size(80, 23);
            numericUpDown15.TabIndex = 14;
            numericUpDown15.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // numericUpDown9
            // 
            numericUpDown9.DecimalPlaces = 3;
            numericUpDown9.Location = new Point(357, 92);
            numericUpDown9.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown9.Name = "numericUpDown9";
            numericUpDown9.Size = new Size(80, 23);
            numericUpDown9.TabIndex = 14;
            numericUpDown9.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // Y轴自动速度标签
            // 
            Y轴自动速度标签.Location = new Point(489, 92);
            Y轴自动速度标签.Name = "Y轴自动速度标签";
            Y轴自动速度标签.Size = new Size(95, 23);
            Y轴自动速度标签.TabIndex = 13;
            Y轴自动速度标签.Text = "Y轴自动速度：";
            Y轴自动速度标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Z轴回零慢速标签
            // 
            Z轴回零慢速标签.Location = new Point(251, 92);
            Z轴回零慢速标签.Name = "Z轴回零慢速标签";
            Z轴回零慢速标签.Size = new Size(95, 23);
            Z轴回零慢速标签.TabIndex = 13;
            Z轴回零慢速标签.Text = "Z轴回零慢速：";
            Z轴回零慢速标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numericUpDown14
            // 
            numericUpDown14.DecimalPlaces = 3;
            numericUpDown14.Location = new Point(596, 33);
            numericUpDown14.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown14.Name = "numericUpDown14";
            numericUpDown14.Size = new Size(80, 23);
            numericUpDown14.TabIndex = 14;
            numericUpDown14.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // Z轴自动速度标签
            // 
            Z轴自动速度标签.Location = new Point(489, 33);
            Z轴自动速度标签.Name = "Z轴自动速度标签";
            Z轴自动速度标签.Size = new Size(95, 23);
            Z轴自动速度标签.TabIndex = 13;
            Z轴自动速度标签.Text = "Z轴自动速度：";
            Z轴自动速度标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numericUpDown8
            // 
            numericUpDown8.DecimalPlaces = 3;
            numericUpDown8.Location = new Point(357, 33);
            numericUpDown8.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown8.Name = "numericUpDown8";
            numericUpDown8.Size = new Size(80, 23);
            numericUpDown8.TabIndex = 14;
            numericUpDown8.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // Z轴回零快速标签
            // 
            Z轴回零快速标签.Location = new Point(251, 33);
            Z轴回零快速标签.Name = "Z轴回零快速标签";
            Z轴回零快速标签.Size = new Size(95, 23);
            Z轴回零快速标签.TabIndex = 13;
            Z轴回零快速标签.Text = "Z轴回零快速：";
            Z轴回零快速标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // 运动控制控件
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(主运组);
            Name = "运动控制控件";
            Size = new Size(1200, 500);
            主运组.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)回零慢速框).EndInit();
            ((System.ComponentModel.ISupportInitialize)最小脉冲框).EndInit();
            ((System.ComponentModel.ISupportInitialize)单圈脉冲框).EndInit();
            ((System.ComponentModel.ISupportInitialize)最大脉冲框).EndInit();
            ((System.ComponentModel.ISupportInitialize)回零快速框).EndInit();
            ((System.ComponentModel.ISupportInitialize)导程框).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown13).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown12).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown17).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown11).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown16).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown10).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown15).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown9).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown14).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).EndInit();
            ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox 主运组;

        private NumericUpDown 导程框;
        private Label Z轴导程标签;
        private NumericUpDown 回零慢速框;
        private NumericUpDown 最小脉冲框;
        private NumericUpDown 单圈脉冲框;
        private Label Y轴最小行程标签;
        private Label Z轴最小行程标签;
        private Label Y轴导程标签;
        private NumericUpDown 最大脉冲框;
        private NumericUpDown 回零快速框;
        private Label Z最大行程标签;
        private Label Y轴最大行程标签;
        private NumericUpDown numericUpDown13;
        private NumericUpDown numericUpDown12;
        private Label Y轴加减速时间;
        private NumericUpDown numericUpDown17;
        private NumericUpDown numericUpDown11;
        private Label Z轴加减速时间标签;
        private Label Y轴手动速度标签;
        private Label Y轴回零慢速标签;
        private NumericUpDown numericUpDown16;
        private NumericUpDown numericUpDown10;
        private Label Z轴手动速度标签;
        private Label Y轴回零快速;
        private NumericUpDown numericUpDown15;
        private NumericUpDown numericUpDown9;
        private Label Y轴自动速度标签;
        private Label Z轴回零慢速标签;
        private NumericUpDown numericUpDown14;
        private Label Z轴自动速度标签;
        private NumericUpDown numericUpDown8;
        private Label Z轴回零快速标签;
    }
}
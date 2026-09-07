using System;
using System.Windows.Forms;

namespace 自动测试
{
    public partial class 运动控制控件 : UserControl
    {
        private 系统配置数据 配置数据;

        public 运动控制控件()
        {
            InitializeComponent();
        }

        public void 设置配置数据(系统配置数据 数据)
        {
            配置数据 = 数据;
            加载配置();
        }

        public void 加载配置()
        {
            if (配置数据 == null) return;
            
            导程框.Value = (decimal)配置数据.运动控制.主运一圈距离;
            单圈脉冲框.Value = 配置数据.运动控制.主运一圈脉冲;
            最大脉冲框.Value = 配置数据.运动控制.主运最大脉冲;
            最小脉冲框.Value = 配置数据.运动控制.主运最小脉冲;
            回零快速框.Value = 配置数据.运动控制.主运归零脉冲;
            numericUpDown12.Value = (decimal)配置数据.运动控制.主运减速时间;
            numericUpDown13.Value = 配置数据.运动控制.主运计数时间;
            numericUpDown8.Value = (decimal)配置数据.运动控制.主运保留参数;
            
            回零慢速框.Value = (decimal)配置数据.运动控制.Z轴导程;
            numericUpDown9.Value = 配置数据.运动控制.Z轴回零慢速;
            numericUpDown10.Value = 配置数据.运动控制.Z轴回零快速;
            numericUpDown11.Value = (decimal)配置数据.运动控制.Z轴加减速时间;
            numericUpDown14.Value = 配置数据.运动控制.Z轴自动速度;
            numericUpDown15.Value = 配置数据.运动控制.Y轴自动速度;
            numericUpDown16.Value = 配置数据.运动控制.Z轴手动速度;
            numericUpDown17.Value = 配置数据.运动控制.Y轴手动速度;
        }

        public void 保存配置()
        {
            if (配置数据 == null) return;
            
            配置数据.运动控制.主运一圈距离 = (double)导程框.Value;
            配置数据.运动控制.主运一圈脉冲 = (int)单圈脉冲框.Value;
            配置数据.运动控制.主运最大脉冲 = (int)最大脉冲框.Value;
            配置数据.运动控制.主运最小脉冲 = (int)最小脉冲框.Value;
            配置数据.运动控制.主运归零脉冲 = (int)回零快速框.Value;
            配置数据.运动控制.主运减速时间 = (double)numericUpDown12.Value;
            配置数据.运动控制.主运计数时间 = (int)numericUpDown13.Value;
            配置数据.运动控制.主运保留参数 = (double)numericUpDown8.Value;
            
            配置数据.运动控制.Z轴导程 = (double)回零慢速框.Value;
            配置数据.运动控制.Z轴回零慢速 = (int)numericUpDown9.Value;
            配置数据.运动控制.Z轴回零快速 = (int)numericUpDown10.Value;
            配置数据.运动控制.Z轴加减速时间 = (double)numericUpDown11.Value;
            配置数据.运动控制.Z轴自动速度 = (int)numericUpDown14.Value;
            配置数据.运动控制.Y轴自动速度 = (int)numericUpDown15.Value;
            配置数据.运动控制.Z轴手动速度 = (int)numericUpDown16.Value;
            配置数据.运动控制.Y轴手动速度 = (int)numericUpDown17.Value;
        }
    }
}
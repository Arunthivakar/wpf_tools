using ATAV.Tools.WPF_2026.Controls.ButtonControls.Button.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace ATAV.Tools.WPF_2026.Controls
{
    internal interface IButtonAdv
    {
        string Label { get; set; }
        ImageSource LageIcon { get; set; }
        ImageSource SmallIcon { get; set; }
        bool IsMultiLine { get; set; }
        SizeMode SizeMode { get; set; }
    }
}

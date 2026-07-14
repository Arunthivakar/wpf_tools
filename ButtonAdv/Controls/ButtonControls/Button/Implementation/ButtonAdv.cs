using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace ATAV.Tools.WPF_2026.Controls.ButtonControls.Button.Implementation
{
    internal class ButtonAdv : ButtonBase, ICommandSource, IButtonAdv
    {
        #region Constants Fields
        private const double SmallIconHeight = 16.0;
        private const double SmallIconWidth = 16.0;
        private const double MediumIconHeight = 20.0;
        private const double MediumIconWidth = 20.0;
        private const double LargeIconHeight = 26.0;
        private const double LargeIconWidth = 26.0;
        #endregion

        #region Initialization
        public ButtonAdv()
        {
            Initialize();
        }
        private void Initialize()
        {
            accessText = GetTemplateChild("accessText") as AccessText;
            smallIcon = GetTemplateChild("smallIcon") as ContentPresenter;
            mediumIcon = GetTemplateChild("mediumIcon") as ContentPresenter;
            largeIcon = GetTemplateChild("largeIcon") as ContentPresenter;
            UpdateSize();

        }
        #endregion

        #region Private Variables
        private AccessText accessText;
        private ContentPresenter smallIcon;
        private ContentPresenter mediumIcon;
        private ContentPresenter largeIcon;
        #endregion

        #region Dependency Properties
        public bool IsCancel
        {
            get { return (bool)GetValue(IsCancelProperty); }
            set { SetValue(IsCancelProperty, value); }
        }
        public static readonly DependencyProperty IsCancelProperty =
    DependencyProperty.Register("IsCancel", typeof(bool), typeof(ButtonAdv), new PropertyMetadata(new PropertyChangedCallback(OnIsCancelChanged)));

        public bool IsDefault
        {
            get { return (bool)GetValue(IsDefaultProperty); }
            set { SetValue(IsDefaultProperty, value); }
        }
        public static readonly DependencyProperty IsDefaultProperty =
    DependencyProperty.Register("IsDefault", typeof(bool), typeof(ButtonAdv), new PropertyMetadata(new PropertyChangedCallback(OnIsDefaultChanged)));

        public Stretch IconStretch
        {
            get { return (Stretch)GetValue(IconStretchProperty); }
            set { SetValue(IconStretchProperty, value); }
        }
        public static readonly DependencyProperty IconStretchProperty =
    DependencyProperty.Register("IconStretch", typeof(Stretch), typeof(ButtonAdv), new PropertyMetadata(Stretch.Uniform));

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }
        public static readonly DependencyProperty LabelProperty =
    DependencyProperty.Register("Label", typeof(string), typeof(ButtonAdv), new PropertyMetadata("Button"));

        public DataTemplate IconTemplate
        {
            get { return (DataTemplate)GetValue(IconTemplateProperty); }
            set { SetValue(IconTemplateProperty, value); }
        }
        public static readonly DependencyProperty IconTemplateProperty =
    DependencyProperty.Register("IconTemplate", typeof(DataTemplate), typeof(ButtonAdv), new PropertyMetadata(null));

        public DataTemplateSelector IconTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(IconTemplateSelectorProperty); }
            set { SetValue(IconTemplateSelectorProperty, value); }
        }
        public static readonly DependencyProperty IconTemplateSelectorProperty =
    DependencyProperty.Register("IconTemplateSelector", typeof(DataTemplateSelector), typeof(ButtonAdv), new PropertyMetadata(null));

        public bool IsCheckable
        {
            get { return (bool)GetValue(IsCheckableProperty); }
            set { SetValue(IsCheckableProperty, value); }
        }
        public static readonly DependencyProperty IsCheckableProperty =
    DependencyProperty.Register("IsCheckable", typeof(bool), typeof(ButtonAdv), new PropertyMetadata(false, new PropertyChangedCallback(OnIsCheckableChanged)));

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }
        public static readonly DependencyProperty IsCheckedProperty =
   DependencyProperty.Register("IsChecked", typeof(bool), typeof(ButtonAdv), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnIsCheckedChanged)));

        public ImageSource LargeIcon
        {
            get { return (ImageSource)GetValue(LargeIconProperty); }
            set { SetValue(LargeIconProperty, value); }
        }
        public static readonly DependencyProperty LargeIconProperty =
    DependencyProperty.Register("LargeIcon", typeof(ImageSource), typeof(ButtonAdv), new PropertyMetadata(null));

        public ImageSource SmallIcon
        {
            get { return (ImageSource)GetValue(SmallIconProperty); }
            set { SetValue(SmallIconProperty, value); }
        }
        public static readonly DependencyProperty SmallIconProperty =
    DependencyProperty.Register("SmallIcon", typeof(ImageSource), typeof(ButtonAdv), new PropertyMetadata(null));

        public ImageSource MediumIcon
        {
            get { return (ImageSource)GetValue(MediumIconroperty); }
            set { SetValue(MediumIconroperty, value); }
        }
        public static readonly DependencyProperty MediumIconroperty =
    DependencyProperty.Register("MediumIcon", typeof(ImageSource), typeof(ButtonAdv), new PropertyMetadata(null));

        public double IconWidth
        {
            get { return (double)GetValue(IconWidthProperty); }
            set { SetValue(IconWidthProperty, value); }
        }
        public static readonly DependencyProperty IconWidthProperty =
    DependencyProperty.Register("IconWidth", typeof(double), typeof(ButtonAdv), new PropertyMetadata(16.0, new PropertyChangedCallback(OnSizeChanged)));

        public double IconHeight
        {
            get { return (double)GetValue(IconHeightProperty); }
            set { SetValue(IconHeightProperty, value); }
        }
        public static readonly DependencyProperty IconHeightProperty =
    DependencyProperty.Register("IconHeight", typeof(double), typeof(ButtonAdv), new PropertyMetadata(16.0, new PropertyChangedCallback(OnSizeChanged)));

        public bool IsMultiLine
        {
            get { return (bool)GetValue(IsMultiLineProperty); }
            set { SetValue(IsMultiLineProperty, value); }
        }
        public static readonly DependencyProperty IsMultiLineProperty =
    DependencyProperty.Register("IsMultiLine", typeof(bool), typeof(ButtonAdv), new PropertyMetadata(true));

        public SizeMode SizeMode
        {
            get { return (SizeMode)GetValue(SizeModeProperty); }
            set { SetValue(SizeModeProperty, value); }
        }
        public static readonly DependencyProperty SizeModeProperty =
    DependencyProperty.Register("SizeMode", typeof(SizeMode), typeof(ButtonAdv), new PropertyMetadata(SizeMode.Medium, new PropertyChangedCallback(OnSizeChanged)));
        #endregion

        #region SizeChanged
        public void UpdateSize()
        {
            if (this.SizeMode == SizeMode.Small)
            {
                if (smallIcon != null)
                {
                    smallIcon.Width = this.IconWidth == 16.0 ? (this.SmallIcon != null || this.IconTemplate != null || this.IconTemplateSelector != null) ? SmallIconWidth : 0 : this.IconWidth;
                    smallIcon.Height = this.IconHeight == 16.0 ? (this.SmallIcon != null || this.IconTemplate != null || this.IconTemplateSelector != null) ? SmallIconHeight : 0 : this.IconHeight;
                }
            }
            else if (this.SizeMode == SizeMode.Medium)
            {
                mediumIcon.Width = this.IconWidth == 20.0 ? (this.MediumIcon != null || this.IconTemplate != null || this.IconTemplateSelector != null) ? MediumIconWidth : 0 : this.IconWidth;
                mediumIcon.Height = this.IconHeight == 20.0 ? (this.MediumIcon != null || this.IconTemplate != null || this.IconTemplateSelector != null) ? MediumIconHeight : 0 : this.IconHeight;

            }
            else
            {
                if (largeIcon != null)
                {
                    largeIcon.Width = this.IconWidth == 26.0 ? (this.LargeIcon != null || this.IconTemplate != null || this.IconTemplateSelector != null) ? LargeIconWidth : 0 : this.IconWidth;
                    largeIcon.Height = this.IconHeight == 26.0 ? (this.LargeIcon != null || this.IconTemplate != null || this.IconTemplateSelector != null) ? LargeIconHeight : 0 : this.IconHeight;
                }
            }
            if (accessText != null)
                accessText.Visibility = this.SizeMode == SizeMode.Medium ? Visibility.Visible : Visibility.Collapsed;
        }

        private static void OnSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as ButtonAdv;
            var iconTemplate = sender.IconTemplateSelector;
            if (sender.IconTemplateSelector != null)
            {
                sender.IconTemplateSelector = null;
                sender.IconTemplateSelector = iconTemplate;
            }
            sender.OnSizeChanged();
        }
        private void OnSizeChanged()
        {
            UpdateSize();
        }
        #endregion

        #region CheckChanged
        private static void OnIsCheckableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as ButtonAdv;
            sender.OnIsCheckableChanged();
        }
        private void OnIsCheckableChanged()
        {
            if (IsChecked)
                IsChecked = false;
            OnIsCheckedChanged();
        }
        private static void OnIsCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as ButtonAdv;
            sender.OnIsCheckedChanged();
        }
        private void OnIsCheckedChanged()
        {
            if (IsCheckable && Checked != null)
                Checked(this, new RoutedEventArgs());
        }
        #endregion

        #region Events
        public event RoutedEventHandler Checked;
        #endregion

        #region Overrides
        public override void OnApplyTemplate()
        {
            Initialize();
            base.OnApplyTemplate();
        }
        protected override void OnClick()
        {
            base.OnClick();
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (IsCheckable)
                IsChecked = !IsChecked;

            base.OnMouseLeftButtonDown(e);
        }
        #endregion

        private static void OnIsCancelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }
        private static void OnIsDefaultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }
    }
    public enum SizeMode
    {
        Small,
        Medium,
        Large
    }
}

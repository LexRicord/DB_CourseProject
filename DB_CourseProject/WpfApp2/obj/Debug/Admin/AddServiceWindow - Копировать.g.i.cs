// Updated by XamlIntelliSenseFileGenerator 04.01.2023 5:09:00
#pragma checksum "..\..\..\Admin\AddServiceWindow - Копировать.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1E6CCFA3493FA01E78EA4013E8C23510ED08FDF478E58B20F6B10FC7BCDDB331"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WpfApp2.Admin;


namespace WpfApp2.Admin
{


    /// <summary>
    /// AddService
    /// </summary>
    public partial class AddType : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 35 "..\..\..\Admin\AddServiceWindow - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox serviceNameText;

#line default
#line hidden


#line 53 "..\..\..\Admin\AddServiceWindow - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox priceText;

#line default
#line hidden


#line 72 "..\..\..\Admin\AddServiceWindow - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addTariffPlanButton;

#line default
#line hidden


#line 75 "..\..\..\Admin\AddServiceWindow - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox unlimMinutesCheck;

#line default
#line hidden


#line 77 "..\..\..\Admin\AddServiceWindow - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox unlimSMSCheck;

#line default
#line hidden


#line 79 "..\..\..\Admin\AddServiceWindow - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox unlimMMSCheck;

#line default
#line hidden


#line 81 "..\..\..\Admin\AddServiceWindow - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox unlimMegabytesCheck;

#line default
#line hidden


#line 83 "..\..\..\Admin\AddServiceWindow - Копировать.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox typeAppliance;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp2;component/admin/addservicewindow%20-%20%d0%9a%d0%be%d0%bf%d0%b8%d1%80%d0" +
                    "%be%d0%b2%d0%b0%d1%82%d1%8c.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Admin\AddServiceWindow - Копировать.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.serviceNameText = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 2:
                    this.priceText = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 3:
                    this.addTariffPlanButton = ((System.Windows.Controls.Button)(target));

#line 72 "..\..\..\Admin\AddServiceWindow - Копировать.xaml"
                    this.addTariffPlanButton.Click += new System.Windows.RoutedEventHandler(this.addTariffPlanButton_Click);

#line default
#line hidden
                    return;
                case 4:
                    this.unlimMinutesCheck = ((System.Windows.Controls.CheckBox)(target));
                    return;
                case 5:
                    this.unlimSMSCheck = ((System.Windows.Controls.CheckBox)(target));
                    return;
                case 6:
                    this.unlimMMSCheck = ((System.Windows.Controls.CheckBox)(target));
                    return;
                case 7:
                    this.unlimMegabytesCheck = ((System.Windows.Controls.CheckBox)(target));
                    return;
                case 8:
                    this.typeAppliance = ((System.Windows.Controls.ComboBox)(target));

#line 83 "..\..\..\Admin\AddServiceWindow - Копировать.xaml"
                    this.typeAppliance.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.typesText_SelectionChanged);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }
    }
}


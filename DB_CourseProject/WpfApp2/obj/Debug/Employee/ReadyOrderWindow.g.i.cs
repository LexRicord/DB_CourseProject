﻿#pragma checksum "..\..\..\Employee\ReadyOrderWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F4FE32D59445EB5360D1692A3EC09865F2C6F2B6E35465629E8E73FCCE44C74E"
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
using WpfApp2.Employee;


namespace WpfApp2.Employee {
    
    
    /// <summary>
    /// ReadyOrderWindow
    /// </summary>
    public partial class ReadyOrderWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\Employee\ReadyOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox orderId;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Employee\ReadyOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addTypesButton;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Employee\ReadyOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox unlimMinutesCheck;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Employee\ReadyOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox unlimSMSCheck;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Employee\ReadyOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox unlimMMSCheck;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Employee\ReadyOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox unlimMegabytesCheck;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp2;component/employee/readyorderwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Employee\ReadyOrderWindow.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.orderId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.addTypesButton = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\Employee\ReadyOrderWindow.xaml"
            this.addTypesButton.Click += new System.Windows.RoutedEventHandler(this.addTypesButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.unlimMinutesCheck = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 4:
            this.unlimSMSCheck = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.unlimMMSCheck = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.unlimMegabytesCheck = ((System.Windows.Controls.CheckBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\Admin\NewMasterWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1FBCF562C91FD808C8FCEF1F491E1DCCBA5E12568D058787DBF399BA4BF75F35"
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


namespace WpfApp2.Admin {
    
    
    /// <summary>
    /// NewMasterWindow
    /// </summary>
    public partial class NewMasterWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\Admin\NewMasterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox employeeSur;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Admin\NewMasterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox emplName;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Admin\NewMasterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox secondName;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\Admin\NewMasterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox loginEmpl;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\Admin\NewMasterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox typeAppliances;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\Admin\NewMasterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button loginButton;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp2;component/admin/newmasterwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Admin\NewMasterWindow.xaml"
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
            this.employeeSur = ((System.Windows.Controls.ComboBox)(target));
            
            #line 40 "..\..\..\Admin\NewMasterWindow.xaml"
            this.employeeSur.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.employeeSur_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.emplName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.secondName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.loginEmpl = ((System.Windows.Controls.ComboBox)(target));
            
            #line 100 "..\..\..\Admin\NewMasterWindow.xaml"
            this.loginEmpl.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.loginEmpl_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.typeAppliances = ((System.Windows.Controls.ComboBox)(target));
            
            #line 118 "..\..\..\Admin\NewMasterWindow.xaml"
            this.typeAppliances.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.typeAppliances_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.loginButton = ((System.Windows.Controls.Button)(target));
            
            #line 128 "..\..\..\Admin\NewMasterWindow.xaml"
            this.loginButton.Click += new System.Windows.RoutedEventHandler(this.loginButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

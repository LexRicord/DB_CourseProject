﻿#pragma checksum "..\..\..\..\..\Views\Admin\AddTypeWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7245609B7AA9156BDA275DBF86565B14DAB3DA15"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DB_CourseProject.Views.Admin;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace DB_CourseProject.Views.Admin {
    
    
    /// <summary>
    /// AddTypeWindow
    /// </summary>
    public partial class AddTypeWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\..\..\Views\Admin\AddTypeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox serviceNameText;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\..\Views\Admin\AddTypeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addTypesButton;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\..\Views\Admin\AddTypeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox unlimMinutesCheck;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\..\Views\Admin\AddTypeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox unlimSMSCheck;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\..\Views\Admin\AddTypeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox unlimMMSCheck;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\..\Views\Admin\AddTypeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox unlimMegabytesCheck;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\..\Views\Admin\AddTypeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox typeAppliance;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DB_CourseProject;component/views/admin/addtypewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Admin\AddTypeWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.serviceNameText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.addTypesButton = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\..\..\Views\Admin\AddTypeWindow.xaml"
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
            case 7:
            this.typeAppliance = ((System.Windows.Controls.ComboBox)(target));
            
            #line 68 "..\..\..\..\..\Views\Admin\AddTypeWindow.xaml"
            this.typeAppliance.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.typesText1_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

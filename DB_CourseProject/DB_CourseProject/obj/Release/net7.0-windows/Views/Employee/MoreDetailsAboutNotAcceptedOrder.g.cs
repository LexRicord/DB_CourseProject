﻿#pragma checksum "..\..\..\..\..\Views\Employee\MoreDetailsAboutNotAcceptedOrder.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2F8B2B944D3673ACC58821BDD6B6DB41166C06A2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DB_CourseProject.Views.Employee;
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


namespace DB_CourseProject.Views.Employee {
    
    
    /// <summary>
    /// MoreDetailsAboutNotAcceptedOrder
    /// </summary>
    public partial class MoreDetailsAboutNotAcceptedOrder : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\..\..\Views\Employee\MoreDetailsAboutNotAcceptedOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox typeAppliance;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\..\Views\Employee\MoreDetailsAboutNotAcceptedOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox loginText;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\..\Views\Employee\MoreDetailsAboutNotAcceptedOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exit;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\..\Views\Employee\MoreDetailsAboutNotAcceptedOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Model;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\..\Views\Employee\MoreDetailsAboutNotAcceptedOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox servicePack;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\..\..\Views\Employee\MoreDetailsAboutNotAcceptedOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Price;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\..\..\Views\Employee\MoreDetailsAboutNotAcceptedOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid serviceDG;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\..\..\Views\Employee\MoreDetailsAboutNotAcceptedOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox OrderDescription;
        
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
            System.Uri resourceLocater = new System.Uri("/DB_CourseProject;component/views/employee/moredetailsaboutnotacceptedorder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Employee\MoreDetailsAboutNotAcceptedOrder.xaml"
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
            
            #line 9 "..\..\..\..\..\Views\Employee\MoreDetailsAboutNotAcceptedOrder.xaml"
            ((DB_CourseProject.Views.Employee.MoreDetailsAboutNotAcceptedOrder)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.typeAppliance = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.loginText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.exit = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\..\..\Views\Employee\MoreDetailsAboutNotAcceptedOrder.xaml"
            this.exit.Click += new System.Windows.RoutedEventHandler(this.exit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Model = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.servicePack = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.Price = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.serviceDG = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            this.OrderDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

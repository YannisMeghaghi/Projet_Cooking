﻿#pragma checksum "..\..\Client_normal_gestion.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F3D5CDC71966564F7937E3CE89E6FB65C2465058E861538C8B4A5EB4487227F0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Cooking;
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


namespace Cooking {
    
    
    /// <summary>
    /// Client_normal_gestion
    /// </summary>
    public partial class Client_normal_gestion : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Client_normal_gestion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button boutton_compte;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Client_normal_gestion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button boutton_commande;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Client_normal_gestion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button boutton_deconnexion;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Client_normal_gestion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textblock_recup_id;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Client_normal_gestion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bouton_classement;
        
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
            System.Uri resourceLocater = new System.Uri("/Cooking;component/client_normal_gestion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Client_normal_gestion.xaml"
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
            this.boutton_compte = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\Client_normal_gestion.xaml"
            this.boutton_compte.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.boutton_commande = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\Client_normal_gestion.xaml"
            this.boutton_commande.Click += new System.Windows.RoutedEventHandler(this.boutton_commande_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.boutton_deconnexion = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\Client_normal_gestion.xaml"
            this.boutton_deconnexion.Click += new System.Windows.RoutedEventHandler(this.boutton_deconnexion_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textblock_recup_id = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.bouton_classement = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\Client_normal_gestion.xaml"
            this.bouton_classement.Click += new System.Windows.RoutedEventHandler(this.bouton_classement_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


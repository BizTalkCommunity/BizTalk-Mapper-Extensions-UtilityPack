﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BizTalk.MapExtention.LookupFunctoid {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class CRMLookupResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CRMLookupResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BizTalk.MapExtention.LookupFunctoid.CRMLookupResources", typeof(CRMLookupResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap IDS_CRMLOOKUP_BITMAP {
            get {
                object obj = ResourceManager.GetObject("IDS_CRMLOOKUP_BITMAP", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This functoid return a resolution internal GUID value of lookup field in CRM, parameters expected 
        ///
        ///- SSO Application Name
        ///- CRM Guid Field Name (Output Field Name)
        ///- CRM Entity Name 
        ///- CRM Input Field Name
        ///- CRM Input Field Value.
        /// </summary>
        internal static string IDS_CRMLOOKUP_DESCRIPTION {
            get {
                return ResourceManager.GetString("IDS_CRMLOOKUP_DESCRIPTION", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CRM Lookup.
        /// </summary>
        internal static string IDS_CRMLOOKUP_NAME {
            get {
                return ResourceManager.GetString("IDS_CRMLOOKUP_NAME", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to To resolve CRM lookup in map.
        /// </summary>
        internal static string IDS_CRMLOOKUP_TOOLTIP {
            get {
                return ResourceManager.GetString("IDS_CRMLOOKUP_TOOLTIP", resourceCulture);
            }
        }
    }
}

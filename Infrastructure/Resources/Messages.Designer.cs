﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infrastructure.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Infrastructure.Resources.Messages", typeof(Messages).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to وارد نمودن چکیده محتوا الزامی می باشد.
        /// </summary>
        public static string ArticleAbstractIsRequired {
            get {
                return ResourceManager.GetString("ArticleAbstractIsRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to وارد کردن تاریخ انقضاء الزامی می باشد.
        /// </summary>
        public static string ArticleDateTimeIsRequired {
            get {
                return ResourceManager.GetString("ArticleDateTimeIsRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to وارد نمودن متن خبر الزامی می باشد.
        /// </summary>
        public static string ArticleFullTextIsRequired {
            get {
                return ResourceManager.GetString("ArticleFullTextIsRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to وارد کردن عنوان الزامی می باشد.
        /// </summary>
        public static string ArticleTitleIsRequired {
            get {
                return ResourceManager.GetString("ArticleTitleIsRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to وارد نمودن نویسنده الزامی می باشد.
        /// </summary>
        public static string AuthorNameIsRequired {
            get {
                return ResourceManager.GetString("AuthorNameIsRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to نام مارک انگلیسی را وارد نمایید.
        /// </summary>
        public static string BrandrequairedEnbrand {
            get {
                return ResourceManager.GetString("BrandrequairedEnbrand", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to نام کاربری یا رمز عبور صحیح نمی باشد.
        /// </summary>
        public static string InvalidUserNameOrPassword {
            get {
                return ResourceManager.GetString("InvalidUserNameOrPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to وارد نمودن موضوع خبر الزامی می باشد.
        /// </summary>
        public static string SubjectIdIsRequired {
            get {
                return ResourceManager.GetString("SubjectIdIsRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to وارد کردن کد انبار الزامی است.
        /// </summary>
        public static string WarehouseCodeIsRequired {
            get {
                return ResourceManager.GetString("WarehouseCodeIsRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to وارد کردن نام انبار الزامی است.
        /// </summary>
        public static string WarehouseNameIsRequired {
            get {
                return ResourceManager.GetString("WarehouseNameIsRequired", resourceCulture);
            }
        }
    }
}
﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB.Exceptions
{
    using System;


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourceMessagesException
    {

        private static System.Resources.ResourceManager resourceMan;

        private static System.Globalization.CultureInfo resourceCulture;

        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public ResourceMessagesException()
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.Equals(null, resourceMan))
                {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("DB.Exceptions.ResourceMessagesException", typeof(ResourceMessagesException).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Globalization.CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        public static string NO_TOKEN
        {
            get
            {
                return ResourceManager.GetString("NO_TOKEN", resourceCulture);
            }
        }

        public static string USER_WITHOUT_PERMISSION_TO_ACCESS_RESOURCES
        {
            get
            {
                return ResourceManager.GetString("USER_WITHOUT_PERMISSION_TO_ACCESS_RESOURCES", resourceCulture);
            }
        }

        public static string EMAIL_OR_PASSWORD_INVALID
        {
            get
            {
                return ResourceManager.GetString("EMAIL_OR_PASSWORD_INVALID", resourceCulture);
            }
        }

        public static string NAME_EMPTY
        {
            get
            {
                return ResourceManager.GetString("NAME_EMPTY", resourceCulture);
            }
        }

        public static string FIRST_NAME_EMPTY
        {
            get
            {
                return ResourceManager.GetString("FIRST_NAME_EMPTY", resourceCulture);
            }
        }

        public static string LAST_NAME_EMPTY
        {
            get
            {
                return ResourceManager.GetString("LAST_NAME_EMPTY", resourceCulture);
            }
        }

        public static string PASSWORD_GREATER_THAN_OR_EQUAL_TO_SIX
        {
            get
            {
                return ResourceManager.GetString("PASSWORD_GREATER_THAN_OR_EQUAL_TO_SIX", resourceCulture);
            }
        }

        public static string EMAIL_EMPTY
        {
            get
            {
                return ResourceManager.GetString("EMAIL_EMPTY", resourceCulture);
            }
        }

        public static string EMAIL_ALREADY_EXISTS
        {
            get
            {
                return ResourceManager.GetString("EMAIL_ALREADY_EXISTS", resourceCulture);
            }
        }

    }
}

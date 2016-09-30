namespace Ataoge.Resources {
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Default {
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;

        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Default() {

        }

         /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Ataoge.Resources.Default", global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(Default)).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
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
        ///   查找类似 ExceptionFormatterHeader 的本地化字符串。
        /// </summary>
        internal static string ExceptionFormatterHeader {
            get {
                return ResourceManager.GetString("ExceptionFormatterHeader", resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似 ExceptionSummary 的本地化字符串。
        /// </summary>
        internal static string ExceptionSummary {
            get {
                return ResourceManager.GetString("ExceptionSummary", resourceCulture);
            }
        }

        // <summary>
        ///   查找类似 ExceptionDetails 的本地化字符串。
        /// </summary>
        internal static string ExceptionDetails {
            get {
                return ResourceManager.GetString("ExceptionDetails", resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似 ExceptionType 的本地化字符串。
        /// </summary>
        internal static string ExceptionType {
            get {
                return ResourceManager.GetString("ExceptionType", resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似 ExceptionStackTraceDetails 的本地化字符串。
        /// </summary>
        internal static string ExceptionStackTraceDetails {
            get {
                return ResourceManager.GetString("ExceptionStackTraceDetails", resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似 PropertyAccessFailed 的本地化字符串。
        /// </summary>
        internal static string PropertyAccessFailed {
            get {
                return ResourceManager.GetString("PropertyAccessFailed", resourceCulture);
            }
        }

        /// <summary>
        ///   查找类似 ExceptionNullOrEmptyString 的本地化字符串。
        /// </summary>
        internal static string ExceptionNullOrEmptyString {
            get {
                return ResourceManager.GetString("ExceptionNullOrEmptyString", resourceCulture);
            }
        }
    }
}
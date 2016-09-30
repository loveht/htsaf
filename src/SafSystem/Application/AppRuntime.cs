using System;

namespace Ataoge.Application
{
    /// <summary>
    /// Represents the Application Runtime from where the application is created, initialized and started. 
    /// </summary>
    public sealed class AppRuntime
    {
        #region Private Static Fields

        private static readonly AppRuntime instance = new AppRuntime();
        private static readonly object lockObj = new object();

        #endregion Private Static Fields

        #region Private Fields

        private IApp currentApplication = null;

        #endregion Private Fields

        #region Ctor

        static AppRuntime()
        {
        }

        private AppRuntime()
        {
        }

        #endregion Ctor

        #region Public Static Properties

        /// <summary>
        /// Gets the instance of the current <c> ApplicationRuntime </c> class. 
        /// </summary>
        public static AppRuntime Instance
        {
            get { return instance; }
        }

        #endregion Public Static Properties

        #region Public Properties

        /// <summary>
        /// Gets the instance of the currently running application. 
        /// </summary>
        public IApp CurrentApplication
        {
            get { return currentApplication; }
        }

        #endregion Public Properties

        public static IApp Create(Action<AppConfig> action = null)
        {
            AppConfig appConfig = new AppConfig();
            if (action != null) 
            {
               action(appConfig);
            }
            return Create(appConfig);
        }

        public static IApp Create(AppConfig appConfig)
        {
            lock (lockObj)
            {
                if (instance.currentApplication == null)
                {
                    lock (lockObj)
                    {
                        instance.currentApplication = new App(appConfig);
                    }
                }
            }
            return instance.currentApplication; 
        }
    }
}
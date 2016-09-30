using System;

namespace Ataoge.Application
{
    /// <summary>
    /// Represents the implementation of the application.
    /// </summary>
    public class App : IApp
    {
        public App(AppConfig config)
        {
            this.config = config;
        }

        private AppConfig config;

        public IApp Start()
        {
            return this;
        }

        public void Start(Action<IApp> action)
        {
            throw new NotImplementedException();
        }
    }
}
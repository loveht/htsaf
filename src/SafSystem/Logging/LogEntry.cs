using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Ataoge.Logging.Formatters;
using Ataoge.Reflection;

namespace Ataoge.Logging
{
    public class LogEntry //: ICloneable
    {
        private static readonly bool isFullyTrusted;
        private static readonly TextFormatter toStringFormatter;

         private string message = string.Empty;
        private string title = string.Empty;

        //[NonSerialized]
        private ICollection<string> categories = new List<string>(0);
        private string[] categoryStrings;

        private int priority = -1;
        private int eventId = 0;
        private Guid activityId;
        private Guid? relatedActivityId;

        private LogLevel severity = LogLevel.Info; //TraceEventType.Information;

        private string machineName = string.Empty;
        private DateTime timeStamp = DateTime.MaxValue;

        private StringBuilder errorMessages;
        private IDictionary<string, object> extendedProperties;


         internal bool timeStampInitialized = false;

        static LogEntry()
        {
            //isFullyTrusted = typeof(LogEntry).Assembly.IsFullyTrusted;
            toStringFormatter = new TextFormatter();
        }

        /// <summary>
        /// Initialize a new instance of a <see cref="LogEntry"/> class.
        /// </summary>
        public LogEntry()
        {
        }


        /// <summary>
        /// Message body to log.  Value from ToString() method from message object.
        /// </summary>
        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }

        /// <summary>
        /// Category name used to route the log entry to a one or more trace listeners.
        /// </summary>
        public ICollection<string> Categories
        {
            get { return categories; }
            set { this.categories = value; }
        }

        /// <summary>
        /// Importance of the log message.  Only messages whose priority is between the minimum and maximum priorities (inclusive)
        /// will be processed.
        /// </summary>
        public int Priority
        {
            get { return this.priority; }
            set { this.priority = value; }
        }

        /// <summary>
        /// Event number or identifier.
        /// </summary>
        public int EventId
        {
            get { return this.eventId; }
            set { this.eventId = value; }
        }

        /// <summary>
        /// Log entry severity as a <see cref="Severity"/> enumeration. (Unspecified, Information, Warning or Error).
        /// </summary>
        public LogLevel Severity
        {
            get { return this.severity; }
            set { this.severity = value; }
        }

        /// <summary>
        /// <para>Gets the string representation of the <see cref="Severity"/> enumeration.</para>
        /// </summary>
        /// <value>
        /// <para>The string value of the <see cref="Severity"/> enumeration.</para>
        /// </value>
        public string LoggedSeverity
        {
            get { return severity.ToString(); }
        }

        /// <summary>
        /// Additional description of the log entry message.
        /// </summary>
        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        /// <summary>
        /// Date and time of the log entry message.
        /// </summary>
        public DateTime TimeStamp
        {
            get
            {
                if (!timeStampInitialized)
                {
                    InitializeTimeStamp();
                }

                return this.timeStamp;
            }
            set
            {
                this.timeStamp = value;
                timeStampInitialized = true;
            }
        }

        /// <summary>
        /// Read-only property that returns the timeStamp formatted using the current culture.
        /// </summary>
        public string TimeStampString
        {
            get { return TimeStamp.ToString(CultureInfo.CurrentCulture); }
        }

        #region Intrinsic Property Initialization

        private void InitializeTimeStamp()
        {
            this.TimeStamp = DateTime.UtcNow;
        }

        #endregion
    }
}
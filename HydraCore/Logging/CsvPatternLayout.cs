using System;
using System.IO;
using System.Reflection;
using log4net.Core;
using log4net.Layout;

namespace HydraCore.Logging
{
    public class CsvPatternLayout : PatternLayout
    {
        public override void ActivateOptions()
        {
            // register custom pattern tokens
            AddConverter("newfield", typeof(NewFieldConverter));
            AddConverter("endrow", typeof(EndRowConverter));
            base.ActivateOptions();
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            if (loggingEvent.MessageObject != null)
            {
                PropertyInfo[] properties = loggingEvent.MessageObject.GetType().GetProperties();
                foreach (PropertyInfo prop in properties)
                {
                    object value = prop.GetValue(loggingEvent.MessageObject, null);
                    loggingEvent.Properties[prop.Name] = value;
                }
            }

            CsvTextWriter ctw = new CsvTextWriter(writer);
            // write the starting quote for the first field
            ctw.WriteQuote();
            base.Format(ctw, loggingEvent);
        }

        public override string Header
        {
            get
            {
                var version = Assembly.GetExecutingAssembly().GetName().Version;
                return base.Header.Replace("%date", DateTime.Now.ToString("o"))
                    .Replace("%version", version.ToString());
            }

            set { base.Header = value; }
        }
    }
}
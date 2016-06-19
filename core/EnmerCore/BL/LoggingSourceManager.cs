using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnmerCore.DataObjects;
using EnmerCore.Exceptions;

namespace EnmerCore.BL
{
    public class LoggingSourceManager
    {
        public LoggingSource GetLoggingSource(long loggingSourceID)
        {
            using (var context = new EnmerDbContext())
            {
                var loggingSource = GetLoggingSource(loggingSourceID, context);
                if (loggingSource != null && !loggingSource.IsDeleted)
                {
                    return loggingSource;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<LoggingSource> GetLoggingSourceList()
        {
            using (var context = new EnmerDbContext())
            {
                return context.LoggingSources.Where(s => !s.IsDeleted).ToList();
            }
        }

        public LoggingSource GetLoggingSource(string code)
        {
            using (var context = new EnmerDbContext())
            {
                var loggingSource = context.LoggingSources.FirstOrDefault(s => s.Code == code);
                if (loggingSource != null && !loggingSource.IsDeleted)
                {
                    return loggingSource;
                }
                else
                {
                    return null;
                }
            }
        }

        internal LoggingSource GetLoggingSource(long loggingSourceID, EnmerDbContext context)
        {
            return context.LoggingSources.FirstOrDefault(s => s.LoggingSourceID == loggingSourceID);
        }

        private void CheckCodeUniqueness(string code, EnmerDbContext context)
        {
            if (code != null)
            {
                if (context.LoggingSources.Any(s => s.Code == code))
                {
                    throw new LoggingSourceCodeException();
                }
            }
        }

        public long CreateLoggingSource(string code, string name, string description,
            string userCreatedID, string siteLink)
        {
            using (var context = new EnmerDbContext())
            {
                CheckCodeUniqueness(code, context);
                var loggingSource = new LoggingSource()
                                    {
                                        Code = code,
                                        Description = description,
                                        IsDeleted = false,
                                        IsEnabled = true,
                                        UserAdded = userCreatedID,
                                        Name = name,
                                        SiteLink = siteLink
                                    };
                context.LoggingSources.Add(loggingSource);
                context.SaveChanges();
                return loggingSource.LoggingSourceID;
            }
        }

        public void EditLoggingSource(long loggingSourceID, string code, string name, string description,
            string siteLink, bool isEnabled)
        {
            using (var context = new EnmerDbContext())
            {
                var loggingSource = GetLoggingSource(loggingSourceID, context);
                if (loggingSource != null)
                {
                    if (loggingSource.Code!=code)
                    {
                        CheckCodeUniqueness(code, context);
                    }
                    loggingSource.Code = code;
                    loggingSource.Name = name;
                    loggingSource.Description = description;
                    loggingSource.SiteLink = siteLink;
                    loggingSource.IsEnabled = isEnabled;
                    context.SaveChanges();
                }
            }
        }

        public void Delete(long loggingSourceID)
        {
            using (var context = new EnmerDbContext())
            {
                var loggingSource = GetLoggingSource(loggingSourceID, context);
                if (loggingSource != null)
                {
                    loggingSource.IsDeleted = true;
                    context.SaveChanges();
                }
            }
        }
    }
}

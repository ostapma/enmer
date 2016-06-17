using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using EnmerCore.BL;
using EnmerWeb.Models;
using Microsoft.AspNet.Identity;

namespace EnmerWeb.Controllers.Api
{
    public class LoggingSourceController : ApiController
    {
        [Authorize]
        public IHttpActionResult Get()
        {
            var loggingSources = new LoggingSourceManager().GetLoggingSourceList();

            return this.Ok(loggingSources.ConvertAll(s =>


                new LoggingSourceModel
                {
                    Code = s.Code,
                    IsEnabled = s.IsEnabled,
                    Description = s.Description,
                    SiteLink = s.SiteLink,
                    Name = s.Name,
                    ID = s.LoggingSourceID
                }));
        }

        [Authorize]
        public IHttpActionResult Get(long id)
        {
            var loggingSource = new LoggingSourceManager().GetLoggingSource(id);
            if (loggingSource!=null)
            {
                return this.Ok(new LoggingSourceModel
                {
                    Code = loggingSource.Code,
                    IsEnabled = loggingSource.IsEnabled,
                    Description = loggingSource.Description,
                    SiteLink = loggingSource.SiteLink,
                    Name = loggingSource.Name,
                    ID = loggingSource.LoggingSourceID
                });
            }
            else
            {
                return this.NotFound();
            }
        }

        [Authorize]
        public IHttpActionResult Post([FromBody] LoggingSourceModel loggingSourceModel)
        {
            var sourceID = new LoggingSourceManager().CreateLoggingSource(loggingSourceModel.Code,
                loggingSourceModel.Name, loggingSourceModel.Description,
                User.Identity.GetUserId(),
                loggingSourceModel.SiteLink);
            loggingSourceModel.ID = sourceID;
            return this.Ok(loggingSourceModel);
        }

        [Authorize]
        public IHttpActionResult Put(long id, [FromBody] LoggingSourceModel loggingSourceModel)
        {
            new LoggingSourceManager().EditLoggingSource(id, loggingSourceModel.Code,
                loggingSourceModel.Name, loggingSourceModel.Description,
                loggingSourceModel.SiteLink, loggingSourceModel.IsEnabled);
            return this.Ok();
        }

        [Authorize]
        public IHttpActionResult Delete(long id)
        {
            new LoggingSourceManager().Delete(id);
            return this.Ok();
        }
    }
}
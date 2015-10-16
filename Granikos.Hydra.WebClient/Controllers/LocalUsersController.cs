﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Granikos.Hydra.WebClient.HydraConfigurationService;

namespace Granikos.Hydra.WebClient.Controllers
{
    // [Authorize]
    [RoutePrefix("api/LocalUsers")]
    public class LocalUsersController : ApiController
    {
        readonly ConfigurationServiceClient _service = new ConfigurationServiceClient();

        // GET api/LocalUsers/Templates
        [HttpGet]
        [Route("Templates")]
        public UserTemplate[] GetTemplates()
        {
            return _service.GetLocalUserTemplates();
        }

        public class GenerateParams
        {
            public string template;
            public string pattern;
            public string domain;
        }

        // POST api/LocalUsers/Generate/10
        [HttpPost]
        [Route("Generate/{count:int}")]
        public bool Generate(GenerateParams parameters, int count)
        {
            return _service.GenerateLocalUsers(parameters.template, parameters.pattern, parameters.domain, count);
        }

        // GET api/LocalUsers
        [HttpGet]
        [Route("")]
        public UsersWithTotal Paged([FromUri]PagedFilter filter)
        {
            var page = filter != null ? filter.PageNumber : 1;
            var pageSize = filter != null ? filter.PageSize : 25;
            return _service.GetLocalUsers(page, pageSize);
        }

        // GET api/LocalUsers/Search
        [HttpGet]
        [Route("Search/{search}")]
        public IEnumerable<string> Search(string search)
        {
            return _service.SearchLocalUsers(search);
        }

        // GET api/LocalUsers/Export
        [HttpGet]
        [Route("Export")]
        public HttpResponseMessage Export()
        {
            var stream = _service.ExportLocalUsers();

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(stream),

            };


            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "LocalUsers.csv"
            };

            return response;
        }

        // POST api/LocalUsers/Import
        [HttpPost]
        [Route("Import")]
        public async Task<ImportResult> Import()
        {
            var stream = await GetUploadedFileStream();

            return await _service.ImportLocalUsersAsync(stream);
        }

        // POST api/LocalUsers/ImportWithOverwrite
        [HttpPost]
        [Route("ImportWithOverwrite")]
        public async Task<ImportResult> ImportWithOverwrite()
        {
            var stream = await GetUploadedFileStream();

            return await _service.ImportLocalUsersWithOverwriteAsync(stream);
        }

        private async Task<Stream> GetUploadedFileStream()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var provider = new MultipartMemoryStreamProvider();

            var reader = await Request.Content.ReadAsMultipartAsync(provider);
            var stream = await reader.Contents.First().ReadAsStreamAsync();

            return stream;
        }

        // GET api/LocalUsers/5
        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var user = _service.GetLocalUser(id);

            if (user == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Could not find user.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        // POST api/LocalUsers
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Add([FromBody]User user)
        {
            var added = _service.AddLocalUser(user);

            if (added == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not add user.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, added);
        }

        // PUT api/LocalUsers/5
        [HttpPut]
        [Route("{id:int}")]
        public HttpResponseMessage Update(int id, [FromBody]User user)
        {
            var updated = _service.UpdateLocalUser(user);

            if (updated == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not update user.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, updated);
        }

        // DELETE api/LocalUsers/5
        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            if (!_service.DeleteLocalUser(id))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Could not delete user.");
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
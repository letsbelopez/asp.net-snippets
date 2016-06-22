using Sabio.Web.Domain;
using Sabio.Web.Models.Requests;
using Sabio.Web.Models.Responses;
using Sabio.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sabio.Web.Controllers.Api
{
    [RoutePrefix("api/languages")]
    public class LanguagesApiController : ApiController
    {
        private ILanguageService _languageService;

        public LanguagesApiController()
        {

        }

        public LanguagesApiController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [Route, HttpPost]
        public HttpResponseMessage Insert(LanguageAddRequest model)
        {
            if (ModelState.IsValid)
            {
                int id = _languageService.Insert(model);
                ItemResponse<int> response = new ItemResponse<int>();
                response.Item = id;
                return Request.CreateResponse(response);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Update(LanguageUpdateRequest model, int id)
        {
            if (ModelState.IsValid)
            {
                _languageService.Update(model);
                return Request.CreateResponse(new SuccessResponse());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetOne(int id)
        {
            if (ModelState.IsValid)
            {
                Language model = _languageService.GetOne(id);
                ItemResponse<Language> response = new ItemResponse<Language>();
                response.Item = model;
                return Request.CreateResponse(response);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Route, HttpGet]
        public HttpResponseMessage SelectAll()
        {
            try
            {
                List<Language> list = _languageService.GetLanguages();
                ItemsResponse<Language> response = new ItemsResponse<Language>();
                response.Items = list;
                return Request.CreateResponse(response);
            }
            catch (Exception ex)
            {
                var response = new ErrorResponse(ex.Message);
                return Request.CreateResponse(response);
            }
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _languageService.Delete(id);
                return Request.CreateResponse(new SuccessResponse());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
    }
}

﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using RestSharp;
using SPS.UI.Data.Core;
using SPS.UI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SPS.UI.Service.Extensions
{
    public class HttpRequestExtension : IHttpRequestExtension
    {
        private IHttpContextAccessor _httpContextAccessor;
        private RestSharpConfiguration _restSharpConfiguration;

        public HttpRequestExtension(IHttpContextAccessor httpContextAccessor, IOptions<RestSharpConfiguration> options)
        {
            _httpContextAccessor = httpContextAccessor;
            _restSharpConfiguration = options.Value;
        }
        #region Method Private
        private string Token { get => _httpContextAccessor.HttpContext.Session.GetString(Constants.SessionKey.Token); }
        private string TokenScheme { get => _httpContextAccessor.HttpContext.Session.GetString(Constants.SessionKey.TokenScheme); }

        private BodyParamsModel ToBodyParams(object body)
        {
            BodyParamsModel bodyParams = new BodyParamsModel();
            if(body == null)
            {
                return null;
            }
            bodyParams.Params = (IDictionary<string, object>)body.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(x => x.PropertyType != typeof(IFormFile))
                .ToDictionary(x => x.Name, x => x.GetValue(body, null));
            return bodyParams;
        }

        private RestRequest CreateRestRequest(string url, List<QueryPamaramsModel> queries)
        {
            RestRequest request = new RestRequest(url, (Method)DataFormat.Json);

            if(!string.IsNullOrEmpty(Token))
            {
                request.AddHeader(Constants.Request.Header.Authorization, $"{TokenScheme} {Token}");
            }
            request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            
            if(queries != null)
            {
                foreach(var query in queries)
                {
                    request.AddQueryParameter(query.Key, query.Value);
                }
            }
            return request;
        }

        private RestRequest CreateJsonRestRequest(string url,object data ,List<QueryPamaramsModel> queries)
        {
            RestRequest request = CreateRestRequest(url, queries);

            if(data !=null)
            {
                request.AddJsonBody(data);
            }
            return request;
        }

        private RestRequest CreateFormRestRequest(string url, object data, List<QueryPamaramsModel> queries)
        {
            RestRequest request = CreateRestRequest(url, queries);

            if (data == null)
            {
                return request;
            }
            var bodyParams = ToBodyParams(data);
            if(bodyParams ==null)
            {
                return request;
            }
            if(bodyParams.Params !=null)
            {
                foreach(var param in bodyParams.Params)
                {
                    request.AddParameter(param.Key, param.Value, ParameterType.GetOrPost);
                }
            }

            return request;
        }
        #endregion

        public Task<T> DeleteFormRequestAsync<T>(string url, object data, List<QueryPamaramsModel> queries = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteJsonFormRequestAsync<T>(string url, object data, List<QueryPamaramsModel> queries = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetRequestAsync<T>(string url, List<QueryPamaramsModel> queries = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> PostFormRequestAsync<T>(string url, object data, List<QueryPamaramsModel> queries = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> PostJsonRequestAsync<T>(string url, object data, List<QueryPamaramsModel> queries = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> PutFormRequestAsync<T>(string url, object data, List<QueryPamaramsModel> queries = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> PutJsonRequestAsync<T>(string url, object data, List<QueryPamaramsModel> queries = null)
        {
            throw new NotImplementedException();
        }
    }
}

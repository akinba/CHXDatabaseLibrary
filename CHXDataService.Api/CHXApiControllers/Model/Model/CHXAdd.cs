﻿using CHXConverter;
using CHXGeoJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CHXDatabase.IO;
using Newtonsoft.Json;

namespace CHXDataService.Api.CHXApiControllers.Model.Model
{
    public class CHXAdd : CHXDataApi, ICHXDataApiModel
    {
        public CHXAdd(ClaimsPrincipal principal) : base(principal)
        {

        }

        public override object Call(CHXRequest data, string method)
        {
            if (method.ToLower() != "post") return null;


            var _name = data.Find("name");
            var _model = data.Find("model");

            var jsonData = JsonConvert.DeserializeObject(data.Data);

            var _server = data.Find("server");
            var _schema = data.Find("schema");
            var _query = data.Find("query");

            if (_server == null) return null;
            if (_query == null) return null;

            var mydb = CHXDatabaseFactory.GetDatabase(_server.Value.ToString());

            if (mydb == null) throw new NullReferenceException($"{_server.Value.ToString()} isimli veri tabanı bulunamadı");


            var query = mydb.Database.ConvertQuery<string>(data.Data, CHXQueryType.Json);
            var result = mydb.Database.RunQuery<dynamic>(query);

            if (result == null) return null;

            var collection = new CHXFeatureCollection();
            collection.features = result as CHXFeatures;
            collection.type = "FeatureCollection";

            return collection;
        }

        public override string GetPermissionName()
        {
            return "model.add";
        }
    }
}

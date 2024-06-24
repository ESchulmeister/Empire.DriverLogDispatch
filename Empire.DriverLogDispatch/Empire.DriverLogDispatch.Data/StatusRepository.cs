﻿using Empire.Shared.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Empire.DriverLog.Data
{
    public class StatusRepository : Repository
    {


        #region Constructors

        public StatusRepository()
        {
            this.ConnectionString = "DevDefaultConnection";
        }

        #endregion

        #region Methods
        public async Task<IDataReader> List(string sLocationCode)
        {
            var lstParameters = new List<IDbDataParameter>();

            using (var oSqlDataAdapter = new SqlDataAdapter(this.ConnectionString))
            {
                var oSqlParameter = oSqlDataAdapter.AddParameter("@LocationCode", DbType.String, sLocationCode, ParameterDirection.Input, 2);
                lstParameters.Add(oSqlParameter);

                return await oSqlDataAdapter.QueryAsync("[ES].[usp_selStatuses]", lstParameters);
            }
        }


        public Task<IDataReader> List()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
